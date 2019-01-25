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
            this.colPlaceholders = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivityDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.MT_tsmiMTreplyIA = new System.Windows.Forms.ToolStripMenuItem();
            this.IA_tsmiIAreturnMT = new System.Windows.Forms.ToolStripMenuItem();
            this.IA_tsmiIAacceptedMT = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTdelegateDT = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTreplyDT = new System.Windows.Forms.ToolStripMenuItem();
            this.DT_tsmiDTreplyMT = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTextendIA = new System.Windows.Forms.ToolStripMenuItem();
            this.IA_tsmiIAextendMT = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtpDetail_ActionDate = new System.Windows.Forms.DateTimePicker();
            this.lblDetail_ActionDate = new System.Windows.Forms.Label();
            this.cmsActivity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIcopy = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailActivityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cmsActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsActivity;
            this.gridControl1.DataSource = this.fIDetailActivityBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 251);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(800, 226);
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
            this.colInsDt,
            this.colPlaceholders,
            this.colActivityDescription,
            this.colActionDt});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
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
            this.colInsDt.Caption = "Insert Date";
            this.colInsDt.FieldName = "InsDt";
            this.colInsDt.Name = "colInsDt";
            this.colInsDt.Visible = true;
            this.colInsDt.VisibleIndex = 7;
            // 
            // colPlaceholders
            // 
            this.colPlaceholders.Caption = "Department";
            this.colPlaceholders.FieldName = "Placeholders.Department.Name";
            this.colPlaceholders.Name = "colPlaceholders";
            this.colPlaceholders.Visible = true;
            this.colPlaceholders.VisibleIndex = 8;
            // 
            // colActivityDescription
            // 
            this.colActivityDescription.Caption = "Side";
            this.colActivityDescription.FieldName = "ActivityDescription.ActionSide.Name";
            this.colActivityDescription.Name = "colActivityDescription";
            this.colActivityDescription.Visible = true;
            this.colActivityDescription.VisibleIndex = 9;
            // 
            // colActionDt
            // 
            this.colActionDt.Caption = "Deadline";
            this.colActionDt.FieldName = "ActionDt";
            this.colActionDt.Name = "colActionDt";
            this.colActionDt.Visible = true;
            this.colActionDt.VisibleIndex = 10;
            // 
            // rtbComments
            // 
            this.rtbComments.Location = new System.Drawing.Point(229, 27);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(300, 197);
            this.rtbComments.TabIndex = 1;
            this.rtbComments.Text = "";
            // 
            // btnMTtoIA
            // 
            this.btnMTtoIA.Location = new System.Drawing.Point(535, 27);
            this.btnMTtoIA.Name = "btnMTtoIA";
            this.btnMTtoIA.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoIA.TabIndex = 2;
            this.btnMTtoIA.Text = "MT to IA (publish)";
            this.btnMTtoIA.UseVisualStyleBackColor = true;
            this.btnMTtoIA.Click += new System.EventHandler(this.btnMTtoIA_Click);
            // 
            // btnFontDialog
            // 
            this.btnFontDialog.Location = new System.Drawing.Point(103, 27);
            this.btnFontDialog.Name = "btnFontDialog";
            this.btnFontDialog.Size = new System.Drawing.Size(120, 23);
            this.btnFontDialog.TabIndex = 3;
            this.btnFontDialog.Text = "Font Dialog";
            this.btnFontDialog.UseVisualStyleBackColor = true;
            this.btnFontDialog.Click += new System.EventHandler(this.btnFontDialog_Click);
            // 
            // btnMTtoDT
            // 
            this.btnMTtoDT.Location = new System.Drawing.Point(535, 172);
            this.btnMTtoDT.Name = "btnMTtoDT";
            this.btnMTtoDT.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoDT.TabIndex = 4;
            this.btnMTtoDT.Text = "MT to DT (comment)";
            this.btnMTtoDT.UseVisualStyleBackColor = true;
            this.btnMTtoDT.Click += new System.EventHandler(this.btnMTtoDT_Click);
            // 
            // btnDTtoMT
            // 
            this.btnDTtoMT.Location = new System.Drawing.Point(535, 143);
            this.btnDTtoMT.Name = "btnDTtoMT";
            this.btnDTtoMT.Size = new System.Drawing.Size(120, 23);
            this.btnDTtoMT.TabIndex = 5;
            this.btnDTtoMT.Text = "DT to MT (comment)";
            this.btnDTtoMT.UseVisualStyleBackColor = true;
            this.btnDTtoMT.Click += new System.EventHandler(this.btnDTtoMT_Click);
            // 
            // btnIAtoMT
            // 
            this.btnIAtoMT.Location = new System.Drawing.Point(535, 56);
            this.btnIAtoMT.Name = "btnIAtoMT";
            this.btnIAtoMT.Size = new System.Drawing.Size(120, 23);
            this.btnIAtoMT.TabIndex = 6;
            this.btnIAtoMT.Text = "IA to MT (return)";
            this.btnIAtoMT.UseVisualStyleBackColor = true;
            this.btnIAtoMT.Click += new System.EventHandler(this.btnIAtoMT_Click);
            // 
            // btnMTtoIAInform
            // 
            this.btnMTtoIAInform.Location = new System.Drawing.Point(535, 85);
            this.btnMTtoIAInform.Name = "btnMTtoIAInform";
            this.btnMTtoIAInform.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoIAInform.TabIndex = 7;
            this.btnMTtoIAInform.Text = "MT to IA (inform)";
            this.btnMTtoIAInform.UseVisualStyleBackColor = true;
            this.btnMTtoIAInform.Click += new System.EventHandler(this.btnMTtoIAInform_Click);
            // 
            // btnMTtoDTDelegate
            // 
            this.btnMTtoDTDelegate.Location = new System.Drawing.Point(535, 114);
            this.btnMTtoDTDelegate.Name = "btnMTtoDTDelegate";
            this.btnMTtoDTDelegate.Size = new System.Drawing.Size(120, 23);
            this.btnMTtoDTDelegate.TabIndex = 8;
            this.btnMTtoDTDelegate.Text = "MT to DT (delegate)";
            this.btnMTtoDTDelegate.UseVisualStyleBackColor = true;
            this.btnMTtoDTDelegate.Click += new System.EventHandler(this.btnMTtoDTDelegate_Click);
            // 
            // btnMTtoIAExtension
            // 
            this.btnMTtoIAExtension.Location = new System.Drawing.Point(535, 201);
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
            this.MT_tsmiMTinformIA,
            this.MT_tsmiMTreplyIA,
            this.IA_tsmiIAreturnMT,
            this.IA_tsmiIAacceptedMT,
            this.MT_tsmiMTdelegateDT,
            this.MT_tsmiMTreplyDT,
            this.DT_tsmiDTreplyMT,
            this.MT_tsmiMTextendIA,
            this.IA_tsmiIAextendMT});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // MT_tsmiMTinformIA
            // 
            this.MT_tsmiMTinformIA.Name = "MT_tsmiMTinformIA";
            this.MT_tsmiMTinformIA.Size = new System.Drawing.Size(260, 22);
            this.MT_tsmiMTinformIA.Tag = "2";
            this.MT_tsmiMTinformIA.Text = "(mt) Inform IA for Work In Progress";
            this.MT_tsmiMTinformIA.Click += new System.EventHandler(this.MT_tsmiMTinformIA_Click);
            // 
            // MT_tsmiMTreplyIA
            // 
            this.MT_tsmiMTreplyIA.Name = "MT_tsmiMTreplyIA";
            this.MT_tsmiMTreplyIA.Size = new System.Drawing.Size(260, 22);
            this.MT_tsmiMTreplyIA.Tag = "2";
            this.MT_tsmiMTreplyIA.Text = "(mt) Publish Actions to IA";
            this.MT_tsmiMTreplyIA.Click += new System.EventHandler(this.MT_tsmiMTreplyIA_Click);
            // 
            // IA_tsmiIAreturnMT
            // 
            this.IA_tsmiIAreturnMT.Name = "IA_tsmiIAreturnMT";
            this.IA_tsmiIAreturnMT.Size = new System.Drawing.Size(260, 22);
            this.IA_tsmiIAreturnMT.Tag = "1";
            this.IA_tsmiIAreturnMT.Text = "(ia) Return to MT";
            this.IA_tsmiIAreturnMT.Click += new System.EventHandler(this.IA_tsmiIAreturnMT_Click);
            // 
            // IA_tsmiIAacceptedMT
            // 
            this.IA_tsmiIAacceptedMT.Name = "IA_tsmiIAacceptedMT";
            this.IA_tsmiIAacceptedMT.Size = new System.Drawing.Size(260, 22);
            this.IA_tsmiIAacceptedMT.Tag = "1";
            this.IA_tsmiIAacceptedMT.Text = "(ia) Accept Actions";
            this.IA_tsmiIAacceptedMT.Click += new System.EventHandler(this.IA_tsmiIAacceptedMT_Click);
            // 
            // MT_tsmiMTdelegateDT
            // 
            this.MT_tsmiMTdelegateDT.Name = "MT_tsmiMTdelegateDT";
            this.MT_tsmiMTdelegateDT.Size = new System.Drawing.Size(260, 22);
            this.MT_tsmiMTdelegateDT.Tag = "2";
            this.MT_tsmiMTdelegateDT.Text = "(mt) Delegate to Key Users";
            this.MT_tsmiMTdelegateDT.Click += new System.EventHandler(this.MT_tsmiMTdelegateDT_Click);
            // 
            // MT_tsmiMTreplyDT
            // 
            this.MT_tsmiMTreplyDT.Name = "MT_tsmiMTreplyDT";
            this.MT_tsmiMTreplyDT.Size = new System.Drawing.Size(260, 22);
            this.MT_tsmiMTreplyDT.Tag = "2";
            this.MT_tsmiMTreplyDT.Text = "(mt) Reply to Key User";
            this.MT_tsmiMTreplyDT.Click += new System.EventHandler(this.MT_tsmiMTreplyDT_Click);
            // 
            // DT_tsmiDTreplyMT
            // 
            this.DT_tsmiDTreplyMT.Name = "DT_tsmiDTreplyMT";
            this.DT_tsmiDTreplyMT.Size = new System.Drawing.Size(260, 22);
            this.DT_tsmiDTreplyMT.Tag = "3";
            this.DT_tsmiDTreplyMT.Text = "(dt) Reply to MT";
            this.DT_tsmiDTreplyMT.Click += new System.EventHandler(this.DT_tsmiDTreplyMT_Click);
            // 
            // MT_tsmiMTextendIA
            // 
            this.MT_tsmiMTextendIA.Name = "MT_tsmiMTextendIA";
            this.MT_tsmiMTextendIA.Size = new System.Drawing.Size(260, 22);
            this.MT_tsmiMTextendIA.Tag = "2";
            this.MT_tsmiMTextendIA.Text = "(mt) Request Deadline Extension";
            this.MT_tsmiMTextendIA.Click += new System.EventHandler(this.MT_tsmiMTextendIA_Click);
            // 
            // IA_tsmiIAextendMT
            // 
            this.IA_tsmiIAextendMT.Name = "IA_tsmiIAextendMT";
            this.IA_tsmiIAextendMT.Size = new System.Drawing.Size(260, 22);
            this.IA_tsmiIAextendMT.Tag = "1";
            this.IA_tsmiIAextendMT.Text = "(ia) Extend Deadline";
            this.IA_tsmiIAextendMT.Click += new System.EventHandler(this.IA_tsmiIAextendMT_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLblUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLblUser
            // 
            this.tsStatusLblUser.BackColor = System.Drawing.SystemColors.Control;
            this.tsStatusLblUser.Image = global::IAFollowUp.Properties.Resources.User_16x;
            this.tsStatusLblUser.Name = "tsStatusLblUser";
            this.tsStatusLblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsStatusLblUser.Size = new System.Drawing.Size(16, 17);
            // 
            // dtpDetail_ActionDate
            // 
            this.dtpDetail_ActionDate.CustomFormat = " ";
            this.dtpDetail_ActionDate.Enabled = false;
            this.dtpDetail_ActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpDetail_ActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDetail_ActionDate.Location = new System.Drawing.Point(12, 144);
            this.dtpDetail_ActionDate.Name = "dtpDetail_ActionDate";
            this.dtpDetail_ActionDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDetail_ActionDate.TabIndex = 13;
            // 
            // lblDetail_ActionDate
            // 
            this.lblDetail_ActionDate.AutoSize = true;
            this.lblDetail_ActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetail_ActionDate.Location = new System.Drawing.Point(65, 117);
            this.lblDetail_ActionDate.Name = "lblDetail_ActionDate";
            this.lblDetail_ActionDate.Size = new System.Drawing.Size(93, 20);
            this.lblDetail_ActionDate.TabIndex = 12;
            this.lblDetail_ActionDate.Text = "Action Date";
            // 
            // cmsActivity
            // 
            this.cmsActivity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIcopy});
            this.cmsActivity.Name = "cmsHeader";
            this.cmsActivity.Size = new System.Drawing.Size(165, 26);
            // 
            // MIcopy
            // 
            this.MIcopy.Name = "MIcopy";
            this.MIcopy.Size = new System.Drawing.Size(164, 22);
            this.MIcopy.Text = "Copy Comments";
            this.MIcopy.Click += new System.EventHandler(this.MIcopy_Click);
            // 
            // FIActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.dtpDetail_ActionDate);
            this.Controls.Add(this.lblDetail_ActionDate);
            this.Controls.Add(this.statusStrip1);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmsActivity.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTreplyIA;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholders;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityDescription;
        private System.Windows.Forms.ToolStripMenuItem IA_tsmiIAreturnMT;
        private System.Windows.Forms.ToolStripMenuItem IA_tsmiIAacceptedMT;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTdelegateDT;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTreplyDT;
        private System.Windows.Forms.ToolStripMenuItem DT_tsmiDTreplyMT;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTextendIA;
        private System.Windows.Forms.ToolStripMenuItem IA_tsmiIAextendMT;
        private System.Windows.Forms.DateTimePicker dtpDetail_ActionDate;
        private System.Windows.Forms.Label lblDetail_ActionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDt;
        public System.Windows.Forms.ContextMenuStrip cmsActivity;
        private System.Windows.Forms.ToolStripMenuItem MIcopy;
    }
}