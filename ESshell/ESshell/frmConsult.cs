using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESshell
{
    public partial class frmConsult : Form
    {
        private ESys es;
        Stack<string> goals = new Stack<string>();
        string maingoal;
        string currentvariable;
        string savedquest;
        public frmConsult(ESys exsys,string g)
        {
            InitializeComponent();
            es = exsys;
            goals.Push(g);
            es.ConflictSet.Clear();
            es.WorkMemory.Clear();
            maingoal = g;
            
        }

        private void frmConsult_Load(object sender, EventArgs e)
        {
            string tmp; 
                run(maingoal,out tmp);
                if (tmp != null)
                    MessageBox.Show(tmp);
                else display_values();
            cmbAnswer.Focus();
        }
        private string in_workmemory(string name)
        {
            try
            {
                return
                    (from fact in es.Fact
                     join mem in es.WorkMemory
                     on fact.id equals mem.fact
                     where fact.Переменная == name
                     select fact.Значение_переменной).First();
            }
            catch (Exception ex)
            { return null; }
        }
        ESys.FactRow[] find_left_side(string rule)
        {
            return 
                (from fact in es.Fact
                 join lside in es.LSide
                 on fact.id equals lside.Fact
                 where lside.Имя==rule
                 select fact).ToArray();
        }
        int check_variable(string variable,string value)        //0-false/1-true/-1-unknown for askable
        {
            string found_value;
            int status;
            switch (es.Variable.FindByИмя(variable).Тип)
            {
                case "Выводимая":
                    status=run(variable,out found_value);        //add to stack
                    if (status == -1)
                        return status;
                    if (found_value == null)            //не удалось вывести переменную
                        return 0;
                    else return Convert.ToInt32(found_value == value);
                case "Выводимо-запрашиваемая":
                    status=run(variable,out found_value);        //add to stack
                    if (status == -1)
                        return status;
                    if (found_value == null)            //не удалось вывести переменную
                        goto case "Запрашиваемая";
                    else return Convert.ToInt32(found_value == value);
                case "Запрашиваемая":
                    
                        bindAnswer.DataSource = es.DomenVal.Where(e => e.Имя_домена == es.Variable.FindByИмя(variable).Домен);
                        cmbAnswer.DisplayMember = "Значение_домена";
                        
                        savedquest = es.Variable.FindByИмя(variable).Вопрос == String.Empty ? variable + "?" : es.Variable.FindByИмя(variable).Вопрос;
                        currentvariable = variable;
                        return -1;
                    
                default: return -2;
            }
        }
        int check_lside(string rule)
        {
            int correct;
            string value;
            ESys.FactRow[] facts = find_left_side(rule);
            int i = 0;
            while (i<facts.Count())
            {
                value = in_workmemory(facts[i].Переменная);
                if (value != null)
                    if (value == facts[i].Значение_переменной)
                    {
                        i++;
                        continue;
                    }
                    else return 0;
                else
                {
                    correct = check_variable(facts[i].Переменная, facts[i].Значение_переменной);
                    if (correct == 1)
                    {
                        i++;
                        continue;
                    }
                    else return correct;
                }   
            }
            return 1;
        }
        int run(string goal,out string value)
        {
            value=in_workmemory(goal);
            if (value == null)          //variable in workmemory
            {
                List<string> conflictset = new List<string>();
                add_rules_to_conflictset(conflictset, goal);
                int i=0;
                int check;
                bool remember_askable=false;
                while (i < conflictset.Count())              //choose first rule
                {
                    check=check_lside(conflictset[i]);
                    if (check == 1)
                        break;
                    else remember_askable =remember_askable || (check == -1);
                    
                    i++;
                }
                if (i < conflictset.Count())
                {
                    value = rule_works(conflictset[i], goal);
                    return 1;
                }
                else
                    if (remember_askable)
                        return -1;
                    else 
                        return 0;
            }
            else return 1;                                      //variable not in workmemory
        }
        void add_to_workmemory(string variable,string value)
        {

            ESys.FactRow fact = null;
            try
            {
                fact = es.Fact.Where(ex => ex.Значение_переменной == value && ex.Переменная == variable).First();
            }
            catch (Exception ex)
            {
                fact = es.Fact.AddFactRow(variable, value);
            }
            finally
            {
                es.WorkMemory.AddWorkMemoryRow(fact.id, "");
            }
        }
        string rule_works(string rule,string goal)
        {
            string found=null;
            ESys.FactRow[] facts=
                (from fact in es.Fact
                 join rside in es.RSide
                 on fact.id equals rside.Fact
                 where rside.Имя == rule
                 select fact).ToArray();
            foreach (ESys.FactRow fact in facts)
            {
                es.WorkMemory.AddWorkMemoryRow(fact.id, "worked");
                if (fact.Переменная == goal)
                    found = fact.Значение_переменной;
            }
            return found;
        }
        void add_rules_to_conflictset(List<string> conflictset,string goal)
        {
            //int[] facts=                                //факты, в выводе которых содержится цель
            //    (from fact in es.Fact
            //         join rside in es.RSide
            //         on fact.id equals rside.Fact
            //         where fact.Переменная==goal
            //         select fact.id
            //        ).ToArray();

            string[] rules=                             //правила, в посылках которых содержится цель
                (from rule in es.Rules
                 join rside in es.RSide
                 on rule.Имя equals rside.Имя
                 join fact in es.Fact
                 on rside.Fact equals fact.id
                 where fact.Переменная==goal
                 select rule.Имя).ToArray();
            foreach (string rule in rules)
                conflictset.Add(rule);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string message="";
            DataRow row = cmbAnswer.SelectedItem as DataRow;
            add_to_workmemory(currentvariable, row[1].ToString());
            string tmp;
            int status=run(maingoal,out tmp);
            if (status == 0)
            {
                message = "Значение ";
                tmp = "найти не удалось";
            }
            if (tmp != null)
            {
                MessageBox.Show(message + maingoal + " " + tmp, "Результат");
                this.Close();
            }
            else
                display_values();
            
        }
        private void display_values()
        {
            cmbAnswer.DataSource = bindAnswer;
            cmbAnswer.SelectedIndex = 0;
            txtQuestion.Text = savedquest;
        }
        private void frmConsult_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmConsult_Activated(object sender, EventArgs e)
        {
            
            
        }

        private void frmConsult_Shown(object sender, EventArgs e)
        {
            if (cmbAnswer.Items.Count == 0)
            {
                MessageBox.Show("Для определения цели не заданы правила");
                this.Close();
            }
        }
    }
}
