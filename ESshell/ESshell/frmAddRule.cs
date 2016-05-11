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
    public partial class frmAddRule : Form
    {
        private frmMain parent;
        private int editrow;
        private string editname;
        public frmAddRule(frmMain par, ESys.RulesRow row, int index)
        {
            InitializeComponent();
            //variableBindingSource.DataSource = par.es.Variable;
            //clmName.DataSource = variableBindingSource;
            //clmName.DisplayMember = "Имя";
            parent = par;
            editrow = index;
            if (editrow >= 0)
                prepare_edit(row);
        }
        void prepare_edit(ESys.RulesRow row)
        {
            editname = row.Имя;
            txtName.Text = row.Имя;
            IEnumerable<ESys.FactRow> facts =
                from fact in parent.es.Fact
                join lside in parent.es.LSide
                on fact.id equals lside.Fact
                where lside.Имя==editname
                select fact;
            foreach (ESys.FactRow f in facts)
                dataLSide.Rows.Add(f.Переменная, f.Значение_переменной);

            facts =
                from fact in parent.es.Fact
                join rside in parent.es.RSide
                on fact.id equals rside.Fact
                where rside.Имя==editname
                select fact;
            foreach (ESys.FactRow f in facts)
                dataRSide.Rows.Add(f.Переменная, f.Значение_переменной);
        }
        
        public static void prepare_edit(ESys es, string editname)
        {
            ESys.LSideRow[] rows = es.LSide.Where(e => e.Имя == editname).ToArray();
            foreach (ESys.LSideRow row in rows)
                es.LSide.RemoveLSideRow(row);
            ESys.RSideRow[] rowss = es.RSide.Where(e => e.Имя == editname).ToArray();
            foreach (ESys.RSideRow row in rowss)
               es.RSide.RemoveRSideRow(row);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Replace(" ","") == "")
            { MessageBox.Show("Введите имя правила"); txtName.Focus(); }
            else
            if (dataRSide.RowCount == 0 || dataLSide.RowCount == 0)
                MessageBox.Show("Введите факты");
            else
            {
                try
                {
                    ESys.RulesRow rule;
                    if (editrow < 0)
                        if (parent.es.Rules.Where(ex => ex.Имя.ToUpper().Replace(" ", "") == txtName.Text.Replace(" ", "").ToUpper()).Count() == 0)
                        {
                            rule = parent.es.Rules.NewRulesRow();
                            rule.Имя = txtName.Text.Trim();
                            parent.es.Rules.Rows.InsertAt(rule,parent.dataRules.SelectedRows[0].Index+1);
                            int index = parent.dataRules.SelectedRows[0].Index;
                            parent.dataRules.Rows[index + 1].Selected = true;
                            parent.dataRules.Rows[index].Selected = false;
                            parent.dataRules.FirstDisplayedScrollingRowIndex = parent.dataRules.SelectedRows[0].Index;
                        }
                        else throw new System.Data.ConstraintException("Правило с таким именем уже существует");
                    else
                    {
                        rule = parent.es.Rules[editrow];
                        rule.Имя = txtName.Text.Trim();
                        prepare_edit(parent.es, editname);
                    }
                    add_to_set(dataLSide, true);
                    add_to_set(dataRSide, false);
                    string left = String.Join(" AND ",
                        from lefts in parent.es.LSide
                        join vals in parent.es.Fact
                        on lefts.Fact equals vals.id
                        where lefts.Имя == txtName.Text
                        select vals.Переменная + " = " + vals.Значение_переменной
                        );
                    string right = String.Join(" AND ",
                        from lefts in parent.es.RSide
                        join vals in parent.es.Fact
                        on lefts.Fact equals vals.id
                        where lefts.Имя == txtName.Text
                        select vals.Переменная + " = " + vals.Значение_переменной
                        );
                    rule.Заключение = " THEN " + right;
                    rule.Посылка = left;
                    if (editrow >= 0)
                        this.Close();
                    //else parent.dataRules.Rows[parent.dataRules.Rows.Count - 1].Selected = true;
                    this.Close();
                    dataLSide.Rows.Clear();
                    dataRSide.Rows.Clear();
                    txtName.Text = "";
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally { txtName.Focus(); }
            }
        }
        
        private void add_to_set(DataGridView data,bool left)
        {
            foreach(DataGridViewRow row in data.Rows)
            {
                ESys.FactRow fact ;
                try
                {
                    fact = parent.es.Fact.Where(e => e.Значение_переменной == row.Cells[1].Value.ToString() && e.Переменная == row.Cells[0].Value.ToString()).First();
                }
                catch (Exception ex)
                {
                    fact = parent.es.Fact.AddFactRow(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }
                if (left)
                   parent.es.LSide.AddLSideRow(txtName.Text, fact.id);
                else
                    parent.es.RSide.AddRSideRow(txtName.Text, fact.id);
            }
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string selected;
        private void dataLSide_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dataLSide.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
            //{
            //    ComboBox comboBox = e.Control as ComboBox;

            //    comboBox.SelectedValueChanged -= new EventHandler(LastColumnComboSelectionChanged);
            //    comboBox.SelectedValueChanged += new EventHandler(LastColumnComboSelectionChanged);
            //}
        }
        private void LastColumnComboSelectionChanged(object sender,EventArgs e)
        {
            //var currentcell = dataLSide.CurrentCellAddress;
            //var sendingCB = sender as DataGridViewComboBoxEditingControl;
            //DataGridViewComboBoxCell cel = (DataGridViewComboBoxCell)dataLSide.Rows[currentcell.Y].Cells[1];
            
            //    selected = sendingCB.EditingControlFormattedValue.ToString();
            //   // IEnumerable<string> tmp =
            //   //     from domenval in parent.es.DomenVal
            //   //     join variable in parent.es.Variable
            //   //     on domenval.Field<string>("Имя_домена") equals variable.Field<string>("Домен")
            //   //     where variable.Field<string>("Имя") == selected
            //   //     select domenval.Field<string>("Значение_домена");
            //   //// cel.Items.Clear();
            //   // foreach (string row in tmp)
            //   //     cel.Items.Add(row);
            //    ESys.VariableRow tmp = parent.es.Variable.FindByИмя(selected);
            //    if (tmp != null)
            //        {
            //            DataView dv = new DataView();
            //            dv = parent.es.DomenVal.Where(ex => ex.Имя_домена == tmp.Домен).AsDataView();
            //            cel.DataSource = dv;
            //            cel.DisplayMember = "Значение_домена";
                            
            //        }
            //    ComboBox cb = (ComboBox)sender;
            //    //cb.SelectedIndexChanged -= LastColumnComboSelectionChanged;
        }

        private void dataLSide_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
        void add_fact(DataGridView data)
        {
            frmAddFact frm = new frmAddFact(parent, data,-1);
           // this.Hide();
            frm.ShowDialog();
           // this.Show();
        }
        private void btnLAdd_Click(object sender, EventArgs e)
        {
            add_fact(dataLSide);
        }

        private void frmAddRule_Load(object sender, EventArgs e)
        {

        }

        private void btnRAdd_Click(object sender, EventArgs e)
        {
            add_fact(dataRSide);
        }

        private void btnLChange_Click(object sender, EventArgs e)
        {
                edit_fact(dataLSide);
        }
        void edit_fact(DataGridView data)
        {

            if (data.SelectedRows.Count > 0)
            {
                frmAddFact frm = new frmAddFact(parent, data, data.SelectedRows[0].Index);
               // this.Hide();
                frm.ShowDialog();
               // this.Show();
            }
            else MessageBox.Show("Выберите строки для изменения");
        }
        void delete_fact(DataGridView data)
        {
            if (data.CurrentCell.RowIndex >= 0)
                data.Rows.RemoveAt(data.SelectedRows[0].Index);
            else MessageBox.Show("Выберите строки для удаления");
        }

        private void dataLSide_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnLDel_Click(object sender, EventArgs e)
        {
            delete_fact(dataLSide);

        }

        private void btnRDel_Click(object sender, EventArgs e)
        {
            delete_fact(dataRSide);
        }

        private void btnRChange_Click(object sender, EventArgs e)
        {
            edit_fact(dataRSide);
        }
    }
}
