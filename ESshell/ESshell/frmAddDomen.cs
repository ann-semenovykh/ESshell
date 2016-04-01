using System;
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
        public frmAddDomen(frmMain par)
        {
            InitializeComponent();
            parent=par;
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                MessageBox.Show("Заполните имя домена");
            else
                if (empty_domen())
            try
            {
                reuse_domen();
                parent.domen.AddDomensRow(txtName.Text, "");
            
            for (int i = 0; i < dataVDom.RowCount; i++)
            {
                if (dataVDom.Rows[i].Cells[0].Value != null)
                    parent.domenval.AddDomenValRow(txtName.Text, dataVDom.Rows[i].Cells[0].Value.ToString());
            }
            add_value();
            dataVDom.Rows.Clear();
            txtName.Clear();
            txtName.Focus();
            }
            catch (System.Data.ConstraintException ex)
            { 
                MessageBox.Show(ex.Message);
                txtName.Focus();  
            }
            finally { }
        }
        private void add_value()
        {
            string vals =String.Join("; ", from domens in parent.domenval.AsEnumerable() 
                       where domens.Field<string>("Имя_домена")==txtName.Text 
                       select domens.Field<string>("Значение_домена"));
            parent.domen.Select("Имя_домена =\'" + txtName.Text+"\'")[0]["Значения_домена"]=vals;
        }
        private int reuse_domen()
        {
            return 1;
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
    }
}
