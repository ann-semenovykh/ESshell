using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ESshell
{
    public partial class frmMain : Form
    {
        ESys es = new ESys();
        public ESys.DomensDataTable domen = new ESys.DomensDataTable();
        public ESys.DomenValDataTable domenval = new ESys.DomenValDataTable();
        public frmMain()
        {
            InitializeComponent();
            bindDomen.DataSource = domen;
            dataDomen.DataSource = bindDomen;
            dataDomen.Columns[0].HeaderText = "Имя домена";
            dataDomen.Columns[1].HeaderText = "Значения домена";
            dataDomen.Columns[0].Width = 150;
            dataDomen.Columns[1].Width = 300;
            

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void цельКонсультацииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void переменныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataDomen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDomenAdd_Click(object sender, EventArgs e)
        {
            add_domen();
        }
        private void add_domen()
        {
            frmAddDomen frm = new frmAddDomen(this);
            frm.ShowDialog(this); 
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            add_domen();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bindDomen_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnDomenEdit_Click(object sender, EventArgs e)
        {
            if (dataDomen.SelectedCells == null)
                MessageBox.Show("Выберите домен для изменения");
            else { }
        }

        private void btnDomenDel_Click(object sender, EventArgs e)
        {
            if (dataDomen.SelectedCells == null)
                MessageBox.Show("Выберите домен для изменения");
            else { dataDomen.Rows.Remove(dataDomen.SelectedRows[0]); }
        }
    }
}
