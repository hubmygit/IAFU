namespace IafuAlerts
{
    partial class CheckResults01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckResults01));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.checkResultsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colfullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colemail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcnt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colccfullNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colccEmails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbody = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotify = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkResultsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.checkResultsBindingSource1;
            this.gridControl1.Location = new System.Drawing.Point(0, 67);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(784, 375);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // checkResultsBindingSource1
            // 
            this.checkResultsBindingSource1.DataSource = typeof(IafuAlerts.CheckResults);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colfullName,
            this.colemail,
            this.colcnt,
            this.colccfullNames,
            this.colccEmails,
            this.colbody,
            this.colnotify});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colfullName
            // 
            this.colfullName.Caption = "Full Name";
            this.colfullName.FieldName = "fullName";
            this.colfullName.Name = "colfullName";
            this.colfullName.Visible = true;
            this.colfullName.VisibleIndex = 0;
            // 
            // colemail
            // 
            this.colemail.Caption = "Email Address";
            this.colemail.FieldName = "email";
            this.colemail.Name = "colemail";
            this.colemail.Visible = true;
            this.colemail.VisibleIndex = 1;
            // 
            // colcnt
            // 
            this.colcnt.Caption = "Counter";
            this.colcnt.FieldName = "cnt";
            this.colcnt.Name = "colcnt";
            this.colcnt.Visible = true;
            this.colcnt.VisibleIndex = 2;
            // 
            // colccfullNames
            // 
            this.colccfullNames.Caption = "Full Names";
            this.colccfullNames.FieldName = "ccfullNames";
            this.colccfullNames.Name = "colccfullNames";
            this.colccfullNames.Visible = true;
            this.colccfullNames.VisibleIndex = 3;
            // 
            // colccEmails
            // 
            this.colccEmails.Caption = "Email Addresses";
            this.colccEmails.FieldName = "ccEmails";
            this.colccEmails.Name = "colccEmails";
            this.colccEmails.Visible = true;
            this.colccEmails.VisibleIndex = 4;
            // 
            // colbody
            // 
            this.colbody.Caption = "Email Body";
            this.colbody.FieldName = "body";
            this.colbody.Name = "colbody";
            this.colbody.Visible = true;
            this.colbody.VisibleIndex = 5;
            // 
            // colnotify
            // 
            this.colnotify.FieldName = "notify";
            this.colnotify.Name = "colnotify";
            this.colnotify.Visible = true;
            this.colnotify.VisibleIndex = 6;
            // 
            // CheckResults01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckResults01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CheckResults01";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkResultsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colfullName;
        private DevExpress.XtraGrid.Columns.GridColumn colemail;
        private DevExpress.XtraGrid.Columns.GridColumn colcnt;
        private System.Windows.Forms.BindingSource checkResultsBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colccfullNames;
        private DevExpress.XtraGrid.Columns.GridColumn colccEmails;
        private DevExpress.XtraGrid.Columns.GridColumn colbody;
        private DevExpress.XtraGrid.Columns.GridColumn colnotify;
    }
}