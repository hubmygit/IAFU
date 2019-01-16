namespace IAFollowUp
{
    partial class FIActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIActivity));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.fIDetailActivityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommentRtf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommentText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtbComments = new System.Windows.Forms.RichTextBox();
            this.btnMTtoIA = new System.Windows.Forms.Button();
            this.btnFontDialog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailActivityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.fIDetailActivityBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 250);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 200);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // fIDetailActivityBindingSource
            // 
            this.fIDetailActivityBindingSource.DataSource = typeof(IAFollowUp.FIDetailActivity);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDetailId,
            this.colActivity,
            this.colCommentRtf,
            this.colCommentText,
            this.colFromUser,
            this.colToUser,
            this.colInsDt});
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
            // colDetailId
            // 
            this.colDetailId.FieldName = "DetailId";
            this.colDetailId.Name = "colDetailId";
            this.colDetailId.Visible = true;
            this.colDetailId.VisibleIndex = 1;
            // 
            // colActivity
            // 
            this.colActivity.FieldName = "Activity";
            this.colActivity.Name = "colActivity";
            this.colActivity.Visible = true;
            this.colActivity.VisibleIndex = 2;
            // 
            // colCommentRtf
            // 
            this.colCommentRtf.FieldName = "CommentRtf";
            this.colCommentRtf.Name = "colCommentRtf";
            this.colCommentRtf.Visible = true;
            this.colCommentRtf.VisibleIndex = 3;
            // 
            // colCommentText
            // 
            this.colCommentText.FieldName = "CommentText";
            this.colCommentText.Name = "colCommentText";
            this.colCommentText.Visible = true;
            this.colCommentText.VisibleIndex = 4;
            // 
            // colFromUser
            // 
            this.colFromUser.Caption = "From User";
            this.colFromUser.FieldName = "FromUser.FullName";
            this.colFromUser.Name = "colFromUser";
            this.colFromUser.Visible = true;
            this.colFromUser.VisibleIndex = 5;
            // 
            // colToUser
            // 
            this.colToUser.Caption = "To User";
            this.colToUser.FieldName = "ToUser.FullName";
            this.colToUser.Name = "colToUser";
            this.colToUser.Visible = true;
            this.colToUser.VisibleIndex = 6;
            // 
            // colInsDt
            // 
            this.colInsDt.FieldName = "InsDt";
            this.colInsDt.Name = "colInsDt";
            this.colInsDt.Visible = true;
            this.colInsDt.VisibleIndex = 7;
            // 
            // rtbComments
            // 
            this.rtbComments.Location = new System.Drawing.Point(12, 12);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(300, 100);
            this.rtbComments.TabIndex = 1;
            this.rtbComments.Text = "";
            // 
            // btnMTtoIA
            // 
            this.btnMTtoIA.Location = new System.Drawing.Point(318, 89);
            this.btnMTtoIA.Name = "btnMTtoIA";
            this.btnMTtoIA.Size = new System.Drawing.Size(75, 23);
            this.btnMTtoIA.TabIndex = 2;
            this.btnMTtoIA.Text = "MT to IA";
            this.btnMTtoIA.UseVisualStyleBackColor = true;
            this.btnMTtoIA.Click += new System.EventHandler(this.btnMTtoIA_Click);
            // 
            // btnFontDialog
            // 
            this.btnFontDialog.Location = new System.Drawing.Point(318, 12);
            this.btnFontDialog.Name = "btnFontDialog";
            this.btnFontDialog.Size = new System.Drawing.Size(75, 23);
            this.btnFontDialog.TabIndex = 3;
            this.btnFontDialog.Text = "Font Dialog";
            this.btnFontDialog.UseVisualStyleBackColor = true;
            // 
            // FIActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFontDialog);
            this.Controls.Add(this.btnMTtoIA);
            this.Controls.Add(this.rtbComments);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FIActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements Activity";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailActivityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource fIDetailActivityBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailId;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colCommentRtf;
        private DevExpress.XtraGrid.Columns.GridColumn colCommentText;
        private DevExpress.XtraGrid.Columns.GridColumn colFromUser;
        private DevExpress.XtraGrid.Columns.GridColumn colToUser;
        private DevExpress.XtraGrid.Columns.GridColumn colInsDt;
        private System.Windows.Forms.RichTextBox rtbComments;
        private System.Windows.Forms.Button btnMTtoIA;
        private System.Windows.Forms.Button btnFontDialog;
    }
}