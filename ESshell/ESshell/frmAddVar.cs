﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESshell
{
    public partial class frmAddVar : Form
    {
        private frmMain parent;
        private int editrow;
        private string editname;
        public frmAddVar(frmMain par, ESys.VariableRow row, int index)
        {
            InitializeComponent();
            cmbType.Items.AddRange(new object[] {"Выводимая", "Запрашиваемая","Выводимо-запрашиваемая"});
            parent = par;
            for (int i = 0; i < par.es.Domens.Count; i++)
                cmbDomen.Items.Add(par.es.Domens[i][0]);
            editrow = index;
            if (index >= 0)
                Load_value(par, row);
           
        }
        public void Load_value(frmMain par, ESys.VariableRow row)
        {
            btnSave.Text = "Применить";
            txtName.Text = editname = row.Имя;
            cmbDomen.SelectedIndex = cmbDomen.Items.IndexOf(row.Домен);
            cmbType.SelectedIndex = cmbType.Items.IndexOf(row.Тип);
            txtQuest.Text = row.Вопрос;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private bool check_use(string variable,string domen)
        {
            string vars=String.Join(", ",
                from var in parent.es.Variable
                where var.Домен==domen && var.Имя!=variable
                select var.Имя
                );
            if (vars != "")
            {
                DialogResult dialog = MessageBox.Show("Домен уже используется в переменной " + vars+"\nПродолжить?", "Внимание", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                    return true;
                else return false;
            }
            else return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Replace(" ","").ToUpper() == "")
            {
                MessageBox.Show("Введите имя переменной");
                txtName.Focus();
            }
            else
            {
                try
                {

                    if (editrow >= 0)
                        if (check_use(editname, cmbDomen.SelectedItem.ToString()))
                        {

                            ESys.VariableRow row = parent.es.Variable.FindByИмя(editname);
                            row.Имя = txtName.Text.Trim();
                            row.Тип = cmbType.SelectedItem.ToString();
                            row.Домен = cmbDomen.SelectedItem.ToString();
                            row.Вопрос = txtQuest.Text.Trim();
                        }
                        else return;
                    else
                        
                            if (parent.es.Variable.Where(ex => ex.Имя.Replace(" ", "").ToUpper() == txtName.Text.Replace(" ", "").ToUpper()).Count() == 0)
                                parent.es.Variable.AddVariableRow(txtName.Text.Trim(), cmbType.SelectedItem.ToString(),
                                    cmbDomen.SelectedItem.ToString(), txtQuest.Text.Trim());
                            else throw new System.Data.ConstraintException("Переменная с таким именем уже существует");
                        
                    parent.dataVars.FirstDisplayedScrollingRowIndex = parent.dataVars.Rows.Count - 1;
                    if (editrow < 0)
                    {
                        txtName.Clear();
                        txtQuest.Clear();
                        cmbDomen.SelectedIndex = cmbType.SelectedIndex = 0;
                        txtName.Focus();
                        parent.dataVars.Rows[parent.dataVars.Rows.Count - 1].Selected = true;
                        this.Close();
                    }
                    else
                    {
                        
                        this.Close();
                    }
                }
                catch (System.Data.ConstraintException ex)
                {
                    MessageBox.Show(ex.Message);
                    txtName.Focus();
                }
                finally { }
            }
        }
        void prepare_edit()
        {
            ESys.VariableRow row = parent.es.Variable.FindByИмя(editname);
            parent.es.Variable.RemoveVariableRow(row);
        }

        private void btnAddDom_Click(object sender, EventArgs e)
        {
            int selection = cmbDomen.SelectedIndex;
            this.Hide();
            parent.add_domen();
            cmbDomen.Items.Clear();
            for (int i = 0; i < parent.es.Domens.Count; i++)
                cmbDomen.Items.Add(parent.es.Domens[i][0]);
            cmbDomen.SelectedIndex = selection;
            this.Show();
            this.btnSave.Text = "Применить";
            cmbDomen.SelectedIndex = parent.es.Domens.Rows.Count - 1;
        }

        private void frmAddVar_Load(object sender, EventArgs e)
        {

        }

        private void frmAddVar_Shown(object sender, EventArgs e)
        {
            if (cmbDomen.Items.Count==0)
            {
                MessageBox.Show("Домены не добавлены\nНельзя добавить переменную", "Ошибка");
                this.Close();
            }
            else if(editrow<0)
            { cmbDomen.SelectedIndex = 0; cmbType.SelectedIndex = 0; }
        }
        
    }
}
