namespace IAFollowUp
{
    partial class NotifInactive15Days
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifInactive15Days));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.notif1ObjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupervisor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor1Idle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditor2Idle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupervisorIdle = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notif1ObjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.notif1ObjBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 66);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(784, 376);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // notif1ObjBindingSource
            // 
            this.notif1ObjBindingSource.DataSource = typeof(IAFollowUp.Notif1Obj);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailId,
            this.colActionDt,
            this.colAuditor1,
            this.colAuditor1Idle,
            this.colAuditor2,
            this.colAuditor2Idle,
            this.colSupervisor,
            this.colSupervisorIdle});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colDetailId
            // 
            this.colDetailId.FieldName = "DetailId";
            this.colDetailId.Name = "colDetailId";
            this.colDetailId.Visible = true;
            this.colDetailId.VisibleIndex = 0;
            // 
            // colActionDt
            // 
            this.colActionDt.Caption = "Action Date";
            this.colActionDt.FieldName = "ActionDt";
            this.colActionDt.Name = "colActionDt";
            this.colActionDt.Visible = true;
            this.colActionDt.VisibleIndex = 1;
            // 
            // colAuditor1
            // 
            this.colAuditor1.FieldName = "Auditor1.FullName";
            this.colAuditor1.Name = "colAuditor1";
            this.colAuditor1.Visible = true;
            this.colAuditor1.VisibleIndex = 2;
            // 
            // colAuditor2
            // 
            this.colAuditor2.FieldName = "Auditor2.FullName";
            this.colAuditor2.Name = "colAuditor2";
            this.colAuditor2.Visible = true;
            this.colAuditor2.VisibleIndex = 3;
            // 
            // colSupervisor
            // 
            this.colSupervisor.FieldName = "Supervisor.FullName";
            this.colSupervisor.Name = "colSupervisor";
            this.colSupervisor.Visible = true;
            this.colSupervisor.VisibleIndex = 4;
            // 
            // colAuditor1Idle
            // 
            this.colAuditor1Idle.FieldName = "Auditor1Idle";
            this.colAuditor1Idle.Name = "colAuditor1Idle";
            this.colAuditor1Idle.Visible = true;
            this.colAuditor1Idle.VisibleIndex = 5;
            // 
            // colAuditor2Idle
            // 
            this.colAuditor2Idle.FieldName = "Auditor2Idle";
            this.colAuditor2Idle.Name = "colAuditor2Idle";
            this.colAuditor2Idle.Visible = true;
            this.colAuditor2Idle.VisibleIndex = 6;
            // 
            // colSupervisorIdle
            // 
            this.colSupervisorIdle.FieldName = "SupervisorIdle";
            this.colSupervisorIdle.Name = "colSupervisorIdle";
            this.colSupervisorIdle.Visible = true;
            this.colSupervisorIdle.VisibleIndex = 7;
            // 
            // NotifInactive15Days
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "NotifInactive15Days";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notifications - Inactive 15 Days";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notif1ObjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailId;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDt;
        private System.Windows.Forms.BindingSource notif1ObjBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditor1;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditor2;
        private DevExpress.XtraGrid.Columns.GridColumn colSupervisor;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditor1Idle;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditor2Idle;
        private DevExpress.XtraGrid.Columns.GridColumn colSupervisorIdle;
    }
}