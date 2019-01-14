namespace IAFollowUp
{
    partial class FIView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIView));
            this.gridControlDetails = new DevExpress.XtraGrid.GridControl();
            this.cmsDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIeditDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.MIduplicateDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.MIdeleteDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MIattachments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mIfinalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fIDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailsId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFIHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFISubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colActionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsClosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPublished = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsFinalized = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentDept1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentUser1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentDept2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentDept3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentUser3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCreateNewHeader = new System.Windows.Forms.Button();
            this.btnCreateNewDetail = new System.Windows.Forms.Button();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtAuditTitle = new System.Windows.Forms.TextBox();
            this.lblAuditTitle = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.gridControlHeaders = new DevExpress.XtraGrid.GridControl();
            this.cmsHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIeditHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.MIdeleteHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.fIHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewHeaders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFIId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colFICategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblHeaders = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetails)).BeginInit();
            this.cmsDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHeaders)).BeginInit();
            this.cmsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fIHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHeaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlDetails
            // 
            this.gridControlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDetails.ContextMenuStrip = this.cmsDetail;
            this.gridControlDetails.DataSource = this.fIDetailBindingSource;
            this.gridControlDetails.Location = new System.Drawing.Point(0, 387);
            this.gridControlDetails.MainView = this.gridViewDetails;
            this.gridControlDetails.Name = "gridControlDetails";
            this.gridControlDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2,
            this.repositoryItemMemoEdit3});
            this.gridControlDetails.ShowOnlyPredefinedDetails = true;
            this.gridControlDetails.Size = new System.Drawing.Size(984, 200);
            this.gridControlDetails.TabIndex = 3;
            this.gridControlDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetails});
            // 
            // cmsDetail
            // 
            this.cmsDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIeditDetail,
            this.MIduplicateDetail,
            this.MIdeleteDetail,
            this.toolStripSeparator1,
            this.MIattachments,
            this.toolStripSeparator2,
            this.mIfinalizeToolStripMenuItem});
            this.cmsDetail.Name = "cmsHeader";
            this.cmsDetail.Size = new System.Drawing.Size(143, 126);
            // 
            // MIeditDetail
            // 
            this.MIeditDetail.Name = "MIeditDetail";
            this.MIeditDetail.Size = new System.Drawing.Size(142, 22);
            this.MIeditDetail.Text = "Edit";
            this.MIeditDetail.Click += new System.EventHandler(this.MIeditDetail_Click);
            // 
            // MIduplicateDetail
            // 
            this.MIduplicateDetail.Name = "MIduplicateDetail";
            this.MIduplicateDetail.Size = new System.Drawing.Size(142, 22);
            this.MIduplicateDetail.Text = "Duplicate";
            this.MIduplicateDetail.Click += new System.EventHandler(this.MIduplicateDetail_Click);
            // 
            // MIdeleteDetail
            // 
            this.MIdeleteDetail.Name = "MIdeleteDetail";
            this.MIdeleteDetail.Size = new System.Drawing.Size(142, 22);
            this.MIdeleteDetail.Text = "Delete";
            this.MIdeleteDetail.Click += new System.EventHandler(this.MIdeleteDetail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // MIattachments
            // 
            this.MIattachments.Name = "MIattachments";
            this.MIattachments.Size = new System.Drawing.Size(142, 22);
            this.MIattachments.Text = "Attachments";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // mIfinalizeToolStripMenuItem
            // 
            this.mIfinalizeToolStripMenuItem.Enabled = false;
            this.mIfinalizeToolStripMenuItem.Name = "mIfinalizeToolStripMenuItem";
            this.mIfinalizeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.mIfinalizeToolStripMenuItem.Text = "Finalize";
            this.mIfinalizeToolStripMenuItem.Click += new System.EventHandler(this.mIfinalizeToolStripMenuItem_Click);
            // 
            // fIDetailBindingSource
            // 
            this.fIDetailBindingSource.DataSource = typeof(IAFollowUp.FIDetail);
            // 
            // gridViewDetails
            // 
            this.gridViewDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailsId,
            this.colFIHeaderId,
            this.colFISubId,
            this.colDescription,
            this.colActionDt,
            this.colActionReq,
            this.colActionCode,
            this.colIsClosed,
            this.colIsPublished,
            this.colIsFinalized,
            this.colDetailIsDeleted,
            this.colCurrentDept1,
            this.colCurrentUser1,
            this.colCurrentDept2,
            this.colCurrentUser2,
            this.colCurrentDept3,
            this.colCurrentUser3});
            this.gridViewDetails.GridControl = this.gridControlDetails;
            this.gridViewDetails.Name = "gridViewDetails";
            this.gridViewDetails.OptionsBehavior.Editable = false;
            this.gridViewDetails.OptionsBehavior.ReadOnly = true;
            this.gridViewDetails.OptionsView.RowAutoHeight = true;
            // 
            // colDetailsId
            // 
            this.colDetailsId.Caption = "Id";
            this.colDetailsId.FieldName = "Id";
            this.colDetailsId.Name = "colDetailsId";
            // 
            // colFIHeaderId
            // 
            this.colFIHeaderId.Caption = "FIHeaderId";
            this.colFIHeaderId.FieldName = "FIHeaderId";
            this.colFIHeaderId.Name = "colFIHeaderId";
            // 
            // colFISubId
            // 
            this.colFISubId.Caption = "FI SubId";
            this.colFISubId.FieldName = "FISubId";
            this.colFISubId.Name = "colFISubId";
            this.colFISubId.Visible = true;
            this.colFISubId.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // colActionDt
            // 
            this.colActionDt.Caption = "Action Date";
            this.colActionDt.FieldName = "ActionDt";
            this.colActionDt.Name = "colActionDt";
            this.colActionDt.Visible = true;
            this.colActionDt.VisibleIndex = 2;
            // 
            // colActionReq
            // 
            this.colActionReq.Caption = "Action Required";
            this.colActionReq.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colActionReq.FieldName = "ActionReq";
            this.colActionReq.Name = "colActionReq";
            this.colActionReq.Visible = true;
            this.colActionReq.VisibleIndex = 3;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colActionCode
            // 
            this.colActionCode.Caption = "Action Code";
            this.colActionCode.FieldName = "ActionCode";
            this.colActionCode.Name = "colActionCode";
            this.colActionCode.Visible = true;
            this.colActionCode.VisibleIndex = 4;
            // 
            // colIsClosed
            // 
            this.colIsClosed.Caption = "Closed";
            this.colIsClosed.FieldName = "IsClosed";
            this.colIsClosed.Name = "colIsClosed";
            this.colIsClosed.Visible = true;
            this.colIsClosed.VisibleIndex = 5;
            // 
            // colIsPublished
            // 
            this.colIsPublished.Caption = "Published";
            this.colIsPublished.FieldName = "IsPublished";
            this.colIsPublished.Name = "colIsPublished";
            this.colIsPublished.Visible = true;
            this.colIsPublished.VisibleIndex = 6;
            // 
            // colIsFinalized
            // 
            this.colIsFinalized.Caption = "Finalized";
            this.colIsFinalized.FieldName = "IsFinalized";
            this.colIsFinalized.Name = "colIsFinalized";
            this.colIsFinalized.Visible = true;
            this.colIsFinalized.VisibleIndex = 7;
            // 
            // colDetailIsDeleted
            // 
            this.colDetailIsDeleted.Caption = "Deleted";
            this.colDetailIsDeleted.FieldName = "IsDeleted";
            this.colDetailIsDeleted.Name = "colDetailIsDeleted";
            this.colDetailIsDeleted.Visible = true;
            this.colDetailIsDeleted.VisibleIndex = 8;
            // 
            // colCurrentDept1
            // 
            this.colCurrentDept1.Caption = "Department1";
            this.colCurrentDept1.FieldName = "CurrentOwner1.Placeholder.Department.Name";
            this.colCurrentDept1.Name = "colCurrentDept1";
            this.colCurrentDept1.Visible = true;
            this.colCurrentDept1.VisibleIndex = 9;
            // 
            // colCurrentUser1
            // 
            this.colCurrentUser1.Caption = "Owner1";
            this.colCurrentUser1.FieldName = "CurrentOwner1.User.FullName";
            this.colCurrentUser1.Name = "colCurrentUser1";
            this.colCurrentUser1.Visible = true;
            this.colCurrentUser1.VisibleIndex = 10;
            // 
            // colCurrentDept2
            // 
            this.colCurrentDept2.Caption = "Department2";
            this.colCurrentDept2.FieldName = "CurrentOwner2.Placeholder.Department.Name";
            this.colCurrentDept2.Name = "colCurrentDept2";
            this.colCurrentDept2.Visible = true;
            this.colCurrentDept2.VisibleIndex = 11;
            // 
            // colCurrentUser2
            // 
            this.colCurrentUser2.Caption = "Owner2";
            this.colCurrentUser2.FieldName = "CurrentOwner2.User.FullName";
            this.colCurrentUser2.Name = "colCurrentUser2";
            this.colCurrentUser2.Visible = true;
            this.colCurrentUser2.VisibleIndex = 12;
            // 
            // colCurrentDept3
            // 
            this.colCurrentDept3.Caption = "Department3";
            this.colCurrentDept3.FieldName = "CurrentOwner3.Placeholder.Department.Name";
            this.colCurrentDept3.Name = "colCurrentDept3";
            this.colCurrentDept3.Visible = true;
            this.colCurrentDept3.VisibleIndex = 13;
            // 
            // colCurrentUser3
            // 
            this.colCurrentUser3.Caption = "Owner3";
            this.colCurrentUser3.FieldName = "CurrentOwner3.User.FullName";
            this.colCurrentUser3.Name = "colCurrentUser3";
            this.colCurrentUser3.Visible = true;
            this.colCurrentUser3.VisibleIndex = 14;
            // 
            // btnCreateNewHeader
            // 
            this.btnCreateNewHeader.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnCreateNewHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewHeader.Location = new System.Drawing.Point(0, 102);
            this.btnCreateNewHeader.Name = "btnCreateNewHeader";
            this.btnCreateNewHeader.Size = new System.Drawing.Size(100, 30);
            this.btnCreateNewHeader.TabIndex = 2;
            this.btnCreateNewHeader.Text = "New Header";
            this.btnCreateNewHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewHeader.UseVisualStyleBackColor = true;
            this.btnCreateNewHeader.Click += new System.EventHandler(this.btnCreateNewHeader_Click);
            // 
            // btnCreateNewDetail
            // 
            this.btnCreateNewDetail.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnCreateNewDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewDetail.Location = new System.Drawing.Point(0, 354);
            this.btnCreateNewDetail.Name = "btnCreateNewDetail";
            this.btnCreateNewDetail.Size = new System.Drawing.Size(100, 30);
            this.btnCreateNewDetail.TabIndex = 4;
            this.btnCreateNewDetail.Text = "New Detail";
            this.btnCreateNewDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewDetail.UseVisualStyleBackColor = true;
            this.btnCreateNewDetail.Click += new System.EventHandler(this.btnCreateNewDetail_Click);
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtCompany.Location = new System.Drawing.Point(84, 6);
            this.txtCompany.MaxLength = 3;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(500, 22);
            this.txtCompany.TabIndex = 0;
            // 
            // txtAuditTitle
            // 
            this.txtAuditTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAuditTitle.Location = new System.Drawing.Point(84, 34);
            this.txtAuditTitle.MaxLength = 500;
            this.txtAuditTitle.Multiline = true;
            this.txtAuditTitle.Name = "txtAuditTitle";
            this.txtAuditTitle.ReadOnly = true;
            this.txtAuditTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAuditTitle.Size = new System.Drawing.Size(888, 50);
            this.txtAuditTitle.TabIndex = 0;
            // 
            // lblAuditTitle
            // 
            this.lblAuditTitle.AutoSize = true;
            this.lblAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditTitle.Location = new System.Drawing.Point(11, 51);
            this.lblAuditTitle.Name = "lblAuditTitle";
            this.lblAuditTitle.Size = new System.Drawing.Size(67, 16);
            this.lblAuditTitle.TabIndex = 0;
            this.lblAuditTitle.Text = "Audit Title";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(12, 9);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 16);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtYear.Location = new System.Drawing.Point(772, 6);
            this.txtYear.MaxLength = 3;
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(200, 22);
            this.txtYear.TabIndex = 0;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblYear.Location = new System.Drawing.Point(729, 9);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 16);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "Year";
            // 
            // gridControlHeaders
            // 
            this.gridControlHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlHeaders.ContextMenuStrip = this.cmsHeader;
            this.gridControlHeaders.DataSource = this.fIHeaderBindingSource;
            this.gridControlHeaders.Location = new System.Drawing.Point(0, 135);
            this.gridControlHeaders.MainView = this.gridViewHeaders;
            this.gridControlHeaders.Name = "gridControlHeaders";
            this.gridControlHeaders.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridControlHeaders.ShowOnlyPredefinedDetails = true;
            this.gridControlHeaders.Size = new System.Drawing.Size(984, 200);
            this.gridControlHeaders.TabIndex = 1;
            this.gridControlHeaders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHeaders});
            // 
            // cmsHeader
            // 
            this.cmsHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIeditHeader,
            this.MIdeleteHeader});
            this.cmsHeader.Name = "cmsHeader";
            this.cmsHeader.Size = new System.Drawing.Size(108, 48);
            // 
            // MIeditHeader
            // 
            this.MIeditHeader.Name = "MIeditHeader";
            this.MIeditHeader.Size = new System.Drawing.Size(107, 22);
            this.MIeditHeader.Text = "Edit";
            this.MIeditHeader.Click += new System.EventHandler(this.MIeditHeader_Click);
            // 
            // MIdeleteHeader
            // 
            this.MIdeleteHeader.Name = "MIdeleteHeader";
            this.MIdeleteHeader.Size = new System.Drawing.Size(107, 22);
            this.MIdeleteHeader.Text = "Delete";
            this.MIdeleteHeader.Click += new System.EventHandler(this.MIdeleteHeader_Click);
            // 
            // fIHeaderBindingSource
            // 
            this.fIHeaderBindingSource.DataSource = typeof(IAFollowUp.FIHeader);
            // 
            // gridViewHeaders
            // 
            this.gridViewHeaders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colAuditId,
            this.colFIId,
            this.colTitle,
            this.colFICategory,
            this.colIsDeleted});
            this.gridViewHeaders.GridControl = this.gridControlHeaders;
            this.gridViewHeaders.Name = "gridViewHeaders";
            this.gridViewHeaders.OptionsBehavior.Editable = false;
            this.gridViewHeaders.OptionsBehavior.ReadOnly = true;
            this.gridViewHeaders.OptionsView.RowAutoHeight = true;
            this.gridViewHeaders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridViewHeaders_MouseDown);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colAuditId
            // 
            this.colAuditId.FieldName = "AuditId";
            this.colAuditId.Name = "colAuditId";
            // 
            // colFIId
            // 
            this.colFIId.Caption = "FI Id";
            this.colFIId.FieldName = "FIId";
            this.colFIId.Name = "colFIId";
            this.colFIId.Visible = true;
            this.colFIId.VisibleIndex = 0;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Title";
            this.colTitle.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colTitle.FieldName = "Title";
            this.colTitle.MinWidth = 200;
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 1;
            this.colTitle.Width = 220;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colFICategory
            // 
            this.colFICategory.Caption = "Category";
            this.colFICategory.FieldName = "FICategory.Name";
            this.colFICategory.MinWidth = 200;
            this.colFICategory.Name = "colFICategory";
            this.colFICategory.Visible = true;
            this.colFICategory.VisibleIndex = 2;
            this.colFICategory.Width = 200;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.Caption = "Deleted";
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 3;
            // 
            // lblHeaders
            // 
            this.lblHeaders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeaders.AutoSize = true;
            this.lblHeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeaders.Location = new System.Drawing.Point(442, 102);
            this.lblHeaders.Name = "lblHeaders";
            this.lblHeaders.Size = new System.Drawing.Size(100, 25);
            this.lblHeaders.TabIndex = 0;
            this.lblHeaders.Text = "Headers";
            // 
            // lblDetails
            // 
            this.lblDetails.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetails.Location = new System.Drawing.Point(442, 354);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(85, 25);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "Details";
            // 
            // FIView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 587);
            this.Controls.Add(this.gridControlDetails);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblHeaders);
            this.Controls.Add(this.gridControlHeaders);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtAuditTitle);
            this.Controls.Add(this.lblAuditTitle);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnCreateNewDetail);
            this.Controls.Add(this.btnCreateNewHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 625);
            this.Name = "FIView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetails)).EndInit();
            this.cmsDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHeaders)).EndInit();
            this.cmsHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fIHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHeaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreateNewHeader;
        private System.Windows.Forms.Button btnCreateNewDetail;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtAuditTitle;
        private System.Windows.Forms.Label lblAuditTitle;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblYear;
        private DevExpress.XtraGrid.GridControl gridControlHeaders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHeaders;
        private System.Windows.Forms.BindingSource fIHeaderBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditId;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colFICategory;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private System.Windows.Forms.Label lblHeaders;
        public System.Windows.Forms.ContextMenuStrip cmsHeader;
        private System.Windows.Forms.ToolStripMenuItem MIeditHeader;
        private System.Windows.Forms.ToolStripMenuItem MIdeleteHeader;
        private System.Windows.Forms.Label lblDetails;
        private DevExpress.XtraGrid.GridControl gridControlDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetails;
        public System.Windows.Forms.ContextMenuStrip cmsDetail;
        private System.Windows.Forms.ToolStripMenuItem MIeditDetail;
        private System.Windows.Forms.ToolStripMenuItem MIdeleteDetail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MIattachments;
        private System.Windows.Forms.BindingSource fIDetailBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailsId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colFIHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDt;
        private DevExpress.XtraGrid.Columns.GridColumn colActionReq;
        private DevExpress.XtraGrid.Columns.GridColumn colActionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsClosed;
        private DevExpress.XtraGrid.Columns.GridColumn colIsFinalized;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailIsDeleted;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mIfinalizeToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPublished;
        private System.Windows.Forms.ToolStripMenuItem MIduplicateDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentDept1;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentDept2;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentDept3;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentUser1;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentUser2;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentUser3;
        private DevExpress.XtraGrid.Columns.GridColumn colFISubId;
        private DevExpress.XtraGrid.Columns.GridColumn colFIId;
    }
}