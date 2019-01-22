namespace IAFollowUp
{
    partial class PlaceholderRoleSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaceholderRoleSelect));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.placeholderRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPlaceholder2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaceholder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaceholder1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.placeholderRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.placeholderRoleBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(27, 61);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(708, 304);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // placeholderRoleBindingSource
            // 
            this.placeholderRoleBindingSource.DataSource = typeof(IAFollowUp.PlaceholderRole);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPlaceholder2,
            this.colPlaceholder,
            this.colPlaceholder1,
            this.colRole,
            this.colRole1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colPlaceholder2
            // 
            this.colPlaceholder2.Caption = "Id";
            this.colPlaceholder2.FieldName = "Placeholder.Id";
            this.colPlaceholder2.Name = "colPlaceholder2";
            // 
            // colPlaceholder
            // 
            this.colPlaceholder.Caption = "Company";
            this.colPlaceholder.FieldName = "Placeholder.Company.Name";
            this.colPlaceholder.Name = "colPlaceholder";
            this.colPlaceholder.Visible = true;
            this.colPlaceholder.VisibleIndex = 0;
            // 
            // colPlaceholder1
            // 
            this.colPlaceholder1.Caption = "Department";
            this.colPlaceholder1.FieldName = "Placeholder.Department.Name";
            this.colPlaceholder1.Name = "colPlaceholder1";
            this.colPlaceholder1.Visible = true;
            this.colPlaceholder1.VisibleIndex = 1;
            // 
            // colRole
            // 
            this.colRole.Caption = "Role Id";
            this.colRole.FieldName = "Role.Id";
            this.colRole.Name = "colRole";
            // 
            // colRole1
            // 
            this.colRole1.Caption = "Role";
            this.colRole1.FieldName = "Role.Name";
            this.colRole1.Name = "colRole1";
            this.colRole1.Visible = true;
            this.colRole1.VisibleIndex = 2;
            // 
            // PlaceholderRoleSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 480);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "PlaceholderRoleSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Role Selection";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.placeholderRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource placeholderRoleBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholder;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholder2;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholder1;
        private DevExpress.XtraGrid.Columns.GridColumn colRole1;
    }
}