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
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.colCommentText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtbComments = new System.Windows.Forms.RichTextBox();
            this.btnMTtoIA = new System.Windows.Forms.Button();
            this.btnFontDialog = new System.Windows.Forms.Button();
            this.btnMTtoDT = new System.Windows.Forms.Button();
            this.btnDTtoMT = new System.Windows.Forms.Button();
            this.btnIAtoMT = new System.Windows.Forms.Button();
            this.btnMTtoIAInform = new System.Windows.Forms.Button();
            this.btnMTtoDTDelegate = new System.Windows.Forms.Button();
            this.btnMTtoIAExtension = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTinformIA = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailActivityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.fIDetailActivityBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 289);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(800, 213);
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
            this.colActivity.FieldName = "ActivityDescription.Name";
            this.colActivity.Name = "colActivity";
            this.colActivity.Visible = true;
            this.colActivity.VisibleIndex = 2;
            // 
            // colCommentRtf
            // 
            this.colCommentRtf.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.colCommentRtf.FieldName = "CommentRtf";
            this.colCommentRtf.Name = "colCommentRtf";
            this.colCommentRtf.Visible = true;
            this.colCommentRtf.VisibleIndex = 3;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
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
            this.rtbComments.Location = new System.Drawing.Point(198, 86);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(300, 197);
            this.rtbComments.TabIndex = 1;
            this.rtbComments.Text = "";
            // 
            // btnMTtoIA
            // 
            this.btnMTtoIA.Location = new System.Drawing.Point(504, 86);
            this.btnMTtoIA.Name = "btnMTtoIA";
            this.btnMTtoIA.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoIA.TabIndex = 2;
            this.btnMTtoIA.Text = "MT to IA (publish)";
            this.btnMTtoIA.UseVisualStyleBackColor = true;
            this.btnMTtoIA.Click += new System.EventHandler(this.btnMTtoIA_Click);
            // 
            // btnFontDialog
            // 
            this.btnFontDialog.Location = new System.Drawing.Point(72, 86);
            this.btnFontDialog.Name = "btnFontDialog";
            this.btnFontDialog.Size = new System.Drawing.Size(120, 23);
            this.btnFontDialog.TabIndex = 3;
            this.btnFontDialog.Text = "Font Dialog";
            this.btnFontDialog.UseVisualStyleBackColor = true;
            this.btnFontDialog.Click += new System.EventHandler(this.btnFontDialog_Click);
            // 
            // btnMTtoDT
            // 
            this.btnMTtoDT.Location = new System.Drawing.Point(504, 231);
            this.btnMTtoDT.Name = "btnMTtoDT";
            this.btnMTtoDT.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoDT.TabIndex = 4;
            this.btnMTtoDT.Text = "MT to DT (comment)";
            this.btnMTtoDT.UseVisualStyleBackColor = true;
            this.btnMTtoDT.Click += new System.EventHandler(this.btnMTtoDT_Click);
            // 
            // btnDTtoMT
            // 
            this.btnDTtoMT.Location = new System.Drawing.Point(504, 202);
            this.btnDTtoMT.Name = "btnDTtoMT";
            this.btnDTtoMT.Size = new System.Drawing.Size(120, 23);
            this.btnDTtoMT.TabIndex = 5;
            this.btnDTtoMT.Text = "DT to MT (comment)";
            this.btnDTtoMT.UseVisualStyleBackColor = true;
            this.btnDTtoMT.Click += new System.EventHandler(this.btnDTtoMT_Click);
            // 
            // btnIAtoMT
            // 
            this.btnIAtoMT.Location = new System.Drawing.Point(504, 115);
            this.btnIAtoMT.Name = "btnIAtoMT";
            this.btnIAtoMT.Size = new System.Drawing.Size(120, 23);
            this.btnIAtoMT.TabIndex = 6;
            this.btnIAtoMT.Text = "IA to MT (return)";
            this.btnIAtoMT.UseVisualStyleBackColor = true;
            this.btnIAtoMT.Click += new System.EventHandler(this.btnIAtoMT_Click);
            // 
            // btnMTtoIAInform
            // 
            this.btnMTtoIAInform.Location = new System.Drawing.Point(504, 144);
            this.btnMTtoIAInform.Name = "btnMTtoIAInform";
            this.btnMTtoIAInform.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoIAInform.TabIndex = 7;
            this.btnMTtoIAInform.Text = "MT to IA (inform)";
            this.btnMTtoIAInform.UseVisualStyleBackColor = true;
            this.btnMTtoIAInform.Click += new System.EventHandler(this.btnMTtoIAInform_Click);
            // 
            // btnMTtoDTDelegate
            // 
            this.btnMTtoDTDelegate.Location = new System.Drawing.Point(504, 173);
            this.btnMTtoDTDelegate.Name = "btnMTtoDTDelegate";
            this.btnMTtoDTDelegate.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoDTDelegate.TabIndex = 8;
            this.btnMTtoDTDelegate.Text = "MT to DT (delegate)";
            this.btnMTtoDTDelegate.UseVisualStyleBackColor = true;
            this.btnMTtoDTDelegate.Click += new System.EventHandler(this.btnMTtoDTDelegate_Click);
            // 
            // btnMTtoIAExtension
            // 
            this.btnMTtoIAExtension.Location = new System.Drawing.Point(504, 260);
            this.btnMTtoIAExtension.Name = "btnMTtoIAExtension";
            this.btnMTtoIAExtension.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoIAExtension.TabIndex = 9;
            this.btnMTtoIAExtension.Text = "MT to IA (extension)";
            this.btnMTtoIAExtension.UseVisualStyleBackColor = true;
            this.btnMTtoIAExtension.Click += new System.EventHandler(this.btnMTtoIAExtension_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MT_tsmiMTinformIA});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // MT_tsmiMTinformIA
            // 
            this.MT_tsmiMTinformIA.Name = "MT_tsmiMTinformIA";
            this.MT_tsmiMTinformIA.Size = new System.Drawing.Size(234, 22);
            this.MT_tsmiMTinformIA.Tag = "2";
            this.MT_tsmiMTinformIA.Text = "Inform IA for Work In Progress";
            this.MT_tsmiMTinformIA.Click += new System.EventHandler(this.MT_tsmiMTinformIA_Click);
            // 
            // FIActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.btnMTtoIAExtension);
            this.Controls.Add(this.btnMTtoDTDelegate);
            this.Controls.Add(this.btnMTtoIAInform);
            this.Controls.Add(this.btnIAtoMT);
            this.Controls.Add(this.btnDTtoMT);
            this.Controls.Add(this.btnMTtoDT);
            this.Controls.Add(this.btnFontDialog);
            this.Controls.Add(this.btnMTtoIA);
            this.Controls.Add(this.rtbComments);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FIActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements Activity";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailActivityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnMTtoDT;
        private System.Windows.Forms.Button btnDTtoMT;
        private System.Windows.Forms.Button btnIAtoMT;
        private System.Windows.Forms.Button btnMTtoIAInform;
        private System.Windows.Forms.Button btnMTtoDTDelegate;
        private System.Windows.Forms.Button btnMTtoIAExtension;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTinformIA;
    }
}