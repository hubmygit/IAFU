﻿namespace IAFollowUp
{
    partial class ChangeLogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLogView));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.changeLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTbl_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExecStatement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTableName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldNameToShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOldValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcelExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.changeLogBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(784, 379);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // changeLogBindingSource
            // 
            this.changeLogBindingSource.DataSource = typeof(IAFollowUp.ChangeLog);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTbl_Id,
            this.colAppUser,
            this.colDt,
            this.colExecStatement,
            this.colTableName,
            this.colFieldName,
            this.colFieldNameToShow,
            this.colOldValue,
            this.colNewValue,
            this.colSection});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colTbl_Id
            // 
            this.colTbl_Id.Caption = "Table Id";
            this.colTbl_Id.FieldName = "Tbl_Id";
            this.colTbl_Id.Name = "colTbl_Id";
            this.colTbl_Id.Visible = true;
            this.colTbl_Id.VisibleIndex = 0;
            // 
            // colAppUser
            // 
            this.colAppUser.Caption = "App User";
            this.colAppUser.FieldName = "AppUser.FullName";
            this.colAppUser.Name = "colAppUser";
            this.colAppUser.Visible = true;
            this.colAppUser.VisibleIndex = 1;
            // 
            // colDt
            // 
            this.colDt.Caption = "Date";
            this.colDt.FieldName = "Dt";
            this.colDt.Name = "colDt";
            this.colDt.Visible = true;
            this.colDt.VisibleIndex = 2;
            // 
            // colExecStatement
            // 
            this.colExecStatement.Caption = "Exec Statement";
            this.colExecStatement.FieldName = "ExecStatement";
            this.colExecStatement.Name = "colExecStatement";
            this.colExecStatement.Visible = true;
            this.colExecStatement.VisibleIndex = 3;
            // 
            // colTableName
            // 
            this.colTableName.Caption = "Table";
            this.colTableName.FieldName = "TableName";
            this.colTableName.Name = "colTableName";
            this.colTableName.Visible = true;
            this.colTableName.VisibleIndex = 4;
            // 
            // colFieldName
            // 
            this.colFieldName.Caption = "Field";
            this.colFieldName.FieldName = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 5;
            // 
            // colFieldNameToShow
            // 
            this.colFieldNameToShow.Caption = "Field Name";
            this.colFieldNameToShow.FieldName = "FieldNameToShow";
            this.colFieldNameToShow.Name = "colFieldNameToShow";
            this.colFieldNameToShow.Visible = true;
            this.colFieldNameToShow.VisibleIndex = 6;
            // 
            // colOldValue
            // 
            this.colOldValue.Caption = "Old Value";
            this.colOldValue.FieldName = "OldValue";
            this.colOldValue.Name = "colOldValue";
            this.colOldValue.Visible = true;
            this.colOldValue.VisibleIndex = 7;
            // 
            // colNewValue
            // 
            this.colNewValue.Caption = "New Value";
            this.colNewValue.FieldName = "NewValue";
            this.colNewValue.Name = "colNewValue";
            this.colNewValue.Visible = true;
            this.colNewValue.VisibleIndex = 8;
            // 
            // colSection
            // 
            this.colSection.Caption = "Section";
            this.colSection.FieldName = "Section";
            this.colSection.Name = "colSection";
            this.colSection.Visible = true;
            this.colSection.VisibleIndex = 9;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport.Image = global::IAFollowUp.Properties.Resources.ExportToExcel_32x;
            this.btnExcelExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelExport.Location = new System.Drawing.Point(652, 12);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(120, 45);
            this.btnExcelExport.TabIndex = 4;
            this.btnExcelExport.Text = "Export to Excel";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // ChangeLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "ChangeLogView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Change Log";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource changeLogBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTbl_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colAppUser;
        private DevExpress.XtraGrid.Columns.GridColumn colDt;
        private DevExpress.XtraGrid.Columns.GridColumn colExecStatement;
        private DevExpress.XtraGrid.Columns.GridColumn colTableName;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colOldValue;
        private DevExpress.XtraGrid.Columns.GridColumn colNewValue;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldNameToShow;
        private DevExpress.XtraGrid.Columns.GridColumn colSection;
        private System.Windows.Forms.Button btnExcelExport;
    }
}