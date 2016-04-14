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
        public string goal;
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
            frmAddGoal frm = new frmAddGoal(this);
            frm.ShowDialog();
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
        
        private bool check_dom_in_rule(string name)
        {
            ESys.VariableRow[] vars = es.Variable.Where(e => e.Домен == name).ToArray();
            bool tmp=true;
            foreach (ESys.VariableRow var in vars)
            {
                tmp = tmp && check_var_in_rule(var.Имя);
                if (!tmp)
                    return false;
            }
            return tmp;
        }
        private bool check_var_in_rule(string name)
        {
            ESys.LSideRow[] rows =(
                from lside in es.LSide
                join fact in es.Fact
                on lside.Fact equals fact.id
                where fact.Переменная==name
                select lside).ToArray();
            if (rows.Count() > 0)
                return false;
            else
            {
                ESys.RSideRow[] row = (
                from rside in es.RSide
                join fact in es.Fact
                on rside.Fact equals fact.id
                where fact.Переменная == name
                select rside).ToArray();
                return (row.Count() > 0 ? false : true);
            }
        }
        private void edit_domen()
        {
            if (dataDomen.SelectedCells == null)
                MessageBox.Show("Выберите домен для изменения");
            else
                if (check_dom_in_rule(dataDomen.SelectedRows[0].Cells[0].Value.ToString()))
                {

                    ESys.DomensRow dr = es.Domens.Where(e => e.Имя_домена == dataDomen.SelectedRows[0].Cells[0].Value.ToString()).First();
                    frmAddDomen frm = new frmAddDomen(this, dr, dataDomen.SelectedRows[0].Index);
                    frm.ShowDialog(this);
                    
                }
                else MessageBox.Show("Значения домена уже используются в правилах","Изменение запрещено");
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
            edit_domen();
        }
        void delete_domen()
        {
            if (dataDomen.SelectedCells == null)
                MessageBox.Show("Выберите домен для изменения");
            else
                if (check_dom_in_rule(dataDomen.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    if (es.Variable.Where(ex => ex.Домен == dataDomen.SelectedRows[0].Cells[0].Value.ToString()).Count()>0)
                    {
                        DialogResult dialog = MessageBox.Show("Домен уже используется в переменной\nВсе переменные будут удалена вместе с доменом\nПродолжить?", "Внимание", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                            dataDomen.Rows.Remove(dataDomen.SelectedRows[0]);
                        else return;
                    }
                    else dataDomen.Rows.Remove(dataDomen.SelectedRows[0]); 
                }
                else  { MessageBox.Show("Значения домена уже используются в правиле", "Удаление запрещено"); }
        }
        private void btnDomenDel_Click(object sender, EventArgs e)
        {
            delete_domen();
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
            if (dataDomen.SelectedRows.Count > 0)
            {
                bindDomenVal.Filter = "Имя_домена='" + dataDomen.SelectedRows[0].Cells[0].Value.ToString() + "'";
                btnSave.Visible = false;
            }
        }
        private Rectangle dragBoxFromMouseDownVal;
        private int rowIndexFromMouseDownVal;
        private int rowIndexOfItemUnderMouseToDropVal;
        private void dataDomenVal_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDownVal != Rectangle.Empty &&
                    !dragBoxFromMouseDownVal.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = dataDomenVal.DoDragDrop(
                             dataDomenVal.Rows[rowIndexFromMouseDownVal],
                             DragDropEffects.Move);
                }
            }
        }
        private ESys.DomenValRow get_domenval(int indexingrid)
        {
            string val = dataDomenVal.Rows[indexingrid].Cells[1].Value.ToString(); //value of domenval
            return es.DomenVal.Where(ex => ex.Имя_домена == dataDomen.SelectedRows[0].Cells[0].Value.ToString() && ex.Значение_домена == val).First();
            ;
        }
        private void dataDomenVal_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDownVal = es.DomenVal.Rows.IndexOf(get_domenval(dataDomenVal.HitTest(e.X, e.Y).RowIndex));

            if (rowIndexFromMouseDownVal != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDownVal = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDownVal = Rectangle.Empty;
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
            rowIndexOfItemUnderMouseToDropVal = es.DomenVal.Rows.IndexOf(get_domenval(
                dataDomenVal.HitTest(clientPoint.X, clientPoint.Y).RowIndex));

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
                if (rowIndexFromMouseDownVal < rowIndexOfItemUnderMouseToDropVal)
                {

                    es.DomenVal.Rows.RemoveAt(rowIndexFromMouseDownVal);
                    es.DomenVal.Rows.InsertAt(rowToMove, rowIndexOfItemUnderMouseToDropVal - 1);
                    dataDomenVal.Update();
                    btnSave.Visible = true;
                }
                else if (rowIndexFromMouseDownVal > rowIndexOfItemUnderMouseToDropVal)
                {

                    es.DomenVal.Rows.RemoveAt(rowIndexFromMouseDownVal);
                    es.DomenVal.Rows.InsertAt(rowToMove, rowIndexOfItemUnderMouseToDropVal);
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
            if (dataVars.SelectedCells == null)
                MessageBox.Show("Выберите переменную для изменения");
            else

                if (check_var_in_rule(dataVars.SelectedRows[0].Cells[0].Value.ToString()))
                {
                ESys.VariableRow dr = es.Variable.FindByИмя(dataVars.SelectedRows[0].Cells[0].Value.ToString());
                frmAddVar frm = new frmAddVar(this, dr, dataVars.SelectedRows[0].Index);
                frm.ShowDialog(this);
                }
                else { MessageBox.Show("Переменная уже используется в правиле", "Изменение запрещено"); }
        }

        private void btnVarAdd_Click(object sender, EventArgs e)
        {
            add_var();
        }

        private void btnVarEdit_Click(object sender, EventArgs e)
        {
            edit_var();
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
                try
                {
                    es.ReadXml(of.FileName, XmlReadMode.IgnoreSchema);
                    filename = of.FileName;
                }
                catch (Exception ex)
                { MessageBox.Show("При открытии файла произошла ошибка"); }
            }
        }
        private string filename="";
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                es.WriteXml(filename);
            else сохранитьКакToolStripMenuItem_Click(sender, e);
        }
        void del_var()
        {
            if (dataVars.SelectedRows == null)
                MessageBox.Show("Выберите переменную для удаления");
            else
                if (check_var_in_rule(dataVars.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    es.Variable.RemoveVariableRow(es.Variable.FindByИмя(dataVars.SelectedRows[0].Cells[0].Value.ToString()));
                }
                else MessageBox.Show("Переменная уже используется в правиле","Удаление запрещено");
        }
        private void btnVarDel_Click(object sender, EventArgs e)
        {
            del_var();
        }

        private void btnRuleAdd_Click(object sender, EventArgs e)
        {
            add_rule();
        }
        void add_rule()
        {
            frmAddRule frm = new frmAddRule(this,null,-1);
            frm.ShowDialog();
        }
        void edit_rule()
        {
            if (dataRules.SelectedRows != null)
            {
                frmAddRule frm = new frmAddRule(this, es.Rules.FindByИмя(dataRules.SelectedRows[0].Cells[0].Value.ToString()), dataRules.SelectedRows[0].Index);
                frm.ShowDialog();
            }
            else MessageBox.Show("Выберите правило для изменения");
            
        }
        private void btnRuleEdit_Click(object sender, EventArgs e)
        {
            edit_rule();
        }

        private void dataRules_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        void del_rule()
        {
            if (dataRules.SelectedRows == null)
                MessageBox.Show("Выберите правило для удаления");
            else
            {
                frmAddRule.prepare_edit(es, dataRules.SelectedRows[0].Cells[0].Value.ToString());
                es.Rules.RemoveRulesRow(es.Rules.FindByИмя(dataRules.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }
        private void btnRuleDel_Click(object sender, EventArgs e)
        {
            del_rule();
        }

        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            edit_domen();
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            delete_domen();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void добавитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            add_var();
        }

        private void изменитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            edit_var();
        }

        private void удалитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            del_var();
        }
       
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_rule();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_rule();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            del_rule();
        }

        private void начатьКонсультациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (goal == null)
            {
                frmAddGoal frmg=new frmAddGoal(this);
                DialogResult dialog = frmg.ShowDialog();
                if (dialog != DialogResult.OK)
                    return;

            }
            frmConsult frm = new frmConsult(es, goal);
            
             frm.ShowDialog();
            
        }

        private Rectangle dragBoxFromMouseDownRule;
        private int rowIndexFromMouseDownRule;
        private int rowIndexOfItemUnderMouseToDropRule;
        private void dataRules_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDownRule != Rectangle.Empty &&
                    !dragBoxFromMouseDownRule.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = dataRules.DoDragDrop(
                             dataRules.Rows[rowIndexFromMouseDownRule],
                             DragDropEffects.Move);
                }
            }
        }

        private void dataRules_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDownRule = dataRules.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDownRule != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDownRule = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDownRule = Rectangle.Empty;
        }

        private void dataRules_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataRules_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be
            // converted to client coordinates.
            Point clientPoint = dataRules.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below.
            rowIndexOfItemUnderMouseToDropRule =
                dataRules.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow row = e.Data.GetData(
                             typeof(DataGridViewRow)) as DataGridViewRow;
                ESys.RulesRow rowToMove = es.Rules.NewRulesRow();
                rowToMove.ItemArray = es.Rules[row.Index].ItemArray;

                if (row.Index < 0)
                {
                    return;
                }
                if (rowIndexFromMouseDownRule < rowIndexOfItemUnderMouseToDropRule)
                {
                    
                    es.Rules.Rows.RemoveAt(rowIndexFromMouseDownRule);
                    es.Rules.Rows.InsertAt(rowToMove, rowIndexOfItemUnderMouseToDropRule - 1);
                    dataRules.Update();
                }
                else if (rowIndexFromMouseDownRule > rowIndexOfItemUnderMouseToDropRule)
                {
                    es.Rules.Rows.RemoveAt(rowIndexFromMouseDownRule);
                    es.Rules.Rows.InsertAt(rowToMove, rowIndexOfItemUnderMouseToDropRule);
                    dataRules.Update();
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmAddDomen.add_value(this, dataDomen.SelectedRows[0].Cells[0].Value.ToString());
            btnSave.Visible = false;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Сохранить изменения в экпертной системе?", "Внимание", MessageBoxButtons.YesNoCancel);
            if (dialog == DialogResult.Yes)
                сохранитьToolStripMenuItem_Click(sender,e);
            if (dialog != DialogResult.Cancel)
            {
                es.Clear();
                filename = "";
            }
        }


    }
}
