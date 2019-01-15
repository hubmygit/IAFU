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
            this.colAuditCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderFIId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailActionReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailActionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailIsFinalized = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailFISubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentOwner1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentOwner2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailCurrentOwner3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsDHA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fI_DetailHeaderAuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsDHA;
            this.gridControl1.DataSource = this.fI_DetailHeaderAuditBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 47);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1184, 395);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsDHA
            // 
            this.cmsDHA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIactivity});
            this.cmsDHA.Name = "cmsHeader";
            this.cmsDHA.Size = new System.Drawing.Size(181, 48);
            // 
            // MIactivity
            // 
            this.MIactivity.Name = "MIactivity";
            this.MIactivity.Size = new System.Drawing.Size(180, 22);
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
            this.colAuditCompany,
            this.colAuditYear,
            this.colAuditTitle,
            this.colAuditRef,
            this.colHeaderId,
            this.colHeaderTitle,
            this.colHeaderCategory,
            this.colHeaderFIId,
            this.colDetailId,
            this.colDetailDescription,
            this.colDetailActionDt,
            this.colDetailActionReq,
            this.colDetailActionCode,
            this.colDetailIsFinalized,
            this.colDetailFISubId,
            this.colDetailCurrentOwner1,
            this.colDetailCurrentOwner2,
            this.colDetailCurrentOwner3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colAuditId
            // 
            this.colAuditId.FieldName = "AuditId";
            this.colAuditId.Name = "colAuditId";
            this.colAuditId.Visible = true;
            this.colAuditId.VisibleIndex = 0;
            // 
            // colAuditCompany
            // 
            this.colAuditCompany.FieldName = "AuditCompany";
            this.colAuditCompany.Name = "colAuditCompany";
            this.colAuditCompany.Visible = true;
            this.colAuditCompany.VisibleIndex = 1;
            // 
            // colAuditYear
            // 
            this.colAuditYear.FieldName = "AuditYear";
            this.colAuditYear.Name = "colAuditYear";
            this.colAuditYear.Visible = true;
            this.colAuditYear.VisibleIndex = 2;
            // 
            // colAuditTitle
            // 
            this.colAuditTitle.FieldName = "AuditTitle";
            this.colAuditTitle.Name = "colAuditTitle";
            this.colAuditTitle.Visible = true;
            this.colAuditTitle.VisibleIndex = 3;
            // 
            // colAuditRef
            // 
            this.colAuditRef.FieldName = "AuditRef";
            this.colAuditRef.Name = "colAuditRef";
            this.colAuditRef.Visible = true;
            this.colAuditRef.VisibleIndex = 4;
            // 
            // colHeaderId
            // 
            this.colHeaderId.FieldName = "HeaderId";
            this.colHeaderId.Name = "colHeaderId";
            this.colHeaderId.Visible = true;
            this.colHeaderId.VisibleIndex = 5;
            // 
            // colHeaderTitle
            // 
            this.colHeaderTitle.FieldName = "HeaderTitle";
            this.colHeaderTitle.Name = "colHeaderTitle";
            this.colHeaderTitle.Visible = true;
            this.colHeaderTitle.VisibleIndex = 6;
            // 
            // colHeaderCategory
            // 
            this.colHeaderCategory.FieldName = "HeaderCategory";
            this.colHeaderCategory.Name = "colHeaderCategory";
            this.colHeaderCategory.Visible = true;
            this.colHeaderCategory.VisibleIndex = 7;
            // 
            // colHeaderFIId
            // 
            this.colHeaderFIId.FieldName = "HeaderFIId";
            this.colHeaderFIId.Name = "colHeaderFIId";
            this.colHeaderFIId.Visible = true;
            this.colHeaderFIId.VisibleIndex = 8;
            // 
            // colDetailId
            // 
            this.colDetailId.FieldName = "DetailId";
            this.colDetailId.Name = "colDetailId";
            this.colDetailId.Visible = true;
            this.colDetailId.VisibleIndex = 9;
            // 
            // colDetailDescription
            // 
            this.colDetailDescription.FieldName = "DetailDescription";
            this.colDetailDescription.Name = "colDetailDescription";
            this.colDetailDescription.Visible = true;
            this.colDetailDescription.VisibleIndex = 10;
            // 
            // colDetailActionDt
            // 
            this.colDetailActionDt.FieldName = "DetailActionDt";
            this.colDetailActionDt.Name = "colDetailActionDt";
            this.colDetailActionDt.Visible = true;
            this.colDetailActionDt.VisibleIndex = 11;
            // 
            // colDetailActionReq
            // 
            this.colDetailActionReq.FieldName = "DetailActionReq";
            this.colDetailActionReq.Name = "colDetailActionReq";
            this.colDetailActionReq.Visible = true;
            this.colDetailActionReq.VisibleIndex = 12;
            // 
            // colDetailActionCode
            // 
            this.colDetailActionCode.FieldName = "DetailActionCode";
            this.colDetailActionCode.Name = "colDetailActionCode";
            this.colDetailActionCode.Visible = true;
            this.colDetailActionCode.VisibleIndex = 13;
            // 
            // colDetailIsFinalized
            // 
            this.colDetailIsFinalized.FieldName = "DetailIsFinalized";
            this.colDetailIsFinalized.Name = "colDetailIsFinalized";
            this.colDetailIsFinalized.Visible = true;
            this.colDetailIsFinalized.VisibleIndex = 14;
            // 
            // colDetailFISubId
            // 
            this.colDetailFISubId.FieldName = "DetailFISubId";
            this.colDetailFISubId.Name = "colDetailFISubId";
            this.colDetailFISubId.Visible = true;
            this.colDetailFISubId.VisibleIndex = 15;
            // 
            // colDetailCurrentOwner1
            // 
            this.colDetailCurrentOwner1.FieldName = "DetailCurrentOwner1";
            this.colDetailCurrentOwner1.Name = "colDetailCurrentOwner1";
            this.colDetailCurrentOwner1.Visible = true;
            this.colDetailCurrentOwner1.VisibleIndex = 16;
            // 
            // colDetailCurrentOwner2
            // 
            this.colDetailCurrentOwner2.FieldName = "DetailCurrentOwner2";
            this.colDetailCurrentOwner2.Name = "colDetailCurrentOwner2";
            this.colDetailCurrentOwner2.Visible = true;
            this.colDetailCurrentOwner2.VisibleIndex = 17;
            // 
            // colDetailCurrentOwner3
            // 
            this.colDetailCurrentOwner3.FieldName = "DetailCurrentOwner3";
            this.colDetailCurrentOwner3.Name = "colDetailCurrentOwner3";
            this.colDetailCurrentOwner3.Visible = true;
            this.colDetailCurrentOwner3.VisibleIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Grouping...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FIView_Auditees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 442);
            this.Controls.Add(this.button1);
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
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ContextMenuStrip cmsDHA;
        private System.Windows.Forms.ToolStripMenuItem MIactivity;
    }
}