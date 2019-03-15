namespace IAFollowUp
{
    partial class AppLogInInfos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppLogInInfos));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.appLogInBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWinUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppUser = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appLogInBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.appLogInBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 92);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(784, 350);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // appLogInBindingSource
            // 
            this.appLogInBindingSource.DataSource = typeof(IAFollowUp.AppLogIn);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colWinUser,
            this.colPcName,
            this.colInsDate,
            this.colExitDate,
            this.colAppUser});
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
            // colWinUser
            // 
            this.colWinUser.FieldName = "WinUser";
            this.colWinUser.Name = "colWinUser";
            this.colWinUser.Visible = true;
            this.colWinUser.VisibleIndex = 1;
            // 
            // colPcName
            // 
            this.colPcName.FieldName = "PcName";
            this.colPcName.Name = "colPcName";
            this.colPcName.Visible = true;
            this.colPcName.VisibleIndex = 2;
            // 
            // colInsDate
            // 
            this.colInsDate.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            this.colInsDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colInsDate.FieldName = "InsDate";
            this.colInsDate.Name = "colInsDate";
            this.colInsDate.Visible = true;
            this.colInsDate.VisibleIndex = 3;
            // 
            // colExitDate
            // 
            this.colExitDate.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            this.colExitDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colExitDate.FieldName = "ExitDate";
            this.colExitDate.Name = "colExitDate";
            this.colExitDate.Visible = true;
            this.colExitDate.VisibleIndex = 4;
            // 
            // colAppUser
            // 
            this.colAppUser.FieldName = "AppUser";
            this.colAppUser.Name = "colAppUser";
            this.colAppUser.Visible = true;
            this.colAppUser.VisibleIndex = 5;
            // 
            // AppLogInInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppLogInInfos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AppLogInInfos";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appLogInBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource appLogInBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colWinUser;
        private DevExpress.XtraGrid.Columns.GridColumn colPcName;
        private DevExpress.XtraGrid.Columns.GridColumn colInsDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAppUser;
    }
}