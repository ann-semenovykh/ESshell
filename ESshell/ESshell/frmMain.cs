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
using System.Xml.Serialization;
using System.IO;

namespace ESshell
{
    public partial class frmMain : Form
    {
        public ESys es = new ESys();
        
        public frmMain()
        {
            InitializeComponent();
            bindDomen.DataSource = es.Domens;
            dataDomen.DataSource = bindDomen;
            dataDomen.Columns[0].HeaderText = "Имя домена";
            dataDomen.Columns[1].HeaderText = "Значения домена";
            dataDomen.Columns[0].Width = 180;
            dataDomen.Columns[1].Width = 666;

            
            bindDomenVal.DataSource = es.DomenVal;
            dataDomenVal.DataSource = bindDomenVal;
            dataDomenVal.Columns[0].Visible = false;
            dataDomenVal.Columns[1].Width = 170;

            bindVars.DataSource = es.Variable;
            dataVars.DataSource = bindVars;
            dataVars.Columns[0].Width = 100;
            dataVars.Columns[1].Width = 120;
            dataVars.Columns[2].Width = 120;
            dataVars.Columns[3].Width = 500;
            btnSave.Visible = false;

            bindRules.DataSource = es.Rules;
            dataRules.DataSource = bindRules;
            dataRules.Columns[0].Width = 100;
            dataRules.Columns[1].Width = 300;
            dataRules.Columns[2].Width = 400;
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
        
        public void add_domen()
        {
            frmAddDomen frm = new frmAddDomen(this,null,-1);
            frm.ShowDialog(this); 
        }
        private void edit_domen()
        {
            ESys.DomensRow dr = es.Domens.Where(e=>e.Имя_домена==dataDomen.SelectedRows[0].Cells[0].Value.ToString()).First();
            frmAddDomen frm = new frmAddDomen(this, dr,dataDomen.SelectedRows[0].Index);
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
            else {
                edit_domen();
            }
        }

        private void btnDomenDel_Click(object sender, EventArgs e)
        {
            if (dataDomen.SelectedCells == null)
                MessageBox.Show("Выберите домен для изменения");
            else { dataDomen.Rows.Remove(dataDomen.SelectedRows[0]); }
        }


        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void dataDomen_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = dataDomen.DoDragDrop(
                             dataDomen.Rows[rowIndexFromMouseDown],
                             DragDropEffects.Move);
                }
            }
        }

        private void dataDomen_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataDomen.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataDomen_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataDomen_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be
    // converted to client coordinates.
    Point clientPoint = dataDomen.PointToClient(new Point(e.X, e.Y));
 
    // Get the row index of the item the mouse is below.
    rowIndexOfItemUnderMouseToDrop =
        dataDomen.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
 
    // If the drag operation was a move then remove and insert the row.
    if (e.Effect == DragDropEffects.Move)
    {
        DataGridViewRow row = e.Data.GetData(
                     typeof(DataGridViewRow)) as DataGridViewRow;
        ESys.DomensRow rowToMove = es.Domens.NewDomensRow();
        rowToMove.ItemArray= es.Domens[row.Index].ItemArray;
        
        if (row.Index < 0)
        {
            return;
        }
        if (rowIndexFromMouseDown < rowIndexOfItemUnderMouseToDrop)
        {

            es.Domens.Rows.RemoveAt(rowIndexFromMouseDown);
            es.Domens.Rows.InsertAt(rowToMove, rowIndexOfItemUnderMouseToDrop-1);
            dataDomen.Update();
        }
        else if (rowIndexFromMouseDown > rowIndexOfItemUnderMouseToDrop)
        {

            es.Domens.Rows.RemoveAt(rowIndexFromMouseDown);
            es.Domens.Rows.InsertAt(rowToMove, rowIndexOfItemUnderMouseToDrop);
            dataDomen.Update();
        }

    }
        }

        private void dataDomen_SelectionChanged(object sender, EventArgs e)
        {
            bindDomenVal.Filter = "Имя_домена='" + dataDomen.SelectedRows[0].Cells[0].Value.ToString()+"'";
            btnSave.Visible = false;
        }

        private void dataDomenVal_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = dataDomenVal.DoDragDrop(
                             dataDomenVal.Rows[rowIndexFromMouseDown],
                             DragDropEffects.Move);
                }
            }
        }

        private void dataDomenVal_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataDomenVal.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataDomenVal_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataDomenVal_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be
            // converted to client coordinates.
            Point clientPoint = dataDomenVal.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below.
            rowIndexOfItemUnderMouseToDrop =
                dataDomenVal.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow row = e.Data.GetData(
                             typeof(DataGridViewRow)) as DataGridViewRow;
                ESys.DomenValRow rowToMove = es.DomenVal.NewDomenValRow();
                rowToMove.ItemArray = es.DomenVal[row.Index].ItemArray;

                if (row.Index < 0)
                {
                    return;
                }
                if (rowIndexFromMouseDown < rowIndexOfItemUnderMouseToDrop)
                {

                    es.DomenVal.Rows.RemoveAt(rowIndexFromMouseDown);
                    es.DomenVal.Rows.InsertAt(rowToMove, rowIndexOfItemUnderMouseToDrop - 1);
                    dataDomenVal.Update();
                    btnSave.Visible = true;
                }
                else if (rowIndexFromMouseDown > rowIndexOfItemUnderMouseToDrop)
                {

                    es.DomenVal.Rows.RemoveAt(rowIndexFromMouseDown);
                    es.DomenVal.Rows.InsertAt(rowToMove, rowIndexOfItemUnderMouseToDrop);
                    dataDomenVal.Update();
                    btnSave.Visible = true;
                }

            }
        }
        private void add_var()
        {
            frmAddVar frm = new frmAddVar(this, null, -1);
            frm.ShowDialog(this);
        }
        private void edit_var()
        {
            ESys.VariableRow dr = es.Variable.FindByИмя(dataVars.SelectedRows[0].Cells[0].Value.ToString());
            frmAddVar frm = new frmAddVar(this, dr, dataVars.SelectedRows[0].Index);
            frm.ShowDialog(this);
        }

        private void btnVarAdd_Click(object sender, EventArgs e)
        {
            add_var();
        }

        private void btnVarEdit_Click(object sender, EventArgs e)
        {
            if (dataVars.SelectedCells == null)
                MessageBox.Show("Выберите переменную для изменения");
            else edit_var();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "xml files (*.xml) | .xml| All files (*.*)|*.*";
            fd.RestoreDirectory = true;
            fd.FilterIndex = 1;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                es.WriteXml(fd.FileName);
                filename = fd.FileName;
            }
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "xml files (*.xml) | *.xml| All files (*.*)|*.*";
            of.RestoreDirectory = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                es.ReadXml(of.FileName,XmlReadMode.IgnoreSchema);
                filename = of.FileName;
            }
        }
        private string filename;
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename == null)
                es.WriteXml(filename);
        }
        
        private void btnVarDel_Click(object sender, EventArgs e)
        {
            if (dataVars.SelectedRows == null)
                MessageBox.Show("Выберите переменную для удаления");
            else es.Variable.RemoveVariableRow(es.Variable.FindByИмя(dataVars.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void btnRuleAdd_Click(object sender, EventArgs e)
        {
            add_rule();
        }
        void add_rule()
        {
            frmAddRule frm = new frmAddRule(this,null,-1);
            frm.Show();
        }
        void edit_rule()
        { }
        private void btnRuleEdit_Click(object sender, EventArgs e)
        {
            if (dataRules.SelectedRows != null)
                edit_rule();
            else MessageBox.Show("Выберите правило для изменения");
        }

        private void dataRules_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnRuleDel_Click(object sender, EventArgs e)
        {
            if (dataRules.SelectedRows == null)
                MessageBox.Show("Выберите правило для удаления");
            else es.Rules.RemoveRulesRow(es.Rules.FindByИмя(dataRules.SelectedRows[0].Cells[0].Value.ToString()));
        }


    }
}
