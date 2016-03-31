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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
            frmAddDomen frm = new frmAddDomen(this);
            frm.ShowDialog(this);
        }
    }
}
