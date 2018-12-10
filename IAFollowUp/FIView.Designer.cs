﻿namespace IAFollowUp
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIView));
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
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFICategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPublished = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblHeaders = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.gridControlDetails = new DevExpress.XtraGrid.GridControl();
            this.cmsDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIeditDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.MIdeleteDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MIattachments = new System.Windows.Forms.ToolStripMenuItem();
            this.fIDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFIHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsClosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsFinalized = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHeaders)).BeginInit();
            this.cmsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fIHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHeaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetails)).BeginInit();
            this.cmsDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateNewHeader
            // 
            this.btnCreateNewHeader.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnCreateNewHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewHeader.Location = new System.Drawing.Point(0, 102);
            this.btnCreateNewHeader.Name = "btnCreateNewHeader";
            this.btnCreateNewHeader.Size = new System.Drawing.Size(100, 30);
            this.btnCreateNewHeader.TabIndex = 36;
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
            this.btnCreateNewDetail.TabIndex = 37;
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
            this.txtCompany.TabIndex = 69;
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
            this.txtAuditTitle.TabIndex = 66;
            // 
            // lblAuditTitle
            // 
            this.lblAuditTitle.AutoSize = true;
            this.lblAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditTitle.Location = new System.Drawing.Point(11, 51);
            this.lblAuditTitle.Name = "lblAuditTitle";
            this.lblAuditTitle.Size = new System.Drawing.Size(67, 16);
            this.lblAuditTitle.TabIndex = 68;
            this.lblAuditTitle.Text = "Audit Title";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(12, 9);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 16);
            this.lblCompany.TabIndex = 67;
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
            this.txtYear.TabIndex = 71;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblYear.Location = new System.Drawing.Point(729, 9);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 16);
            this.lblYear.TabIndex = 70;
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
            this.gridControlHeaders.Size = new System.Drawing.Size(984, 200);
            this.gridControlHeaders.TabIndex = 72;
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
            this.colTitle,
            this.colFICategory,
            this.colIsDeleted,
            this.colIsPublished});
            this.gridViewHeaders.GridControl = this.gridControlHeaders;
            this.gridViewHeaders.Name = "gridViewHeaders";
            this.gridViewHeaders.OptionsBehavior.Editable = false;
            this.gridViewHeaders.OptionsBehavior.ReadOnly = true;
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
            // colTitle
            // 
            this.colTitle.Caption = "Title";
            this.colTitle.FieldName = "Title";
            this.colTitle.MinWidth = 200;
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 220;
            // 
            // colFICategory
            // 
            this.colFICategory.Caption = "Category";
            this.colFICategory.FieldName = "FICategory.Name";
            this.colFICategory.MinWidth = 200;
            this.colFICategory.Name = "colFICategory";
            this.colFICategory.Visible = true;
            this.colFICategory.VisibleIndex = 1;
            this.colFICategory.Width = 200;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.FieldName = "IsDeleted";
            this.colIsDeleted.Name = "colIsDeleted";
            // 
            // colIsPublished
            // 
            this.colIsPublished.FieldName = "IsPublished";
            this.colIsPublished.Name = "colIsPublished";
            // 
            // lblHeaders
            // 
            this.lblHeaders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeaders.AutoSize = true;
            this.lblHeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeaders.Location = new System.Drawing.Point(442, 102);
            this.lblHeaders.Name = "lblHeaders";
            this.lblHeaders.Size = new System.Drawing.Size(100, 25);
            this.lblHeaders.TabIndex = 73;
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
            this.lblDetails.TabIndex = 74;
            this.lblDetails.Text = "Details";
            // 
            // gridControlDetails
            // 
            this.gridControlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDetails.ContextMenuStrip = this.cmsDetail;
            this.gridControlDetails.DataSource = this.fIDetailBindingSource;
            gridLevelNode1.RelationName = "Owners";
            this.gridControlDetails.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlDetails.Location = new System.Drawing.Point(0, 387);
            this.gridControlDetails.MainView = this.gridViewDetails;
            this.gridControlDetails.Name = "gridControlDetails";
            this.gridControlDetails.Size = new System.Drawing.Size(984, 200);
            this.gridControlDetails.TabIndex = 75;
            this.gridControlDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetails});
            // 
            // cmsDetail
            // 
            this.cmsDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIeditDetail,
            this.MIdeleteDetail,
            this.toolStripSeparator1,
            this.MIattachments});
            this.cmsDetail.Name = "cmsHeader";
            this.cmsDetail.Size = new System.Drawing.Size(181, 98);
            // 
            // MIeditDetail
            // 
            this.MIeditDetail.Name = "MIeditDetail";
            this.MIeditDetail.Size = new System.Drawing.Size(180, 22);
            this.MIeditDetail.Text = "Edit";
            this.MIeditDetail.Click += new System.EventHandler(this.MIeditDetail_Click);
            // 
            // MIdeleteDetail
            // 
            this.MIdeleteDetail.Name = "MIdeleteDetail";
            this.MIdeleteDetail.Size = new System.Drawing.Size(180, 22);
            this.MIdeleteDetail.Text = "Delete";
            this.MIdeleteDetail.Click += new System.EventHandler(this.MIdeleteDetail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MIattachments
            // 
            this.MIattachments.Name = "MIattachments";
            this.MIattachments.Size = new System.Drawing.Size(180, 22);
            this.MIattachments.Text = "Attachments";
            // 
            // fIDetailBindingSource
            // 
            this.fIDetailBindingSource.DataSource = typeof(IAFollowUp.FIDetail);
            // 
            // gridViewDetails
            // 
            this.gridViewDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId1,
            this.colDescription,
            this.colFIHeaderId,
            this.colActionDt,
            this.colActionReq,
            this.colActionCode,
            this.colIsClosed,
            this.colIsFinalized,
            this.colIsDeleted1});
            this.gridViewDetails.GridControl = this.gridControlDetails;
            this.gridViewDetails.Name = "gridViewDetails";
            this.gridViewDetails.OptionsBehavior.Editable = false;
            this.gridViewDetails.OptionsBehavior.ReadOnly = true;
            // 
            // colId1
            // 
            this.colId1.FieldName = "Id";
            this.colId1.Name = "colId1";
            this.colId1.Visible = true;
            this.colId1.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colFIHeaderId
            // 
            this.colFIHeaderId.FieldName = "FIHeaderId";
            this.colFIHeaderId.Name = "colFIHeaderId";
            this.colFIHeaderId.Visible = true;
            this.colFIHeaderId.VisibleIndex = 2;
            // 
            // colActionDt
            // 
            this.colActionDt.FieldName = "ActionDt";
            this.colActionDt.Name = "colActionDt";
            this.colActionDt.Visible = true;
            this.colActionDt.VisibleIndex = 3;
            // 
            // colActionReq
            // 
            this.colActionReq.FieldName = "ActionReq";
            this.colActionReq.Name = "colActionReq";
            this.colActionReq.Visible = true;
            this.colActionReq.VisibleIndex = 4;
            // 
            // colActionCode
            // 
            this.colActionCode.FieldName = "ActionCode";
            this.colActionCode.Name = "colActionCode";
            this.colActionCode.Visible = true;
            this.colActionCode.VisibleIndex = 5;
            // 
            // colIsClosed
            // 
            this.colIsClosed.FieldName = "IsClosed";
            this.colIsClosed.Name = "colIsClosed";
            this.colIsClosed.Visible = true;
            this.colIsClosed.VisibleIndex = 6;
            // 
            // colIsFinalized
            // 
            this.colIsFinalized.FieldName = "IsFinalized";
            this.colIsFinalized.Name = "colIsFinalized";
            this.colIsFinalized.Visible = true;
            this.colIsFinalized.VisibleIndex = 7;
            // 
            // colIsDeleted1
            // 
            this.colIsDeleted1.FieldName = "IsDeleted";
            this.colIsDeleted1.Name = "colIsDeleted1";
            this.colIsDeleted1.Visible = true;
            this.colIsDeleted1.VisibleIndex = 8;
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHeaders)).EndInit();
            this.cmsHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fIHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHeaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetails)).EndInit();
            this.cmsDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetails)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colIsPublished;
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
        private DevExpress.XtraGrid.Columns.GridColumn colId1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colFIHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDt;
        private DevExpress.XtraGrid.Columns.GridColumn colActionReq;
        private DevExpress.XtraGrid.Columns.GridColumn colActionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsClosed;
        private DevExpress.XtraGrid.Columns.GridColumn colIsFinalized;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted1;
    }
}