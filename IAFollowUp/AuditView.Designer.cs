namespace IAFollowUp
{
    partial class AuditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditView));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIupdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MIdelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MIattachments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MIshowFindings = new System.Windows.Forms.ToolStripMenuItem();
            this.MIfinalizeAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.auditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIASentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colAuditRating = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupervisor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCreateNewAudit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.auditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsOnGrid;
            this.gridControl1.DataSource = this.auditBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 89);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(984, 473);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIupdate,
            this.MIdelete,
            this.tsSep1,
            this.MIattachments,
            this.tsSep2,
            this.MIshowFindings,
            this.MIfinalizeAudit});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(208, 126);
            // 
            // MIupdate
            // 
            this.MIupdate.Name = "MIupdate";
            this.MIupdate.Size = new System.Drawing.Size(207, 22);
            this.MIupdate.Text = "Edit";
            this.MIupdate.Click += new System.EventHandler(this.MIupdate_Click);
            // 
            // MIdelete
            // 
            this.MIdelete.Name = "MIdelete";
            this.MIdelete.Size = new System.Drawing.Size(207, 22);
            this.MIdelete.Text = "Delete";
            this.MIdelete.Click += new System.EventHandler(this.MIdelete_Click);
            // 
            // tsSep1
            // 
            this.tsSep1.Name = "tsSep1";
            this.tsSep1.Size = new System.Drawing.Size(204, 6);
            // 
            // MIattachments
            // 
            this.MIattachments.Name = "MIattachments";
            this.MIattachments.Size = new System.Drawing.Size(207, 22);
            this.MIattachments.Text = "Attachments";
            this.MIattachments.Click += new System.EventHandler(this.MIattachments_Click);
            // 
            // tsSep2
            // 
            this.tsSep2.Name = "tsSep2";
            this.tsSep2.Size = new System.Drawing.Size(204, 6);
            // 
            // MIshowFindings
            // 
            this.MIshowFindings.Name = "MIshowFindings";
            this.MIshowFindings.Size = new System.Drawing.Size(207, 22);
            this.MIshowFindings.Text = "Findings / Improvements";
            this.MIshowFindings.Click += new System.EventHandler(this.MIshowFindings_Click);
            // 
            // MIfinalizeAudit
            // 
            this.MIfinalizeAudit.Name = "MIfinalizeAudit";
            this.MIfinalizeAudit.Size = new System.Drawing.Size(207, 22);
            this.MIfinalizeAudit.Text = "Finalize Audit";
            this.MIfinalizeAudit.Click += new System.EventHandler(this.MIfinalizeAudit_Click);
            // 
            // auditBindingSource
            // 
            this.auditBindingSource.DataSource = typeof(IAFollowUp.Audit);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colAuditRef,
            this.colYear,
            this.colCompany,
            this.colAuditNumber,
            this.colAuditType,
            this.colIASentNumber,
            this.colTitle,
            this.colAuditRating,
            this.colReportDt,
            this.colAuditor1,
            this.colAuditor2,
            this.colSupervisor,
            this.colIsCompleted,
            this.colIsDeleted});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colAuditRef
            // 
            this.colAuditRef.FieldName = "AuditRef";
            this.colAuditRef.Name = "colAuditRef";
            this.colAuditRef.Visible = true;
            this.colAuditRef.VisibleIndex = 0;
            this.colAuditRef.Width = 69;
            // 
            // colYear
            // 
            this.colYear.Caption = "Year";
            this.colYear.FieldName = "Year";
            this.colYear.MaxWidth = 50;
            this.colYear.Name = "colYear";
            this.colYear.Visible = true;
            this.colYear.VisibleIndex = 1;
            this.colYear.Width = 50;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Company";
            this.colCompany.FieldName = "Company.Name";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 2;
            this.colCompany.Width = 66;
            // 
            // colAuditNumber
            // 
            this.colAuditNumber.Caption = "Audit Number";
            this.colAuditNumber.FieldName = "AuditNumber";
            this.colAuditNumber.Name = "colAuditNumber";
            this.colAuditNumber.Visible = true;
            this.colAuditNumber.VisibleIndex = 3;
            this.colAuditNumber.Width = 66;
            // 
            // colAuditType
            // 
            this.colAuditType.Caption = "Audit Type";
            this.colAuditType.FieldName = "AuditType.Name";
            this.colAuditType.Name = "colAuditType";
            this.colAuditType.Visible = true;
            this.colAuditType.VisibleIndex = 4;
            this.colAuditType.Width = 66;
            // 
            // colIASentNumber
            // 
            this.colIASentNumber.Caption = "IA Sent Number";
            this.colIASentNumber.FieldName = "IASentNumber";
            this.colIASentNumber.Name = "colIASentNumber";
            this.colIASentNumber.Visible = true;
            this.colIASentNumber.VisibleIndex = 5;
            this.colIASentNumber.Width = 66;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Title";
            this.colTitle.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 6;
            this.colTitle.Width = 66;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colAuditRating
            // 
            this.colAuditRating.Caption = "Audit Rating";
            this.colAuditRating.FieldName = "AuditRating.Name";
            this.colAuditRating.Name = "colAuditRating";
            this.colAuditRating.Visible = true;
            this.colAuditRating.VisibleIndex = 7;
            this.colAuditRating.Width = 66;
            // 
            // colReportDt
            // 
            this.colReportDt.Caption = "Report Date";
            this.colReportDt.FieldName = "ReportDt";
            this.colReportDt.Name = "colReportDt";
            this.colReportDt.Visible = true;
            this.colReportDt.VisibleIndex = 8;
            this.colReportDt.Width = 66;
            // 
            // colAuditor1
            // 
            this.colAuditor1.Caption = "Auditor1";
            this.colAuditor1.FieldName = "Auditor1.FullName";
            this.colAuditor1.Name = "colAuditor1";
            this.colAuditor1.Visible = true;
            this.colAuditor1.VisibleIndex = 9;
            this.colAuditor1.Width = 66;
            // 
            // colAuditor2
            // 
            this.colAuditor2.Caption = "Auditor2";
            this.colAuditor2.FieldName = "Auditor2.FullName";
            this.colAuditor2.Name = "colAuditor2";
            this.colAuditor2.Visible = true;
            this.colAuditor2.VisibleIndex = 10;
            this.colAuditor2.Width = 66;
            // 
            // colSupervisor
            // 
            this.colSupervisor.Caption = "Supervisor";
            this.colSupervisor.FieldName = "Supervisor.FullName";
            this.colSupervisor.Name = "colSupervisor";
            this.colSupervisor.Visible = true;
            this.colSupervisor.VisibleIndex = 11;
            this.colSupervisor.Width = 66;
            // 
            // colIsCompleted
            // 
            this.colIsCompleted.Caption = "Finalized";
            this.colIsCompleted.FieldName = "IsCompleted";
            this.colIsCompleted.Name = "colIsCompleted";
            this.colIsCompleted.Visible = true;
            this.colIsCompleted.VisibleIndex = 12;
            this.colIsCompleted.Width = 66;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.Caption = "Deleted";
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 13;
            this.colIsDeleted.Width = 96;
            // 
            // btnCreateNewAudit
            // 
            this.btnCreateNewAudit.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnCreateNewAudit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewAudit.Location = new System.Drawing.Point(12, 24);
            this.btnCreateNewAudit.Name = "btnCreateNewAudit";
            this.btnCreateNewAudit.Size = new System.Drawing.Size(120, 45);
            this.btnCreateNewAudit.TabIndex = 2;
            this.btnCreateNewAudit.Text = "New Audit";
            this.btnCreateNewAudit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewAudit.UseVisualStyleBackColor = true;
            this.btnCreateNewAudit.Click += new System.EventHandler(this.btnCreateNewAudit_Click);
            // 
            // AuditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnCreateNewAudit);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "AuditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audits View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.auditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem MIupdate;
        private System.Windows.Forms.ToolStripMenuItem MIdelete;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripMenuItem MIattachments;
        private System.Windows.Forms.ToolStripSeparator tsSep2;
        private System.Windows.Forms.ToolStripMenuItem MIshowFindings;
        private System.Windows.Forms.ToolStripMenuItem MIfinalizeAudit;
        private System.Windows.Forms.Button btnCreateNewAudit;
        private System.Windows.Forms.BindingSource auditBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditType;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colReportDt;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditor1;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditor2;
        private DevExpress.XtraGrid.Columns.GridColumn colSupervisor;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colIASentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditRating;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditRef;
    }
}