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
        public ESys es;
        Stack<string> goals = new Stack<string>();
        string maingoal;
        string currentvariable;
        string savedquest;
        public TreeNode currentnode;

        private Thread cycle;
        private ManualResetEvent clickEvent = new ManualResetEvent(false);
        public frmConsult(ESys exsys,string g)
        {
            InitializeComponent();
            es = exsys;
            goals.Push(g);
            es.ConflictSet.Clear();
            es.WorkMemory.Clear();
            maingoal = g;
            currentnode = new TreeNode("Цель консультации: "+g);
        }

        private void frmConsult_Load(object sender, EventArgs e)
        {
            //string tmp;
            //List<string> conflictset = new List<string>();
            //add_rules_to_conflictset(conflictset, maingoal);
            //int i = 0;
            //int check;
            //while (i < conflictset.Count())              //choose first rule
            //{
            //    check = check_lside(conflictset[0],null);
            //    if (check == 1)
            //        break;
            //    else remember_askable = remember_askable || (check == -1);
            //    if (remember_askable)
            //        break;

            //    i++;
            //} 
            //display_values();
           // cmbAnswer.Focus();
            cycle = new Thread(new ThreadStart(start));  // порождаем поток цикла
            cycle.Start();
        }
        private void start()
        {
                string message = "";
                string tmp;
                int status = run(maingoal, out tmp, currentnode);
                if (status == 0)
                {
                    message = "Значение ";
                    tmp = "найти не удалось";
                }
                if (tmp != null)
                {
                    MessageBox.Show(message + maingoal + " " + tmp, "Результат");
                    this.BeginInvoke((MethodInvoker)(() => this.Close()));
                }
            
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
                (from lside in es.LSide
                 join fact in es.Fact
                 on lside.Fact equals fact.id
                 where lside.Имя==rule
                 select fact).ToArray();
        }
        int check_variable(string variable,string value,TreeNode tn)        //0-false/1-true/-1-unknown for askable
        {
            string found_value;
            int status;
            switch (es.Variable.FindByИмя(variable).Тип)
            {
                case "Выводимая":
                    status=run(variable,out found_value,tn);        //add to stack
                    if (found_value == null)            //не удалось вывести переменную
                        return 0;
                    else return Convert.ToInt32(found_value == value);
                case "Выводимо-запрашиваемая":
                    status=run(variable,out found_value,tn);        //add to stack
                    if (found_value == null)            //не удалось вывести переменную
                        goto case "Запрашиваемая";
                    else return Convert.ToInt32(found_value == value);
                case "Запрашиваемая":
                    
                    ((Form)this).Invoke((Action)(() =>
                        {
                            bindAnswer.DataSource = es.DomenVal.Where(e => e.Имя_домена == es.Variable.FindByИмя(variable).Домен);
                            this.cmbAnswer.DisplayMember = "Значение_домена";

                            savedquest = es.Variable.FindByИмя(variable).Вопрос == String.Empty ? variable + "?" : es.Variable.FindByИмя(variable).Вопрос;
                            currentvariable = variable;

                            this.cmbAnswer.DataSource = bindAnswer;
                            this.txtQuestion.Text = savedquest;
                            this.cmbAnswer.SelectedIndex = 0;
                            this.btnOk.Enabled = true;
                        }));

                        clickEvent.Reset();
                        clickEvent.WaitOne();   //ждем сигнала
                        
                        DataRow row=null;
                        ((Form)this).Invoke((Action)(() =>
                        { row = cmbAnswer.SelectedItem as DataRow; 
                        add_to_workmemory(currentvariable, row[1].ToString(),tn.Text);
                        btnOk.Enabled = false;
                        }));
                     return Convert.ToInt32(row[1].ToString() == value); 
                default: return -2;
            }
        }
        int check_lside(string rule,TreeNode tn)
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
                    correct = check_variable(facts[i].Переменная, facts[i].Значение_переменной,tn);
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
        void add_child(TreeNode parent,TreeNode child)
        {
            ESys.RulesRow rule =es.Rules.FindByИмя(child.Text);
            child.Text = rule[0].ToString()+": " + rule[1] + rule[2];
            parent.Nodes.Add(child);

        }
        int run(string goal,out string value,TreeNode current)
        {
            value=in_workmemory(goal);
            if (value == null)          //variable in workmemory
            {
                List<string> conflictset = new List<string>();
                add_rules_to_conflictset(conflictset, goal);
                int i=0;
                int check;
                TreeNode tn = new TreeNode();
                while (i < conflictset.Count())              //choose first rule
                {
                    tn.Text = conflictset[i];
                    
                    check=check_lside(conflictset[i],tn);
                    if (check == 1)
                        break;
                    
                    i++;
                }
                if (i < conflictset.Count())
                {
                    tn.Tag = conflictset[i];
                    add_child(current, tn);
                    value = rule_works(conflictset[i], goal);
                    return 1;
                }
                else
                    return 0;
            }
            else return 1;                                      //variable not in workmemory
        }
        void add_to_workmemory(string variable,string value,string rule)
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
                es.WorkMemory.AddWorkMemoryRow(fact.id, rule);
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
                es.WorkMemory.AddWorkMemoryRow(fact.id, rule);
                if (fact.Переменная == goal)
                    found = fact.Значение_переменной;
            }
            return found;
        }
        void add_rules_to_conflictset(List<string> conflictset,string goal)
        {
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
            clickEvent.Set(); 
        }
        private void display_values()
        {
            
        }
        private void frmConsult_FormClosed(object sender, FormClosedEventArgs e)
        {
            cycle.Abort();
        }

        private void frmConsult_Activated(object sender, EventArgs e)
        {
            
            
        }

        private void frmConsult_Shown(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Выдействительно хотите выйти?", "Внимание", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                currentnode = null;
                this.Close();
            }
        }
    }
}
