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
    public partial class frmAddDomen : Form
    {
        private frmMain parent;
        private int editrow;
        private string editname;
        public frmAddDomen(frmMain par,ESys.DomensRow row,int index)
        {
            InitializeComponent();
            parent=par;
            editrow = index;
            if (index>=0)
                Load_value(par,row);
        }
        public void Load_value(frmMain par,ESys.DomensRow row)
        {
            btnSave.Text = "Изменить";
            txtName.Text = row.Имя_домена;
            DataRow[] rows = parent.es.DomenVal.Select("Имя_домена =\'" + txtName.Text + "\'");
            foreach(DataRow r in rows)
            {
                dataVDom.Rows.Add(r[1]);
            }
            editname = txtName.Text;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
                MessageBox.Show("Заполните имя домена");
            else
                if (empty_domen())
            try
            {
                if (editrow < 0)
                    parent.es.Domens.AddDomensRow(txtName.Text.Trim(), "");
                else prepare_edit();
            for (int i = 0; i < dataVDom.RowCount; i++)
            {
                if (dataVDom.Rows[i].Cells[0].Value != null && not_in(txtName.Text.Trim(), dataVDom.Rows[i].Cells[0].Value.ToString().Trim()))
                    parent.es.DomenVal.AddDomenValRow(txtName.Text.Trim(), dataVDom.Rows[i].Cells[0].Value.ToString().Trim());
            }
            add_value(parent,txtName.Text);
            if (editrow < 0)
            {
                dataVDom.Rows.Clear();
                txtName.Clear();
                txtName.Focus();
            }
            else this.Close();
            }
            catch (System.Data.ConstraintException ex)
            { 
                MessageBox.Show(ex.Message);
                txtName.Focus();  
            }
            finally { }
        }
        private bool not_in(string domen,string val)
        {
            return parent.es.DomenVal.Where(e => e.Имя_домена == domen && e.Значение_домена == val).Count() == 0;
        }
        public static void add_value(frmMain parent,string name)
        {
            string vals =String.Join("; ", from domens in parent.es.DomenVal.AsEnumerable() 
                       where domens.Field<string>("Имя_домена")==name.Trim() 
                       select domens.Field<string>("Значение_домена"));
            
            parent.es.Domens.Select("Имя_домена =\'" + name.Trim() + "\'")[0]["Значения_домена"] = vals;
            

        }
        
        private bool empty_domen()
        {
            
            for (int i = 0; i < dataVDom.RowCount; i++)
            if (dataVDom.Rows[i].Cells[0].Value != null && dataVDom.Rows[i].Cells[0].Value.ToString().Trim() == "")
                {
                    dataVDom.Rows.RemoveAt(i); i--; 
                }
            
            if (1 == dataVDom.RowCount)
            {
                MessageBox.Show("Заполните значения домена");
                dataVDom.Focus();
                dataVDom.Rows.Clear();
                return false;
            }
            else return true;         
        }
        private void prepare_edit()
        {
            ESys.DomenValRow[] dr=parent.es.DomenVal.Where(e=>e.Имя_домена==editname).ToArray();
            foreach(ESys.DomenValRow row in dr)
                parent.es.DomenVal.RemoveDomenValRow(row);
            parent.es.Domens[editrow]["Имя_домена"] = txtName.Text.Trim();
        }

        private void frmAddDomen_Load(object sender, EventArgs e)
        {

        }
    }
}
