﻿namespace ESshell
{
    partial class frmAddDomen
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
            this.dataVDom = new System.Windows.Forms.DataGridView();
            this.DValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataVDom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя домена";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(95, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(167, 20);
            this.txtName.TabIndex = 1;
            // 
            // dataVDom
            // 
            this.dataVDom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVDom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DValue});
            this.dataVDom.Location = new System.Drawing.Point(22, 61);
            this.dataVDom.Name = "dataVDom";
            this.dataVDom.Size = new System.Drawing.Size(240, 150);
            this.dataVDom.TabIndex = 2;
            // 
            // DValue
            // 
            this.DValue.HeaderText = "Значение";
            this.DValue.Name = "DValue";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Добавить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(152, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 33);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddDomen
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataVDom);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddDomen";
            this.Text = "Добавить домен";
            ((System.ComponentModel.ISupportInitialize)(this.dataVDom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dataVDom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}