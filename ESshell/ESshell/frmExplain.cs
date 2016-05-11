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
    public partial class frmExplain : Form
    {
        private ESys es;
        public frmExplain(TreeNode tv,frmMain par)
        {
            InitializeComponent();
            treeRules.Nodes.Clear();
            treeRules.Nodes.Add(tv);
            es = par.es;
            DataRow[] rows =
                (from works in es.WorkMemory
                 join facts in es.Fact
                 on works.fact equals facts.id
                 select facts).ToArray();
            foreach (ESys.FactRow fact in rows)
                dataVarVal.Rows.Add(fact.Переменная, fact.Значение_переменной);
            
            
        }

        private void frmExplain_Load(object sender, EventArgs e)
        {

        }

        private void treeRules_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //dataVarVal.Rows.Clear();
                //DataRow[] rows =
                //    (from facts in es.Fact
                //     join works in es.WorkMemory
                //     on facts.id equals works.fact
                //     where works.rule == e.Node.Tag.ToString()
                //     select facts).ToArray();
                //foreach (ESys.FactRow fact in rows)
                //    dataVarVal.Rows.Add(fact.Переменная, fact.Значение_переменной);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Expand")
            {
                treeRules.ExpandAll();
                button1.Text = "Collapse";
            }
            else
            {
                treeRules.CollapseAll();
                button1.Text = "Expand";
            }
        }
    }
}
