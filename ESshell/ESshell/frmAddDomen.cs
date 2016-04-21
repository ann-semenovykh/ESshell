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
            btnSave.Text = "Применить";
            txtName.Text = row.Имя_домена;
            DataRow[] rows =
                (from dom in par.es.Domens
                join vals in par.es.DomenVal
                on dom.Имя_домена equals vals.Имя_домена
                where dom.Имя_домена==txtName.Text
                select vals).ToArray();
            foreach(DataRow r in rows)
            {
                dataVDom.Rows.Add(r[1]);
            }
            editname = txtName.Text;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Replace(" ","") == "")
                MessageBox.Show("Заполните имя домена");
            else
                if (empty_domen())
            try
            {
                if (editrow < 0)
                    if (parent.es.Domens.Where(ex => ex.Имя_домена.Replace(" ", "").ToUpper() == txtName.Text.Replace(" ", "").ToUpper()).Count() == 0)
                        parent.es.Domens.AddDomensRow(txtName.Text.Trim(), "");
                    else throw new System.Data.ConstraintException("Домен с таким именем уже существует");
                else prepare_edit();
            for (int i = 0; i < dataVDom.RowCount; i++)
            {
                if (dataVDom.Rows[i].Cells[0].Value != null && not_in(txtName.Text, dataVDom.Rows[i].Cells[0].Value.ToString()))
                    parent.es.DomenVal.AddDomenValRow(txtName.Text.Trim(), dataVDom.Rows[i].Cells[0].Value.ToString().Trim());
            }
            add_value(parent,txtName.Text);
            if (editrow < 0)
            {
                dataVDom.Rows.Clear();
                txtName.Clear();
                txtName.Focus();
                parent.dataDomen.FirstDisplayedScrollingRowIndex = parent.dataDomen.Rows.Count - 1;
                parent.dataDomen.Rows[parent.dataDomen.Rows.Count-1].Selected = true;
                this.Close();
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
            return parent.es.DomenVal.Where(e => e.Имя_домена == domen.Trim() && e.Значение_домена.Replace(" ","").ToUpper() == val.ToUpper().Replace(" ","")).Count() == 0;
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

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void dataVDom_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse movparent.es outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = dataVDom.DoDragDrop(
                             dataVDom.Rows[rowIndexFromMouseDown],
                             DragDropEffects.Move);
                }
            }
        }

        private void dataVDom_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataVDom.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicatparent.es the size that the mouse can move 
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
                // Rparent.eset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataVDom_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataVDom_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be
            // converted to client coordinatparent.es.
            Point clientPoint = dataVDom.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below.
            rowIndexOfItemUnderMouseToDrop =
                dataVDom.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                             typeof(DataGridViewRow)) as DataGridViewRow;

                if (rowToMove.Index < 0)
                {
                    return;
                }
                if (rowIndexOfItemUnderMouseToDrop < 0)
                    return;
                if (rowIndexFromMouseDown < rowIndexOfItemUnderMouseToDrop)
                {

                    dataVDom.Rows.RemoveAt(rowIndexFromMouseDown);
                    dataVDom.Rows.Insert(rowIndexOfItemUnderMouseToDrop - 1, rowToMove);
                    dataVDom.Update();
                }
                else if (rowIndexFromMouseDown > rowIndexOfItemUnderMouseToDrop)
                {

                    dataVDom.Rows.RemoveAt(rowIndexFromMouseDown);
                    dataVDom.Rows.Insert(rowIndexOfItemUnderMouseToDrop , rowToMove);
                    dataVDom.Update();
                }

            }
        }
    }
}
