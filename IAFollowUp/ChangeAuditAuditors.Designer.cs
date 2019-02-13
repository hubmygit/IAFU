namespace IAFollowUp
{
    partial class ChangeAuditAuditors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeAuditAuditors));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsOwners = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIaddOwner = new System.Windows.Forms.ToolStripMenuItem();
            this.MIaddSupervisor = new System.Windows.Forms.ToolStripMenuItem();
            this.MIremoveOwner = new System.Windows.Forms.ToolStripMenuItem();
            this.MIremoveSupervisor = new System.Windows.Forms.ToolStripMenuItem();
            this.MIchangeOwner = new System.Windows.Forms.ToolStripMenuItem();
            this.MIchangeSupervisor = new System.Windows.Forms.ToolStripMenuItem();
            this.auditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupervisor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIASentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditRating = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditRef = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsOwners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.auditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsOwners;
            this.gridControl1.DataSource = this.auditBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 72);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(784, 370);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsOwners
            // 
            this.cmsOwners.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIaddOwner,
            this.MIaddSupervisor,
            this.MIremoveOwner,
            this.MIremoveSupervisor,
            this.MIchangeOwner,
            this.MIchangeSupervisor});
            this.cmsOwners.Name = "cmsHeader";
            this.cmsOwners.Size = new System.Drawing.Size(207, 136);
            // 
            // MIaddOwner
            // 
            this.MIaddOwner.Name = "MIaddOwner";
            this.MIaddOwner.Size = new System.Drawing.Size(206, 22);
            this.MIaddOwner.Text = "Add Owner (Auditor)";
            this.MIaddOwner.Click += new System.EventHandler(this.MIaddOwner_Click);
            // 
            // MIaddSupervisor
            // 
            this.MIaddSupervisor.Name = "MIaddSupervisor";
            this.MIaddSupervisor.Size = new System.Drawing.Size(206, 22);
            this.MIaddSupervisor.Text = "Add Supervisor";
            this.MIaddSupervisor.Click += new System.EventHandler(this.MIaddSupervisor_Click);
            // 
            // MIremoveOwner
            // 
            this.MIremoveOwner.Name = "MIremoveOwner";
            this.MIremoveOwner.Size = new System.Drawing.Size(206, 22);
            this.MIremoveOwner.Text = "Remove Owner (Auditor)";
            this.MIremoveOwner.Click += new System.EventHandler(this.MIremoveOwner_Click);
            // 
            // MIremoveSupervisor
            // 
            this.MIremoveSupervisor.Name = "MIremoveSupervisor";
            this.MIremoveSupervisor.Size = new System.Drawing.Size(206, 22);
            this.MIremoveSupervisor.Text = "Remove Supervisor";
            this.MIremoveSupervisor.Click += new System.EventHandler(this.MIremoveSupervisor_Click);
            // 
            // MIchangeOwner
            // 
            this.MIchangeOwner.Name = "MIchangeOwner";
            this.MIchangeOwner.Size = new System.Drawing.Size(206, 22);
            this.MIchangeOwner.Text = "Change Owner (Auditor)";
            this.MIchangeOwner.Click += new System.EventHandler(this.MIchangeOwner_Click);
            // 
            // MIchangeSupervisor
            // 
            this.MIchangeSupervisor.Name = "MIchangeSupervisor";
            this.MIchangeSupervisor.Size = new System.Drawing.Size(206, 22);
            this.MIchangeSupervisor.Text = "Change Supervisor";
            this.MIchangeSupervisor.Click += new System.EventHandler(this.MIchangeSupervisor_Click);
            // 
            // auditBindingSource
            // 
            this.auditBindingSource.DataSource = typeof(IAFollowUp.Audit);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colYear,
            this.colCompany,
            this.colAuditType,
            this.colTitle,
            this.colReportDt,
            this.colAuditor1,
            this.colAuditor2,
            this.colSupervisor,
            this.colIsCompleted,
            this.colAuditNumber,
            this.colIASentNumber,
            this.colAuditRating,
            this.colIsDeleted,
            this.colAuditRef});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colYear
            // 
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.Visible = true;
            this.colYear.VisibleIndex = 1;
            // 
            // colCompany
            // 
            this.colCompany.FieldName = "Company.Name";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 2;
            // 
            // colAuditType
            // 
            this.colAuditType.FieldName = "AuditType.Name";
            this.colAuditType.Name = "colAuditType";
            this.colAuditType.Visible = true;
            this.colAuditType.VisibleIndex = 3;
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 4;
            // 
            // colReportDt
            // 
            this.colReportDt.FieldName = "ReportDt";
            this.colReportDt.Name = "colReportDt";
            this.colReportDt.Visible = true;
            this.colReportDt.VisibleIndex = 5;
            // 
            // colAuditor1
            // 
            this.colAuditor1.FieldName = "Auditor1.FullName";
            this.colAuditor1.Name = "colAuditor1";
            this.colAuditor1.Visible = true;
            this.colAuditor1.VisibleIndex = 6;
            // 
            // colAuditor2
            // 
            this.colAuditor2.FieldName = "Auditor2.FullName";
            this.colAuditor2.Name = "colAuditor2";
            this.colAuditor2.Visible = true;
            this.colAuditor2.VisibleIndex = 7;
            // 
            // colSupervisor
            // 
            this.colSupervisor.FieldName = "Supervisor.FullName";
            this.colSupervisor.Name = "colSupervisor";
            this.colSupervisor.Visible = true;
            this.colSupervisor.VisibleIndex = 8;
            // 
            // colIsCompleted
            // 
            this.colIsCompleted.FieldName = "IsCompleted";
            this.colIsCompleted.Name = "colIsCompleted";
            this.colIsCompleted.Visible = true;
            this.colIsCompleted.VisibleIndex = 9;
            // 
            // colAuditNumber
            // 
            this.colAuditNumber.FieldName = "AuditNumber";
            this.colAuditNumber.Name = "colAuditNumber";
            this.colAuditNumber.Visible = true;
            this.colAuditNumber.VisibleIndex = 10;
            // 
            // colIASentNumber
            // 
            this.colIASentNumber.FieldName = "IASentNumber";
            this.colIASentNumber.Name = "colIASentNumber";
            this.colIASentNumber.Visible = true;
            this.colIASentNumber.VisibleIndex = 11;
            // 
            // colAuditRating
            // 
            this.colAuditRating.FieldName = "AuditRating.Name";
            this.colAuditRating.Name = "colAuditRating";
            this.colAuditRating.Visible = true;
            this.colAuditRating.VisibleIndex = 12;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 13;
            // 
            // colAuditRef
            // 
            this.colAuditRef.FieldName = "AuditRef";
            this.colAuditRef.Name = "colAuditRef";
            this.colAuditRef.Visible = true;
            this.colAuditRef.VisibleIndex = 14;
            // 
            // ChangeAuditAuditors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "ChangeAuditAuditors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Audit Auditors";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsOwners.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.auditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
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
        private DevExpress.XtraGrid.Columns.GridColumn colAuditRef;
        public System.Windows.Forms.ContextMenuStrip cmsOwners;
        private System.Windows.Forms.ToolStripMenuItem MIaddOwner;
        private System.Windows.Forms.ToolStripMenuItem MIremoveOwner;
        private System.Windows.Forms.ToolStripMenuItem MIchangeOwner;
        private System.Windows.Forms.ToolStripMenuItem MIaddSupervisor;
        private System.Windows.Forms.ToolStripMenuItem MIremoveSupervisor;
        private System.Windows.Forms.ToolStripMenuItem MIchangeSupervisor;
    }
}