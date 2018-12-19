namespace IAFollowUp
{
    partial class FIView_Auditees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIView_Auditees));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.fI_DetailHeaderAuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAuditId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colHeaderCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailActionReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailIsFinalized = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fI_DetailHeaderAuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.fI_DetailHeaderAuditBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 64);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2,
            this.repositoryItemMemoEdit3,
            this.repositoryItemMemoEdit4});
            this.gridControl1.Size = new System.Drawing.Size(784, 378);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // fI_DetailHeaderAuditBindingSource
            // 
            this.fI_DetailHeaderAuditBindingSource.DataSource = typeof(IAFollowUp.FI_DetailHeaderAudit);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAuditId,
            this.colAuditCompany,
            this.colAuditYear,
            this.colHeaderId,
            this.colHeaderTitle,
            this.colHeaderCategory,
            this.colDetailId,
            this.colDetailDescription,
            this.colDetailActionDt,
            this.colDetailActionReq,
            this.colDetailIsFinalized});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            // 
            // colAuditId
            // 
            this.colAuditId.Caption = "Audit Id";
            this.colAuditId.FieldName = "AuditId";
            this.colAuditId.Name = "colAuditId";
            // 
            // colAuditCompany
            // 
            this.colAuditCompany.Caption = "Audit Company";
            this.colAuditCompany.FieldName = "AuditCompany.Name";
            this.colAuditCompany.Name = "colAuditCompany";
            this.colAuditCompany.Visible = true;
            this.colAuditCompany.VisibleIndex = 0;
            // 
            // colAuditYear
            // 
            this.colAuditYear.Caption = "Audit Year";
            this.colAuditYear.FieldName = "AuditYear";
            this.colAuditYear.Name = "colAuditYear";
            this.colAuditYear.Visible = true;
            this.colAuditYear.VisibleIndex = 1;
            // 
            // colHeaderId
            // 
            this.colHeaderId.Caption = "Header Id";
            this.colHeaderId.FieldName = "HeaderId";
            this.colHeaderId.Name = "colHeaderId";
            // 
            // colHeaderTitle
            // 
            this.colHeaderTitle.Caption = "Header Title";
            this.colHeaderTitle.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colHeaderTitle.FieldName = "HeaderTitle";
            this.colHeaderTitle.Name = "colHeaderTitle";
            this.colHeaderTitle.Visible = true;
            this.colHeaderTitle.VisibleIndex = 2;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colHeaderCategory
            // 
            this.colHeaderCategory.Caption = "Header Category";
            this.colHeaderCategory.FieldName = "HeaderCategory.Name";
            this.colHeaderCategory.Name = "colHeaderCategory";
            this.colHeaderCategory.Visible = true;
            this.colHeaderCategory.VisibleIndex = 3;
            // 
            // colDetailId
            // 
            this.colDetailId.Caption = "Detail Id";
            this.colDetailId.FieldName = "DetailId";
            this.colDetailId.Name = "colDetailId";
            // 
            // colDetailDescription
            // 
            this.colDetailDescription.Caption = "Detail Description";
            this.colDetailDescription.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colDetailDescription.FieldName = "DetailDescription";
            this.colDetailDescription.Name = "colDetailDescription";
            this.colDetailDescription.Visible = true;
            this.colDetailDescription.VisibleIndex = 4;
            // 
            // colDetailActionDt
            // 
            this.colDetailActionDt.Caption = "Detail Action Date";
            this.colDetailActionDt.FieldName = "DetailActionDt";
            this.colDetailActionDt.Name = "colDetailActionDt";
            this.colDetailActionDt.Visible = true;
            this.colDetailActionDt.VisibleIndex = 5;
            // 
            // colDetailActionReq
            // 
            this.colDetailActionReq.Caption = "Detail Action Required";
            this.colDetailActionReq.ColumnEdit = this.repositoryItemMemoEdit4;
            this.colDetailActionReq.FieldName = "DetailActionReq";
            this.colDetailActionReq.Name = "colDetailActionReq";
            this.colDetailActionReq.Visible = true;
            this.colDetailActionReq.VisibleIndex = 6;
            // 
            // colDetailIsFinalized
            // 
            this.colDetailIsFinalized.Caption = "Detail Finalized";
            this.colDetailIsFinalized.FieldName = "DetailIsFinalized";
            this.colDetailIsFinalized.Name = "colDetailIsFinalized";
            this.colDetailIsFinalized.Visible = true;
            this.colDetailIsFinalized.VisibleIndex = 7;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // repositoryItemMemoEdit4
            // 
            this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
            // 
            // FIView_Auditees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "FIView_Auditees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements View";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fI_DetailHeaderAuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource fI_DetailHeaderAuditBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditId;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditYear;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailId;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailActionDt;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailActionReq;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailIsFinalized;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit4;
    }
}