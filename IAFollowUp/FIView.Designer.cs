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
            this.btnCreateNewHeader = new System.Windows.Forms.Button();
            this.btnCreateNewDetail = new System.Windows.Forms.Button();
            this.btnUpdateDetail = new System.Windows.Forms.Button();
            this.btnDeleteDetail = new System.Windows.Forms.Button();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtAuditTitle = new System.Windows.Forms.TextBox();
            this.lblAuditTitle = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.gridControlHeaders = new DevExpress.XtraGrid.GridControl();
            this.fIHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewHeaders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFICategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPublished = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblHeaders = new System.Windows.Forms.Label();
            this.cmsHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIeditHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.MIdeleteHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDetails = new System.Windows.Forms.Label();
            this.gridControlDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmsDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIeditDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.MIdeleteDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MIattachments = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHeaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHeaders)).BeginInit();
            this.cmsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetails)).BeginInit();
            this.cmsDetail.SuspendLayout();
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
            // 
            // btnUpdateDetail
            // 
            this.btnUpdateDetail.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnUpdateDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateDetail.Location = new System.Drawing.Point(738, 354);
            this.btnUpdateDetail.Name = "btnUpdateDetail";
            this.btnUpdateDetail.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateDetail.TabIndex = 39;
            this.btnUpdateDetail.Text = "Upd Detail";
            this.btnUpdateDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateDetail.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnDeleteDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDetail.Location = new System.Drawing.Point(864, 354);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteDetail.TabIndex = 41;
            this.btnDeleteDetail.Text = "Del Detail";
            this.btnDeleteDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
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
            this.txtAuditTitle.Size = new System.Drawing.Size(850, 50);
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
            this.txtYear.Location = new System.Drawing.Point(734, 6);
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
            this.lblYear.Location = new System.Drawing.Point(691, 9);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 16);
            this.lblYear.TabIndex = 70;
            this.lblYear.Text = "Year";
            // 
            // gridControlHeaders
            // 
            this.gridControlHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlHeaders.DataSource = this.fIHeaderBindingSource;
            this.gridControlHeaders.Location = new System.Drawing.Point(0, 135);
            this.gridControlHeaders.MainView = this.gridViewHeaders;
            this.gridControlHeaders.Name = "gridControlHeaders";
            this.gridControlHeaders.Size = new System.Drawing.Size(984, 200);
            this.gridControlHeaders.TabIndex = 72;
            this.gridControlHeaders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHeaders});
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
            this.colTitle.Width = 200;
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
            this.gridControlDetails.DataSource = this.fIHeaderBindingSource;
            this.gridControlDetails.Location = new System.Drawing.Point(0, 387);
            this.gridControlDetails.MainView = this.gridViewDetails;
            this.gridControlDetails.Name = "gridControlDetails";
            this.gridControlDetails.Size = new System.Drawing.Size(984, 200);
            this.gridControlDetails.TabIndex = 75;
            this.gridControlDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetails});
            // 
            // gridViewDetails
            // 
            this.gridViewDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridViewDetails.GridControl = this.gridControlDetails;
            this.gridViewDetails.Name = "gridViewDetails";
            this.gridViewDetails.OptionsBehavior.Editable = false;
            this.gridViewDetails.OptionsBehavior.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "AuditId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Title";
            this.gridColumn3.FieldName = "Title";
            this.gridColumn3.MinWidth = 200;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 200;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Category";
            this.gridColumn4.FieldName = "FICategory.Name";
            this.gridColumn4.MinWidth = 200;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 200;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "IsDeleted";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.FieldName = "IsPublished";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // cmsDetail
            // 
            this.cmsDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIeditDetail,
            this.MIdeleteDetail,
            this.toolStripSeparator1,
            this.MIattachments});
            this.cmsDetail.Name = "cmsHeader";
            this.cmsDetail.Size = new System.Drawing.Size(143, 76);
            // 
            // MIeditDetail
            // 
            this.MIeditDetail.Name = "MIeditDetail";
            this.MIeditDetail.Size = new System.Drawing.Size(142, 22);
            this.MIeditDetail.Text = "Edit";
            // 
            // MIdeleteDetail
            // 
            this.MIdeleteDetail.Name = "MIdeleteDetail";
            this.MIdeleteDetail.Size = new System.Drawing.Size(142, 22);
            this.MIdeleteDetail.Text = "Delete";
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
            this.Controls.Add(this.btnDeleteDetail);
            this.Controls.Add(this.btnUpdateDetail);
            this.Controls.Add(this.btnCreateNewDetail);
            this.Controls.Add(this.btnCreateNewHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 625);
            this.Name = "FIView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements View";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHeaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHeaders)).EndInit();
            this.cmsHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetails)).EndInit();
            this.cmsDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreateNewHeader;
        private System.Windows.Forms.Button btnCreateNewDetail;
        private System.Windows.Forms.Button btnUpdateDetail;
        private System.Windows.Forms.Button btnDeleteDetail;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        public System.Windows.Forms.ContextMenuStrip cmsDetail;
        private System.Windows.Forms.ToolStripMenuItem MIeditDetail;
        private System.Windows.Forms.ToolStripMenuItem MIdeleteDetail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MIattachments;
    }
}