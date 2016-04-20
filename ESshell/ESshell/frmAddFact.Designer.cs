namespace ESshell
{
    partial class frmAddFact
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbVar = new System.Windows.Forms.ComboBox();
            this.cmbVal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eSys = new ESshell.ESys();
            this.variableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.domenValBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddVar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eSys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domenValBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(263, 59);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 33);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Добавить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbVar
            // 
            this.cmbVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVar.FormattingEnabled = true;
            this.cmbVar.Location = new System.Drawing.Point(55, 33);
            this.cmbVar.Name = "cmbVar";
            this.cmbVar.Size = new System.Drawing.Size(185, 21);
            this.cmbVar.TabIndex = 0;
            this.cmbVar.SelectedIndexChanged += new System.EventHandler(this.cmbVar_SelectedIndexChanged);
            // 
            // cmbVal
            // 
            this.cmbVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVal.FormattingEnabled = true;
            this.cmbVal.Location = new System.Drawing.Point(263, 33);
            this.cmbVal.Name = "cmbVal";
            this.cmbVal.Size = new System.Drawing.Size(185, 21);
            this.cmbVal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(244, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Переменная";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Значение";
            // 
            // eSys
            // 
            this.eSys.DataSetName = "ESys";
            this.eSys.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // variableBindingSource
            // 
            this.variableBindingSource.DataMember = "Variable";
            this.variableBindingSource.DataSource = this.eSys;
            // 
            // domenValBindingSource
            // 
            this.domenValBindingSource.DataMember = "DomenVal";
            this.domenValBindingSource.DataSource = this.eSys;
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(28, 32);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(21, 22);
            this.btnAddVar.TabIndex = 19;
            this.btnAddVar.Text = "+";
            this.btnAddVar.UseVisualStyleBackColor = true;
            this.btnAddVar.Click += new System.EventHandler(this.btnAddVar_Click);
            // 
            // frmAddFact
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(491, 107);
            this.Controls.Add(this.btnAddVar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVal);
            this.Controls.Add(this.cmbVar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddFact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Факт";
            this.Shown += new System.EventHandler(this.frmAddFact_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.eSys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domenValBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbVar;
        private System.Windows.Forms.ComboBox cmbVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource variableBindingSource;
        private ESys eSys;
        private System.Windows.Forms.BindingSource domenValBindingSource;
        private System.Windows.Forms.Button btnAddVar;
    }
}