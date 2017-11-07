namespace RBI
{
    partial class test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.imageTreeList = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(503, 392);
            this.treeList1.StateImageList = this.imageTreeList;
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.CustomDrawNodeImages += new DevExpress.XtraTreeList.CustomDrawNodeImagesEventHandler(this.treeList1_CustomDrawNodeImages);
            this.treeList1.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treeList1_PopupMenuShowing);
            // 
            // imageTreeList
            // 
            this.imageTreeList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageTreeList.ImageStream")));
            this.imageTreeList.Images.SetKeyName(0, "factory48x48.png");
            this.imageTreeList.Images.SetKeyName(1, "Factory-Yellow48x48.png");
            this.imageTreeList.Images.SetKeyName(2, "Equipment32x32.png");
            this.imageTreeList.Images.SetKeyName(3, "component32x32.png");
            this.imageTreeList.Images.SetKeyName(4, "Assessment32x32.png");
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 392);
            this.Controls.Add(this.treeList1);
            this.Name = "test";
            this.Text = "test";
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreeList)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.Utils.ImageCollection imageTreeList;


    }
}