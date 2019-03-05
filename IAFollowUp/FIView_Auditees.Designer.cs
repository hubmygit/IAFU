﻿namespace IAFollowUp
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
            this.cmsDHA = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIactivity = new System.Windows.Forms.ToolStripMenuItem();
            this.fI_DetailHeaderAuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAuditId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionSide1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderCategory1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderFIId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailFISubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colAuditAuditor1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditAuditor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditSupervisor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailActionReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailActionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentDept1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentOwner1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentDept2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentOwner2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentDept3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentOwner3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailIsFinalized = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionSide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chbMine = new System.Windows.Forms.CheckBox();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.lblIssuesAll = new System.Windows.Forms.Label();
            this.lblIssuesAllCnt = new System.Windows.Forms.Label();
            this.lblIssuesOpenCnt = new System.Windows.Forms.Label();
            this.lblIssuesMyCnt = new System.Windows.Forms.Label();
            this.lblIssuesOpen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsDHA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fI_DetailHeaderAuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsDHA;
            this.gridControl1.DataSource = this.fI_DetailHeaderAuditBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1184, 379);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsDHA
            // 
            this.cmsDHA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIactivity});
            this.cmsDHA.Name = "cmsHeader";
            this.cmsDHA.Size = new System.Drawing.Size(115, 26);
            // 
            // MIactivity
            // 
            this.MIactivity.Name = "MIactivity";
            this.MIactivity.Size = new System.Drawing.Size(114, 22);
            this.MIactivity.Text = "Activity";
            this.MIactivity.Click += new System.EventHandler(this.MIactivity_Click);
            // 
            // fI_DetailHeaderAuditBindingSource
            // 
            this.fI_DetailHeaderAuditBindingSource.DataSource = typeof(IAFollowUp.FI_DetailHeaderAudit);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAuditId,
            this.colHeaderId,
            this.colDetailId,
            this.colActionSide1,
            this.colHeaderCategory1,
            this.colAuditCompany,
            this.colAuditYear,
            this.colAuditRef,
            this.colHeaderFIId,
            this.colDetailFISubId,
            this.colAuditTitle,
            this.colAuditAuditor1,
            this.colAuditAuditor2,
            this.colAuditSupervisor,
            this.colHeaderTitle,
            this.colHeaderCategory,
            this.colDetailDescription,
            this.colDetailActionDt,
            this.colDetailActionReq,
            this.colDetailActionCode,
            this.colDetailCurrentDept1,
            this.colDetailCurrentOwner1,
            this.colDetailCurrentDept2,
            this.colDetailCurrentOwner2,
            this.colDetailCurrentDept3,
            this.colDetailCurrentOwner3,
            this.colDetailIsFinalized,
            this.colActionSide});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            // 
            // colAuditId
            // 
            this.colAuditId.FieldName = "AuditId";
            this.colAuditId.Name = "colAuditId";
            this.colAuditId.Visible = true;
            this.colAuditId.VisibleIndex = 23;
            this.colAuditId.Width = 80;
            // 
            // colHeaderId
            // 
            this.colHeaderId.FieldName = "HeaderId";
            this.colHeaderId.Name = "colHeaderId";
            this.colHeaderId.Visible = true;
            this.colHeaderId.VisibleIndex = 24;
            // 
            // colDetailId
            // 
            this.colDetailId.FieldName = "DetailId";
            this.colDetailId.Name = "colDetailId";
            this.colDetailId.Visible = true;
            this.colDetailId.VisibleIndex = 25;
            // 
            // colActionSide1
            // 
            this.colActionSide1.FieldName = "ActionSide.Id";
            this.colActionSide1.Name = "colActionSide1";
            // 
            // colHeaderCategory1
            // 
            this.colHeaderCategory1.FieldName = "HeaderCategory.Id";
            this.colHeaderCategory1.Name = "colHeaderCategory1";
            // 
            // colAuditCompany
            // 
            this.colAuditCompany.Caption = "Company";
            this.colAuditCompany.FieldName = "AuditCompany.Name";
            this.colAuditCompany.Name = "colAuditCompany";
            this.colAuditCompany.Visible = true;
            this.colAuditCompany.VisibleIndex = 0;
            this.colAuditCompany.Width = 54;
            // 
            // colAuditYear
            // 
            this.colAuditYear.Caption = "Year";
            this.colAuditYear.FieldName = "AuditYear";
            this.colAuditYear.MaxWidth = 50;
            this.colAuditYear.Name = "colAuditYear";
            this.colAuditYear.Visible = true;
            this.colAuditYear.VisibleIndex = 1;
            this.colAuditYear.Width = 36;
            // 
            // colAuditRef
            // 
            this.colAuditRef.Caption = "AuditRef";
            this.colAuditRef.FieldName = "AuditRef";
            this.colAuditRef.MaxWidth = 140;
            this.colAuditRef.Name = "colAuditRef";
            this.colAuditRef.Visible = true;
            this.colAuditRef.VisibleIndex = 2;
            this.colAuditRef.Width = 100;
            // 
            // colHeaderFIId
            // 
            this.colHeaderFIId.Caption = "FIId";
            this.colHeaderFIId.FieldName = "HeaderFIId";
            this.colHeaderFIId.MaxWidth = 50;
            this.colHeaderFIId.Name = "colHeaderFIId";
            this.colHeaderFIId.Visible = true;
            this.colHeaderFIId.VisibleIndex = 3;
            this.colHeaderFIId.Width = 50;
            // 
            // colDetailFISubId
            // 
            this.colDetailFISubId.Caption = "FISubId";
            this.colDetailFISubId.FieldName = "DetailFISubId";
            this.colDetailFISubId.MaxWidth = 50;
            this.colDetailFISubId.Name = "colDetailFISubId";
            this.colDetailFISubId.Visible = true;
            this.colDetailFISubId.VisibleIndex = 4;
            this.colDetailFISubId.Width = 50;
            // 
            // colAuditTitle
            // 
            this.colAuditTitle.Caption = "Audit Title";
            this.colAuditTitle.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colAuditTitle.FieldName = "AuditTitle";
            this.colAuditTitle.Name = "colAuditTitle";
            this.colAuditTitle.Visible = true;
            this.colAuditTitle.VisibleIndex = 5;
            this.colAuditTitle.Width = 140;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colAuditAuditor1
            // 
            this.colAuditAuditor1.Caption = "Auditor1";
            this.colAuditAuditor1.FieldName = "AuditAuditor1.FullName";
            this.colAuditAuditor1.MaxWidth = 200;
            this.colAuditAuditor1.Name = "colAuditAuditor1";
            this.colAuditAuditor1.Visible = true;
            this.colAuditAuditor1.VisibleIndex = 6;
            this.colAuditAuditor1.Width = 90;
            // 
            // colAuditAuditor2
            // 
            this.colAuditAuditor2.Caption = "Auditor2";
            this.colAuditAuditor2.FieldName = "AuditAuditor2.FullName";
            this.colAuditAuditor2.MaxWidth = 200;
            this.colAuditAuditor2.Name = "colAuditAuditor2";
            this.colAuditAuditor2.Visible = true;
            this.colAuditAuditor2.VisibleIndex = 7;
            this.colAuditAuditor2.Width = 90;
            // 
            // colAuditSupervisor
            // 
            this.colAuditSupervisor.Caption = "Supervisor";
            this.colAuditSupervisor.FieldName = "AuditSupervisor.FullName";
            this.colAuditSupervisor.MaxWidth = 200;
            this.colAuditSupervisor.Name = "colAuditSupervisor";
            this.colAuditSupervisor.Visible = true;
            this.colAuditSupervisor.VisibleIndex = 8;
            this.colAuditSupervisor.Width = 90;
            // 
            // colHeaderTitle
            // 
            this.colHeaderTitle.Caption = "Header Title";
            this.colHeaderTitle.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colHeaderTitle.FieldName = "HeaderTitle";
            this.colHeaderTitle.Name = "colHeaderTitle";
            this.colHeaderTitle.Visible = true;
            this.colHeaderTitle.VisibleIndex = 9;
            this.colHeaderTitle.Width = 140;
            // 
            // colHeaderCategory
            // 
            this.colHeaderCategory.Caption = "Header Category";
            this.colHeaderCategory.FieldName = "HeaderCategory.Name";
            this.colHeaderCategory.MaxWidth = 150;
            this.colHeaderCategory.Name = "colHeaderCategory";
            this.colHeaderCategory.Visible = true;
            this.colHeaderCategory.VisibleIndex = 10;
            this.colHeaderCategory.Width = 65;
            // 
            // colDetailDescription
            // 
            this.colDetailDescription.Caption = "Detail Description";
            this.colDetailDescription.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDetailDescription.FieldName = "DetailDescription";
            this.colDetailDescription.Name = "colDetailDescription";
            this.colDetailDescription.Visible = true;
            this.colDetailDescription.VisibleIndex = 11;
            this.colDetailDescription.Width = 180;
            // 
            // colDetailActionDt
            // 
            this.colDetailActionDt.Caption = "Action Date";
            this.colDetailActionDt.FieldName = "DetailActionDt";
            this.colDetailActionDt.MaxWidth = 70;
            this.colDetailActionDt.Name = "colDetailActionDt";
            this.colDetailActionDt.Visible = true;
            this.colDetailActionDt.VisibleIndex = 12;
            this.colDetailActionDt.Width = 55;
            // 
            // colDetailActionReq
            // 
            this.colDetailActionReq.Caption = "Action Required";
            this.colDetailActionReq.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDetailActionReq.FieldName = "DetailActionReq";
            this.colDetailActionReq.Name = "colDetailActionReq";
            this.colDetailActionReq.Visible = true;
            this.colDetailActionReq.VisibleIndex = 13;
            this.colDetailActionReq.Width = 180;
            // 
            // colDetailActionCode
            // 
            this.colDetailActionCode.Caption = "Action Code";
            this.colDetailActionCode.FieldName = "DetailActionCode";
            this.colDetailActionCode.MaxWidth = 70;
            this.colDetailActionCode.Name = "colDetailActionCode";
            this.colDetailActionCode.Visible = true;
            this.colDetailActionCode.VisibleIndex = 14;
            this.colDetailActionCode.Width = 50;
            // 
            // colDetailCurrentDept1
            // 
            this.colDetailCurrentDept1.Caption = "Owner Role1";
            this.colDetailCurrentDept1.FieldName = "DetailCurrentOwner1.Placeholder.Department.Name";
            this.colDetailCurrentDept1.MaxWidth = 200;
            this.colDetailCurrentDept1.Name = "colDetailCurrentDept1";
            this.colDetailCurrentDept1.Visible = true;
            this.colDetailCurrentDept1.VisibleIndex = 15;
            // 
            // colDetailCurrentOwner1
            // 
            this.colDetailCurrentOwner1.Caption = "Owner1";
            this.colDetailCurrentOwner1.FieldName = "DetailCurrentOwner1.User.FullName";
            this.colDetailCurrentOwner1.MaxWidth = 200;
            this.colDetailCurrentOwner1.Name = "colDetailCurrentOwner1";
            this.colDetailCurrentOwner1.Visible = true;
            this.colDetailCurrentOwner1.VisibleIndex = 16;
            // 
            // colDetailCurrentDept2
            // 
            this.colDetailCurrentDept2.Caption = "Owner Role2";
            this.colDetailCurrentDept2.FieldName = "DetailCurrentOwner2.Placeholder.Department.Name";
            this.colDetailCurrentDept2.MaxWidth = 200;
            this.colDetailCurrentDept2.Name = "colDetailCurrentDept2";
            this.colDetailCurrentDept2.Visible = true;
            this.colDetailCurrentDept2.VisibleIndex = 17;
            // 
            // colDetailCurrentOwner2
            // 
            this.colDetailCurrentOwner2.Caption = "Owner2";
            this.colDetailCurrentOwner2.FieldName = "DetailCurrentOwner2.User.FullName";
            this.colDetailCurrentOwner2.MaxWidth = 200;
            this.colDetailCurrentOwner2.Name = "colDetailCurrentOwner2";
            this.colDetailCurrentOwner2.Visible = true;
            this.colDetailCurrentOwner2.VisibleIndex = 18;
            // 
            // colDetailCurrentDept3
            // 
            this.colDetailCurrentDept3.Caption = "Owner Role3";
            this.colDetailCurrentDept3.FieldName = "DetailCurrentOwner3.Placeholder.Department.Name";
            this.colDetailCurrentDept3.MaxWidth = 200;
            this.colDetailCurrentDept3.Name = "colDetailCurrentDept3";
            this.colDetailCurrentDept3.Visible = true;
            this.colDetailCurrentDept3.VisibleIndex = 19;
            // 
            // colDetailCurrentOwner3
            // 
            this.colDetailCurrentOwner3.Caption = "Owner3";
            this.colDetailCurrentOwner3.FieldName = "DetailCurrentOwner3.User.FullName";
            this.colDetailCurrentOwner3.MaxWidth = 200;
            this.colDetailCurrentOwner3.Name = "colDetailCurrentOwner3";
            this.colDetailCurrentOwner3.Visible = true;
            this.colDetailCurrentOwner3.VisibleIndex = 20;
            // 
            // colDetailIsFinalized
            // 
            this.colDetailIsFinalized.Caption = "Finalized";
            this.colDetailIsFinalized.FieldName = "DetailIsFinalized";
            this.colDetailIsFinalized.MaxWidth = 50;
            this.colDetailIsFinalized.Name = "colDetailIsFinalized";
            this.colDetailIsFinalized.Visible = true;
            this.colDetailIsFinalized.VisibleIndex = 21;
            this.colDetailIsFinalized.Width = 50;
            // 
            // colActionSide
            // 
            this.colActionSide.Caption = "ActionSide";
            this.colActionSide.FieldName = "ActionSide.Name";
            this.colActionSide.Name = "colActionSide";
            this.colActionSide.Visible = true;
            this.colActionSide.VisibleIndex = 22;
            this.colActionSide.Width = 70;
            // 
            // chbMine
            // 
            this.chbMine.AutoSize = true;
            this.chbMine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbMine.Location = new System.Drawing.Point(424, 25);
            this.chbMine.Name = "chbMine";
            this.chbMine.Size = new System.Drawing.Size(140, 20);
            this.chbMine.TabIndex = 1;
            this.chbMine.Text = "My Pending Issues";
            this.chbMine.UseVisualStyleBackColor = true;
            this.chbMine.CheckedChanged += new System.EventHandler(this.chbMine_CheckedChanged);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport.Image = global::IAFollowUp.Properties.Resources.ExportToExcel_32x;
            this.btnExcelExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelExport.Location = new System.Drawing.Point(1052, 12);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(120, 45);
            this.btnExcelExport.TabIndex = 4;
            this.btnExcelExport.Text = "Export to Excel";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // lblIssuesAll
            // 
            this.lblIssuesAll.AutoSize = true;
            this.lblIssuesAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblIssuesAll.Location = new System.Drawing.Point(12, 26);
            this.lblIssuesAll.Name = "lblIssuesAll";
            this.lblIssuesAll.Size = new System.Drawing.Size(65, 16);
            this.lblIssuesAll.TabIndex = 5;
            this.lblIssuesAll.Text = "All Issues";
            // 
            // lblIssuesAllCnt
            // 
            this.lblIssuesAllCnt.AutoSize = true;
            this.lblIssuesAllCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblIssuesAllCnt.ForeColor = System.Drawing.Color.Green;
            this.lblIssuesAllCnt.Location = new System.Drawing.Point(83, 23);
            this.lblIssuesAllCnt.Name = "lblIssuesAllCnt";
            this.lblIssuesAllCnt.Size = new System.Drawing.Size(19, 20);
            this.lblIssuesAllCnt.TabIndex = 6;
            this.lblIssuesAllCnt.Text = "0";
            // 
            // lblIssuesOpenCnt
            // 
            this.lblIssuesOpenCnt.AutoSize = true;
            this.lblIssuesOpenCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblIssuesOpenCnt.ForeColor = System.Drawing.Color.Green;
            this.lblIssuesOpenCnt.Location = new System.Drawing.Point(305, 23);
            this.lblIssuesOpenCnt.Name = "lblIssuesOpenCnt";
            this.lblIssuesOpenCnt.Size = new System.Drawing.Size(19, 20);
            this.lblIssuesOpenCnt.TabIndex = 7;
            this.lblIssuesOpenCnt.Text = "0";
            // 
            // lblIssuesMyCnt
            // 
            this.lblIssuesMyCnt.AutoSize = true;
            this.lblIssuesMyCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblIssuesMyCnt.ForeColor = System.Drawing.Color.Green;
            this.lblIssuesMyCnt.Location = new System.Drawing.Point(570, 23);
            this.lblIssuesMyCnt.Name = "lblIssuesMyCnt";
            this.lblIssuesMyCnt.Size = new System.Drawing.Size(19, 20);
            this.lblIssuesMyCnt.TabIndex = 8;
            this.lblIssuesMyCnt.Text = "0";
            // 
            // lblIssuesOpen
            // 
            this.lblIssuesOpen.AutoSize = true;
            this.lblIssuesOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblIssuesOpen.Location = new System.Drawing.Point(216, 26);
            this.lblIssuesOpen.Name = "lblIssuesOpen";
            this.lblIssuesOpen.Size = new System.Drawing.Size(83, 16);
            this.lblIssuesOpen.TabIndex = 9;
            this.lblIssuesOpen.Text = "Open Issues";
            // 
            // FIView_Auditees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 442);
            this.Controls.Add(this.lblIssuesOpen);
            this.Controls.Add(this.lblIssuesMyCnt);
            this.Controls.Add(this.lblIssuesOpenCnt);
            this.Controls.Add(this.lblIssuesAllCnt);
            this.Controls.Add(this.lblIssuesAll);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.chbMine);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "FIView_Auditees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsDHA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fI_DetailHeaderAuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource fI_DetailHeaderAuditBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditId;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditYear;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditRef;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderFIId;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailId;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailActionDt;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailActionReq;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailActionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailIsFinalized;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailFISubId;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailCurrentOwner1;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailCurrentOwner2;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailCurrentOwner3;
        public System.Windows.Forms.ContextMenuStrip cmsDHA;
        private System.Windows.Forms.ToolStripMenuItem MIactivity;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailCurrentDept1;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailCurrentDept2;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailCurrentDept3;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditAuditor1;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditAuditor2;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditSupervisor;
        private System.Windows.Forms.CheckBox chbMine;
        private DevExpress.XtraGrid.Columns.GridColumn colActionSide;
        private DevExpress.XtraGrid.Columns.GridColumn colActionSide1;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderCategory1;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Label lblIssuesAll;
        private System.Windows.Forms.Label lblIssuesAllCnt;
        private System.Windows.Forms.Label lblIssuesOpenCnt;
        private System.Windows.Forms.Label lblIssuesMyCnt;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.Label lblIssuesOpen;
    }
}