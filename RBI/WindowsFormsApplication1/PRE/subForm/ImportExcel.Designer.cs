namespace RBI.PRE.subForm
{
    partial class ImportExcel
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPathFileExcel = new System.Windows.Forms.TextBox();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(284, 464);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPathFileExcel
            // 
            this.txtPathFileExcel.Location = new System.Drawing.Point(12, 465);
            this.txtPathFileExcel.Name = "txtPathFileExcel";
            this.txtPathFileExcel.Size = new System.Drawing.Size(266, 20);
            this.txtPathFileExcel.TabIndex = 1;
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(821, 465);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnImportExcel.TabIndex = 2;
            this.btnImportExcel.Text = "Import";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(902, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(989, 459);
            this.panelControl1.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(645, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(726, 465);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 8;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            // 
            // ImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 495);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.txtPathFileExcel);
            this.Controls.Add(this.btnBrowse);
            this.Name = "ImportExcel";
            this.Text = "Import Excel";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPathFileExcel;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveAs;
    }
}