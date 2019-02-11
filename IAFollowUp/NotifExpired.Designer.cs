namespace IAFollowUp
{
    partial class NotifExpired
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifExpired));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaceholder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaceholder1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 66);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(784, 376);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailId,
            this.colActionDt,
            this.colPlaceholder,
            this.colPlaceholder1,
            this.colUser});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colDetailId
            // 
            this.colDetailId.FieldName = "DetailId";
            this.colDetailId.Name = "colDetailId";
            this.colDetailId.Visible = true;
            this.colDetailId.VisibleIndex = 0;
            // 
            // colActionDt
            // 
            this.colActionDt.Caption = "Action Date";
            this.colActionDt.FieldName = "ActionDt";
            this.colActionDt.Name = "colActionDt";
            this.colActionDt.Visible = true;
            this.colActionDt.VisibleIndex = 1;
            // 
            // colPlaceholder
            // 
            this.colPlaceholder.Caption = "Company";
            this.colPlaceholder.FieldName = "Placeholder.Company.Name";
            this.colPlaceholder.Name = "colPlaceholder";
            this.colPlaceholder.Visible = true;
            this.colPlaceholder.VisibleIndex = 2;
            // 
            // colPlaceholder1
            // 
            this.colPlaceholder1.Caption = "Department";
            this.colPlaceholder1.FieldName = "Placeholder.Department.Name";
            this.colPlaceholder1.Name = "colPlaceholder1";
            this.colPlaceholder1.Visible = true;
            this.colPlaceholder1.VisibleIndex = 3;
            // 
            // colUser
            // 
            this.colUser.Caption = "Manager Name";
            this.colUser.FieldName = "User.FullName";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 4;
            // 
            // NotifExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "NotifExpired";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notifications - Expired";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailId;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDt;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholder;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholder1;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
    }
}