namespace RBI.PRE.subForm
{
    partial class UCrisk
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.equip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eqDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eqType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representFluid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fluidPhase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cotcatFlame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentrisk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cotcatPeoble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(855, 580);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RISK Summary";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 46);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(6, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 503);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equip,
            this.eqDes,
            this.eqType,
            this.component,
            this.representFluid,
            this.fluidPhase,
            this.cotcatFlame,
            this.currentrisk,
            this.cotcatPeoble,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(843, 503);
            this.dataGridView1.TabIndex = 0;
            // 
            // equip
            // 
            this.equip.HeaderText = "Equipment";
            this.equip.Name = "equip";
            // 
            // eqDes
            // 
            this.eqDes.HeaderText = "Equipment Description";
            this.eqDes.Name = "eqDes";
            // 
            // eqType
            // 
            this.eqType.HeaderText = "Equipment Type";
            this.eqType.Name = "eqType";
            // 
            // component
            // 
            this.component.HeaderText = "Components";
            this.component.Name = "component";
            // 
            // representFluid
            // 
            this.representFluid.HeaderText = "Represent .fluid";
            this.representFluid.Name = "representFluid";
            // 
            // fluidPhase
            // 
            this.fluidPhase.HeaderText = "Fluid Phase";
            this.fluidPhase.Name = "fluidPhase";
            // 
            // cotcatFlame
            // 
            this.cotcatFlame.HeaderText = "Cotcat.flammable";
            this.cotcatFlame.Name = "cotcatFlame";
            // 
            // currentrisk
            // 
            this.currentrisk.HeaderText = "Current Risk";
            this.currentrisk.Name = "currentrisk";
            // 
            // cotcatPeoble
            // 
            this.cotcatPeoble.HeaderText = "Cotcat.people";
            this.cotcatPeoble.Name = "cotcatPeoble";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cot.cat.asset";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cot.cat.Env";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cot.cat.Reputation";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cot.cat.Combined";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Component Material grade";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "InitThinningCategory";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "InitEnvCracking";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "InitOtherCategory";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "InitCategory";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ExtThinningCategory";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ExtEnvCracking";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "ExtOtherCategory";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "ExtCategory";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "POFCategory";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Current Risk";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Future Risk";
            this.Column16.Name = "Column16";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(765, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UCrisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCrisk";
            this.Size = new System.Drawing.Size(855, 580);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn equip;
        private System.Windows.Forms.DataGridViewTextBoxColumn eqDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn eqType;
        private System.Windows.Forms.DataGridViewTextBoxColumn component;
        private System.Windows.Forms.DataGridViewTextBoxColumn representFluid;
        private System.Windows.Forms.DataGridViewTextBoxColumn fluidPhase;
        private System.Windows.Forms.DataGridViewTextBoxColumn cotcatFlame;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentrisk;
        private System.Windows.Forms.DataGridViewTextBoxColumn cotcatPeoble;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}
