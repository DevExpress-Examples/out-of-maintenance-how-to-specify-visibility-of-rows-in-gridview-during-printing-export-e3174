namespace ExportToXlsx
{
    partial class Form1
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.GridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cb_MasterDetail = new DevExpress.XtraEditors.CheckButton();
            this.cb_NonBlank = new DevExpress.XtraEditors.CheckButton();
            this.cb_MasterOnly = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridView2
            // 
            this.GridView2.GridControl = this.gridControl1;
            this.GridView2.Name = "GridView2";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.GridView2;
            gridLevelNode1.RelationName = "Children";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 62);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(426, 316);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.GridView2});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.PrintDetails = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButton1.Location = new System.Drawing.Point(2, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(84, 58);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Export ot xlsx";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cb_MasterDetail);
            this.panelControl1.Controls.Add(this.cb_NonBlank);
            this.panelControl1.Controls.Add(this.cb_MasterOnly);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(426, 62);
            this.panelControl1.TabIndex = 3;
            // 
            // cb_MasterDetail
            // 
            this.cb_MasterDetail.Location = new System.Drawing.Point(220, 5);
            this.cb_MasterDetail.Name = "cb_MasterDetail";
            this.cb_MasterDetail.Size = new System.Drawing.Size(142, 23);
            this.cb_MasterDetail.TabIndex = 4;
            this.cb_MasterDetail.Text = "All Master and Detail Rows";
            this.cb_MasterDetail.CheckedChanged += new System.EventHandler(this.cb_MasterDetail_CheckedChanged);
            // 
            // cb_NonBlank
            // 
            this.cb_NonBlank.Location = new System.Drawing.Point(92, 34);
            this.cb_NonBlank.Name = "cb_NonBlank";
            this.cb_NonBlank.Size = new System.Drawing.Size(122, 23);
            this.cb_NonBlank.TabIndex = 3;
            this.cb_NonBlank.Text = "Non Blank Rows Only";
            this.cb_NonBlank.CheckedChanged += new System.EventHandler(this.cb_NonBlank_CheckedChanged);
            // 
            // cb_MasterOnly
            // 
            this.cb_MasterOnly.Location = new System.Drawing.Point(92, 5);
            this.cb_MasterOnly.Name = "cb_MasterOnly";
            this.cb_MasterOnly.Size = new System.Drawing.Size(122, 23);
            this.cb_MasterOnly.TabIndex = 2;
            this.cb_MasterOnly.Text = "Master Rows Only";
            this.cb_MasterOnly.CheckedChanged += new System.EventHandler(this.cb_MasterOnly_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 378);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        internal DevExpress.XtraGrid.Views.Grid.GridView GridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckButton cb_NonBlank;
        private DevExpress.XtraEditors.CheckButton cb_MasterOnly;
        private DevExpress.XtraEditors.CheckButton cb_MasterDetail;
    }
}

