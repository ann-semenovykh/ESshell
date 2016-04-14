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
    public partial class frmAddGoal : Form
    {
        private frmMain parent;
        public frmAddGoal(frmMain par)
        {
            InitializeComponent();
            parent = par;
            bindGoal.DataSource = parent.es.Variable.Where(e => e.Тип == "Выводимая");
            cmbGoal.DataSource = bindGoal;
            cmbGoal.DisplayMember = "Имя";
            cmbGoal.ValueMember = "Имя";
            if (parent.goal != null)
                cmbGoal.SelectedIndex = cmbGoal.FindString(parent.goal);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            parent.goal = cmbGoal.SelectedValue.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmAddGoal_Shown(object sender, EventArgs e)
        {
            if (cmbGoal.Items.Count == 0)
            {
                MessageBox.Show("Доступных переменных не найдено", "Ошибка");
                this.Close();
            }
        }
    }
}
