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
            string s="";
            for (int i = 0; i < dataVDom.RowCount; i++)
            {
                if (dataVDom.Rows[i].Cells[0].Value!=null)
                    s += dataVDom.Rows[i].Cells[0].Value.ToString();
                s += ";";
            }
            s.Remove(s.Length - 1, 1);
            parent.dataDomen.Rows.Add(txtName.Text, s);
        }
    }
}
