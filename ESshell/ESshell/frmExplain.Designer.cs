namespace ESshell
{
    partial class frmExplain
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRules = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeRules = new System.Windows.Forms.TreeView();
            this.dataVarVal = new System.Windows.Forms.DataGridView();
            this.bindVarVal = new System.Windows.Forms.BindingSource(this.components);
            this.Var = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Val = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataVarVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindVarVal)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpRules);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 403);
            this.tabControl1.TabIndex = 0;
            // 
            // tpRules
            // 
            this.tpRules.Controls.Add(this.splitContainer1);
            this.tpRules.Location = new System.Drawing.Point(4, 22);
            this.tpRules.Name = "tpRules";
            this.tpRules.Padding = new System.Windows.Forms.Padding(3);
            this.tpRules.Size = new System.Drawing.Size(525, 377);
            this.tpRules.TabIndex = 0;
            this.tpRules.Text = "Сработавшие правила";
            this.tpRules.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(219, 409);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeRules);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataVarVal);
            this.splitContainer1.Size = new System.Drawing.Size(519, 371);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeRules
            // 
            this.treeRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRules.Location = new System.Drawing.Point(0, 0);
            this.treeRules.Name = "treeRules";
            this.treeRules.Size = new System.Drawing.Size(315, 371);
            this.treeRules.TabIndex = 1;
            this.treeRules.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeRules_NodeMouseClick);
            // 
            // dataVarVal
            // 
            this.dataVarVal.AllowUserToAddRows = false;
            this.dataVarVal.AllowUserToDeleteRows = false;
            this.dataVarVal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataVarVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVarVal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Var,
            this.Val});
            this.dataVarVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataVarVal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataVarVal.Location = new System.Drawing.Point(0, 0);
            this.dataVarVal.MultiSelect = false;
            this.dataVarVal.Name = "dataVarVal";
            this.dataVarVal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataVarVal.Size = new System.Drawing.Size(200, 371);
            this.dataVarVal.TabIndex = 0;
            // 
            // Var
            // 
            this.Var.HeaderText = "Переменная";
            this.Var.Name = "Var";
            this.Var.ReadOnly = true;
            this.Var.Width = 96;
            // 
            // Val
            // 
            this.Val.HeaderText = "Значение переменной";
            this.Val.Name = "Val";
            this.Val.ReadOnly = true;
            this.Val.Width = 132;
            // 
            // frmExplain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 444);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.MinimizeBox = false;
            this.Name = "frmExplain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Компонента объяснения";
            this.Load += new System.EventHandler(this.frmExplain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpRules.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataVarVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindVarVal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRules;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TreeView treeRules;
        private System.Windows.Forms.BindingSource bindVarVal;
        public System.Windows.Forms.DataGridView dataVarVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Var;
        private System.Windows.Forms.DataGridViewTextBoxColumn Val;
    }
}