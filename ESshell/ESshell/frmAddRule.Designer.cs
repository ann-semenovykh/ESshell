namespace ESshell
{
    partial class frmAddRule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dataLSide = new System.Windows.Forms.DataGridView();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eSys = new ESshell.ESys();
            this.dataRSide = new System.Windows.Forms.DataGridView();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRDel = new System.Windows.Forms.Button();
            this.btnRChange = new System.Windows.Forms.Button();
            this.btnRAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLDel = new System.Windows.Forms.Button();
            this.btnLChange = new System.Windows.Forms.Button();
            this.btnLAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataLSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRSide)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(74, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(385, 20);
            this.txtName.TabIndex = 1;
            // 
            // dataLSide
            // 
            this.dataLSide.AllowUserToAddRows = false;
            this.dataLSide.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLSide.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmVal});
            this.dataLSide.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataLSide.Location = new System.Drawing.Point(5, 17);
            this.dataLSide.MultiSelect = false;
            this.dataLSide.Name = "dataLSide";
            this.dataLSide.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataLSide.Size = new System.Drawing.Size(405, 149);
            this.dataLSide.TabIndex = 2;
            this.dataLSide.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataLSide_DataError);
            this.dataLSide.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataLSide_EditingControlShowing);
            this.dataLSide.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataLSide.SelectionChanged += new System.EventHandler(this.dataLSide_SelectionChanged);
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Имя переменной";
            this.clmName.Name = "clmName";
            this.clmName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmName.Width = 180;
            // 
            // clmVal
            // 
            this.clmVal.HeaderText = "Значение переменной";
            this.clmVal.Name = "clmVal";
            this.clmVal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmVal.Width = 180;
            // 
            // eSys
            // 
            this.eSys.DataSetName = "ESys";
            this.eSys.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataRSide
            // 
            this.dataRSide.AllowUserToAddRows = false;
            this.dataRSide.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRSide.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewComboBoxColumn2});
            this.dataRSide.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataRSide.Location = new System.Drawing.Point(5, 17);
            this.dataRSide.MultiSelect = false;
            this.dataRSide.Name = "dataRSide";
            this.dataRSide.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataRSide.Size = new System.Drawing.Size(406, 149);
            this.dataRSide.TabIndex = 4;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Имя переменной";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewComboBoxColumn1.Width = 180;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.HeaderText = "Значение переменной";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewComboBoxColumn2.Width = 180;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(263, 459);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 33);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 32);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Применить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRDel);
            this.groupBox1.Controls.Add(this.dataRSide);
            this.groupBox1.Controls.Add(this.btnRChange);
            this.groupBox1.Controls.Add(this.btnRAdd);
            this.groupBox1.Location = new System.Drawing.Point(41, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 200);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заключение";
            // 
            // btnRDel
            // 
            this.btnRDel.Location = new System.Drawing.Point(335, 172);
            this.btnRDel.Name = "btnRDel";
            this.btnRDel.Size = new System.Drawing.Size(75, 23);
            this.btnRDel.TabIndex = 8;
            this.btnRDel.Text = "Удалить";
            this.btnRDel.UseVisualStyleBackColor = true;
            this.btnRDel.Click += new System.EventHandler(this.btnRDel_Click);
            // 
            // btnRChange
            // 
            this.btnRChange.Location = new System.Drawing.Point(166, 172);
            this.btnRChange.Name = "btnRChange";
            this.btnRChange.Size = new System.Drawing.Size(75, 23);
            this.btnRChange.TabIndex = 7;
            this.btnRChange.Text = "Изменить";
            this.btnRChange.UseVisualStyleBackColor = true;
            this.btnRChange.Click += new System.EventHandler(this.btnRChange_Click);
            // 
            // btnRAdd
            // 
            this.btnRAdd.Location = new System.Drawing.Point(6, 172);
            this.btnRAdd.Name = "btnRAdd";
            this.btnRAdd.Size = new System.Drawing.Size(75, 23);
            this.btnRAdd.TabIndex = 6;
            this.btnRAdd.Text = "Добавить";
            this.btnRAdd.UseVisualStyleBackColor = true;
            this.btnRAdd.Click += new System.EventHandler(this.btnRAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLDel);
            this.groupBox2.Controls.Add(this.btnLChange);
            this.groupBox2.Controls.Add(this.btnLAdd);
            this.groupBox2.Controls.Add(this.dataLSide);
            this.groupBox2.Location = new System.Drawing.Point(41, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 200);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Посылка";
            // 
            // btnLDel
            // 
            this.btnLDel.Location = new System.Drawing.Point(335, 171);
            this.btnLDel.Name = "btnLDel";
            this.btnLDel.Size = new System.Drawing.Size(75, 23);
            this.btnLDel.TabIndex = 5;
            this.btnLDel.Text = "Удалить";
            this.btnLDel.UseVisualStyleBackColor = true;
            this.btnLDel.Click += new System.EventHandler(this.btnLDel_Click);
            // 
            // btnLChange
            // 
            this.btnLChange.Location = new System.Drawing.Point(166, 171);
            this.btnLChange.Name = "btnLChange";
            this.btnLChange.Size = new System.Drawing.Size(75, 23);
            this.btnLChange.TabIndex = 4;
            this.btnLChange.Text = "Изменить";
            this.btnLChange.UseVisualStyleBackColor = true;
            this.btnLChange.Click += new System.EventHandler(this.btnLChange_Click);
            // 
            // btnLAdd
            // 
            this.btnLAdd.Location = new System.Drawing.Point(6, 171);
            this.btnLAdd.Name = "btnLAdd";
            this.btnLAdd.Size = new System.Drawing.Size(75, 23);
            this.btnLAdd.TabIndex = 3;
            this.btnLAdd.Text = "Добавить";
            this.btnLAdd.UseVisualStyleBackColor = true;
            this.btnLAdd.Click += new System.EventHandler(this.btnLAdd_Click);
            // 
            // frmAddRule
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(504, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Правило";
            this.Load += new System.EventHandler(this.frmAddRule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRSide)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private ESys eSys;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRDel;
        private System.Windows.Forms.Button btnRChange;
        private System.Windows.Forms.Button btnRAdd;
        private System.Windows.Forms.Button btnLDel;
        private System.Windows.Forms.Button btnLChange;
        private System.Windows.Forms.Button btnLAdd;
        public System.Windows.Forms.DataGridView dataLSide;
        public System.Windows.Forms.DataGridView dataRSide;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewComboBoxColumn2;
    }
}