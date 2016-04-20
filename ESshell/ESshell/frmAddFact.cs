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
    public partial class frmAddFact : Form
    {
        private frmMain parent;
        private DataGridView datagr;
        private int editrow;
        public frmAddFact(frmMain par,DataGridView data,int edit)
        {
            InitializeComponent();
            parent = par;
            variableBindingSource.DataSource = parent.es.Variable;
            cmbVar.DataSource = variableBindingSource;
            cmbVar.DisplayMember = "Имя";

            domenValBindingSource.DataSource = parent.es.DomenVal;
            cmbVal.DataSource = domenValBindingSource;
            cmbVal.DisplayMember = "Значение_домена";
            datagr = data;

            editrow = edit;
            if (edit >= 0)
            {
                cmbVar.SelectedIndex = cmbVar.FindString(datagr.Rows[edit].Cells[0].Value.ToString());
                cmbVal.SelectedIndex = cmbVal.FindString(datagr.Rows[edit].Cells[1].Value.ToString());
                btnSave.Text = "Изменить";
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRowView tmp = cmbVar.SelectedItem as DataRowView;
            DataRowView tmp2 = cmbVal.SelectedItem as DataRowView;

            if (datagr.Rows.Cast<DataGridViewRow>().Where(ex => ex.Cells[0].Value.ToString().Equals(tmp["Имя"]) && ex.Cells[1].Value.ToString().Equals(tmp2["Значение_домена"])).Count() == 0)
            {
                if (editrow >= 0)
                {
                    datagr.Rows[editrow].Cells[0].Value = tmp["Имя"];
                    datagr.Rows[editrow].Cells[1].Value = tmp2["Значение_домена"];
                }
                else
                    datagr.Rows.Add(tmp["Имя"], tmp2["Значение_домена"]);

                this.Close();
            }
            else MessageBox.Show("Такой факт в таблице уже существует");
        }

        private void cmbVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView tmp = cmbVar.SelectedItem as DataRowView;// parent.es.Variable.FindByИмя(cmbVar.Items[0].ToString());
            if (tmp != null)
            {
                cmbVal.DataSource = null;
                domenValBindingSource.Filter = "Имя_домена='" + tmp["Домен"] + "'";
                cmbVal.DisplayMember = "Значение_домена";
                cmbVal.DataSource = domenValBindingSource;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddFact_Shown(object sender, EventArgs e)
        {
            if (cmbVar.Items.Count==0)
            {
                MessageBox.Show("Переменные не добавлены\nНельзя добавить факт", "Ошибка");
                this.Close();
            }
        }

        private void btnAddVar_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.add_var();
            this.Show();
        }
    }
}
