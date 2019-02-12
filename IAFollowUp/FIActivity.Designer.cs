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
            this.cmsActivity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIattachments = new System.Windows.Forms.ToolStripMenuItem();
            this.MIcopyComments = new System.Windows.Forms.ToolStripMenuItem();
            this.MIcopyAttachments = new System.Windows.Forms.ToolStripMenuItem();
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
            this.colPlaceholdersId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaceholders = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivityDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHasAttachments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rtbComments = new System.Windows.Forms.RichTextBox();
            this.btnFontDialog = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTinformIA = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTreplyIA = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTdelegateDT = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTreplyDT = new System.Windows.Forms.ToolStripMenuItem();
            this.DT_tsmiDTreplyMT = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_tsmiMTextendIA = new System.Windows.Forms.ToolStripMenuItem();
            this.IA_tsmiIAextendMT = new System.Windows.Forms.ToolStripMenuItem();
            this.IA_tsmiIAjudgeMT = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtpDetail_ActionDate = new System.Windows.Forms.DateTimePicker();
            this.lblDetail_ActionDate = new System.Windows.Forms.Label();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnAttachment = new System.Windows.Forms.Button();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtAuditRef = new System.Windows.Forms.TextBox();
            this.lblAuditRef = new System.Windows.Forms.Label();
            this.lblFIId = new System.Windows.Forms.Label();
            this.txtFIId = new System.Windows.Forms.TextBox();
            this.lblFISubId = new System.Windows.Forms.Label();
            this.txtFISubId = new System.Windows.Forms.TextBox();
            this.txtActionCode = new System.Windows.Forms.TextBox();
            this.lblActionCode = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtAuditTitle = new System.Windows.Forms.TextBox();
            this.lblAuditTitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.txtHeaderTitle = new System.Windows.Forms.TextBox();
            this.lblDetailDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtActionReq = new System.Windows.Forms.TextBox();
            this.lblActionReq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailActivityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.cmsActivity;
            this.gridControl1.DataSource = this.fIDetailActivityBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 482);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(800, 176);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsActivity
            // 
            this.cmsActivity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIattachments,
            this.MIcopyComments,
            this.MIcopyAttachments});
            this.cmsActivity.Name = "cmsHeader";
            this.cmsActivity.Size = new System.Drawing.Size(174, 70);
            // 
            // MIattachments
            // 
            this.MIattachments.Name = "MIattachments";
            this.MIattachments.Size = new System.Drawing.Size(173, 22);
            this.MIattachments.Text = "Attachments";
            this.MIattachments.Click += new System.EventHandler(this.MIattachments_Click);
            // 
            // MIcopyComments
            // 
            this.MIcopyComments.Name = "MIcopyComments";
            this.MIcopyComments.Size = new System.Drawing.Size(173, 22);
            this.MIcopyComments.Text = "Copy Comments";
            this.MIcopyComments.Click += new System.EventHandler(this.MIcopyComments_Click);
            // 
            // MIcopyAttachments
            // 
            this.MIcopyAttachments.Name = "MIcopyAttachments";
            this.MIcopyAttachments.Size = new System.Drawing.Size(173, 22);
            this.MIcopyAttachments.Text = "Copy Attachments";
            this.MIcopyAttachments.Click += new System.EventHandler(this.MIcopyAttachments_Click);
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
            this.colPlaceholdersId,
            this.colPlaceholders,
            this.colActivityDescription,
            this.colActionDt,
            this.colHasAttachments});
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
            // 
            // colDetailId
            // 
            this.colDetailId.FieldName = "DetailId";
            this.colDetailId.Name = "colDetailId";
            // 
            // colActivity
            // 
            this.colActivity.Caption = "Activity";
            this.colActivity.FieldName = "ActivityDescription.Name";
            this.colActivity.Name = "colActivity";
            this.colActivity.Visible = true;
            this.colActivity.VisibleIndex = 0;
            // 
            // colCommentRtf
            // 
            this.colCommentRtf.Caption = "Comment";
            this.colCommentRtf.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.colCommentRtf.FieldName = "CommentRtf";
            this.colCommentRtf.Name = "colCommentRtf";
            this.colCommentRtf.Visible = true;
            this.colCommentRtf.VisibleIndex = 1;
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
            // 
            // colFromUser
            // 
            this.colFromUser.Caption = "From User";
            this.colFromUser.FieldName = "FromUser.FullName";
            this.colFromUser.Name = "colFromUser";
            this.colFromUser.Visible = true;
            this.colFromUser.VisibleIndex = 2;
            // 
            // colToUser
            // 
            this.colToUser.Caption = "To User";
            this.colToUser.FieldName = "ToUser.FullName";
            this.colToUser.Name = "colToUser";
            this.colToUser.Visible = true;
            this.colToUser.VisibleIndex = 3;
            // 
            // colInsDt
            // 
            this.colInsDt.Caption = "Insert Date";
            this.colInsDt.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            this.colInsDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colInsDt.FieldName = "InsDt";
            this.colInsDt.Name = "colInsDt";
            this.colInsDt.Visible = true;
            this.colInsDt.VisibleIndex = 4;
            // 
            // colPlaceholdersId
            // 
            this.colPlaceholdersId.Caption = "phId";
            this.colPlaceholdersId.FieldName = "Placeholders.Id";
            this.colPlaceholdersId.Name = "colPlaceholdersId";
            // 
            // colPlaceholders
            // 
            this.colPlaceholders.Caption = "Department";
            this.colPlaceholders.FieldName = "Placeholders.Department.Name";
            this.colPlaceholders.Name = "colPlaceholders";
            this.colPlaceholders.Visible = true;
            this.colPlaceholders.VisibleIndex = 5;
            // 
            // colActivityDescription
            // 
            this.colActivityDescription.Caption = "Side";
            this.colActivityDescription.FieldName = "ActivityDescription.ActionSide.Name";
            this.colActivityDescription.Name = "colActivityDescription";
            // 
            // colActionDt
            // 
            this.colActionDt.Caption = "Deadline";
            this.colActionDt.FieldName = "ActionDt";
            this.colActionDt.Name = "colActionDt";
            this.colActionDt.Visible = true;
            this.colActionDt.VisibleIndex = 6;
            // 
            // colHasAttachments
            // 
            this.colHasAttachments.Caption = "Attachments";
            this.colHasAttachments.FieldName = "HasAttachments";
            this.colHasAttachments.Name = "colHasAttachments";
            this.colHasAttachments.Visible = true;
            this.colHasAttachments.VisibleIndex = 7;
            // 
            // rtbComments
            // 
            this.rtbComments.Location = new System.Drawing.Point(229, 27);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(300, 197);
            this.rtbComments.TabIndex = 1;
            this.rtbComments.Text = "";
            // 
            // btnFontDialog
            // 
            this.btnFontDialog.Location = new System.Drawing.Point(535, 27);
            this.btnFontDialog.Name = "btnFontDialog";
            this.btnFontDialog.Size = new System.Drawing.Size(120, 23);
            this.btnFontDialog.TabIndex = 3;
            this.btnFontDialog.Text = "Font Dialog";
            this.btnFontDialog.UseVisualStyleBackColor = true;
            this.btnFontDialog.Click += new System.EventHandler(this.btnFontDialog_Click);
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
            this.MT_tsmiMTdelegateDT,
            this.MT_tsmiMTreplyDT,
            this.DT_tsmiDTreplyMT,
            this.MT_tsmiMTextendIA,
            this.IA_tsmiIAextendMT,
            this.IA_tsmiIAjudgeMT});
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
            this.DT_tsmiDTreplyMT.Tag = "2";
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
            // IA_tsmiIAjudgeMT
            // 
            this.IA_tsmiIAjudgeMT.Name = "IA_tsmiIAjudgeMT";
            this.IA_tsmiIAjudgeMT.Size = new System.Drawing.Size(260, 22);
            this.IA_tsmiIAjudgeMT.Tag = "1";
            this.IA_tsmiIAjudgeMT.Text = "(ia) Judge Actions";
            this.IA_tsmiIAjudgeMT.Click += new System.EventHandler(this.IA_tsmiIAjudgeMT_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLblUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
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
            this.dtpDetail_ActionDate.Location = new System.Drawing.Point(23, 67);
            this.dtpDetail_ActionDate.Name = "dtpDetail_ActionDate";
            this.dtpDetail_ActionDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDetail_ActionDate.TabIndex = 13;
            // 
            // lblDetail_ActionDate
            // 
            this.lblDetail_ActionDate.AutoSize = true;
            this.lblDetail_ActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetail_ActionDate.Location = new System.Drawing.Point(76, 40);
            this.lblDetail_ActionDate.Name = "lblDetail_ActionDate";
            this.lblDetail_ActionDate.Size = new System.Drawing.Size(93, 20);
            this.lblDetail_ActionDate.TabIndex = 12;
            this.lblDetail_ActionDate.Text = "Action Date";
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Location = new System.Drawing.Point(535, 56);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(120, 23);
            this.btnSaveDraft.TabIndex = 14;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = true;
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click);
            // 
            // btnAttachment
            // 
            this.btnAttachment.Location = new System.Drawing.Point(661, 56);
            this.btnAttachment.Name = "btnAttachment";
            this.btnAttachment.Size = new System.Drawing.Size(120, 23);
            this.btnAttachment.TabIndex = 15;
            this.btnAttachment.Text = "Attachment(s)";
            this.btnAttachment.UseVisualStyleBackColor = true;
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtCompany.Location = new System.Drawing.Point(23, 111);
            this.txtCompany.MaxLength = 3;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(200, 22);
            this.txtCompany.TabIndex = 16;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(77, 92);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 16);
            this.lblCompany.TabIndex = 17;
            this.lblCompany.Text = "Company";
            // 
            // txtAuditRef
            // 
            this.txtAuditRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAuditRef.Location = new System.Drawing.Point(23, 203);
            this.txtAuditRef.Margin = new System.Windows.Forms.Padding(3, 3, 114, 3);
            this.txtAuditRef.MaxLength = 50;
            this.txtAuditRef.Name = "txtAuditRef";
            this.txtAuditRef.ReadOnly = true;
            this.txtAuditRef.Size = new System.Drawing.Size(200, 22);
            this.txtAuditRef.TabIndex = 19;
            // 
            // lblAuditRef
            // 
            this.lblAuditRef.AutoSize = true;
            this.lblAuditRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditRef.Location = new System.Drawing.Point(81, 184);
            this.lblAuditRef.Name = "lblAuditRef";
            this.lblAuditRef.Size = new System.Drawing.Size(62, 16);
            this.lblAuditRef.TabIndex = 18;
            this.lblAuditRef.Text = "Audit Ref";
            // 
            // lblFIId
            // 
            this.lblFIId.AutoSize = true;
            this.lblFIId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFIId.Location = new System.Drawing.Point(80, 136);
            this.lblFIId.Name = "lblFIId";
            this.lblFIId.Size = new System.Drawing.Size(46, 20);
            this.lblFIId.TabIndex = 63;
            this.lblFIId.Text = "F/I Id";
            // 
            // txtFIId
            // 
            this.txtFIId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFIId.Location = new System.Drawing.Point(23, 159);
            this.txtFIId.Margin = new System.Windows.Forms.Padding(3, 3, 114, 3);
            this.txtFIId.MaxLength = 50;
            this.txtFIId.Name = "txtFIId";
            this.txtFIId.ReadOnly = true;
            this.txtFIId.Size = new System.Drawing.Size(200, 22);
            this.txtFIId.TabIndex = 62;
            // 
            // lblFISubId
            // 
            this.lblFISubId.AutoSize = true;
            this.lblFISubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFISubId.Location = new System.Drawing.Point(535, 82);
            this.lblFISubId.Name = "lblFISubId";
            this.lblFISubId.Size = new System.Drawing.Size(75, 20);
            this.lblFISubId.TabIndex = 65;
            this.lblFISubId.Text = "F/I SubId";
            // 
            // txtFISubId
            // 
            this.txtFISubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFISubId.Location = new System.Drawing.Point(535, 105);
            this.txtFISubId.Margin = new System.Windows.Forms.Padding(3, 3, 114, 3);
            this.txtFISubId.MaxLength = 50;
            this.txtFISubId.Name = "txtFISubId";
            this.txtFISubId.ReadOnly = true;
            this.txtFISubId.Size = new System.Drawing.Size(200, 22);
            this.txtFISubId.TabIndex = 64;
            // 
            // txtActionCode
            // 
            this.txtActionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtActionCode.Location = new System.Drawing.Point(535, 153);
            this.txtActionCode.MaxLength = 3;
            this.txtActionCode.Name = "txtActionCode";
            this.txtActionCode.ReadOnly = true;
            this.txtActionCode.Size = new System.Drawing.Size(200, 22);
            this.txtActionCode.TabIndex = 67;
            // 
            // lblActionCode
            // 
            this.lblActionCode.AutoSize = true;
            this.lblActionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActionCode.Location = new System.Drawing.Point(535, 130);
            this.lblActionCode.Name = "lblActionCode";
            this.lblActionCode.Size = new System.Drawing.Size(96, 20);
            this.lblActionCode.TabIndex = 66;
            this.lblActionCode.Text = "Action Code";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCategory.Location = new System.Drawing.Point(536, 178);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(157, 16);
            this.lblCategory.TabIndex = 68;
            this.lblCategory.Text = "Category (per FI Header)";
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtCategory.Location = new System.Drawing.Point(535, 197);
            this.txtCategory.MaxLength = 3;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(200, 22);
            this.txtCategory.TabIndex = 69;
            // 
            // txtAuditTitle
            // 
            this.txtAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAuditTitle.Location = new System.Drawing.Point(114, 231);
            this.txtAuditTitle.MaxLength = 500;
            this.txtAuditTitle.Multiline = true;
            this.txtAuditTitle.Name = "txtAuditTitle";
            this.txtAuditTitle.ReadOnly = true;
            this.txtAuditTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAuditTitle.Size = new System.Drawing.Size(667, 50);
            this.txtAuditTitle.TabIndex = 70;
            // 
            // lblAuditTitle
            // 
            this.lblAuditTitle.AutoSize = true;
            this.lblAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditTitle.Location = new System.Drawing.Point(4, 251);
            this.lblAuditTitle.Name = "lblAuditTitle";
            this.lblAuditTitle.Size = new System.Drawing.Size(67, 16);
            this.lblAuditTitle.TabIndex = 71;
            this.lblAuditTitle.Text = "Audit Title";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(4, 304);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(80, 16);
            this.lblHeaderTitle.TabIndex = 72;
            this.lblHeaderTitle.Text = "HeaderTitle";
            // 
            // txtHeaderTitle
            // 
            this.txtHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtHeaderTitle.Location = new System.Drawing.Point(114, 287);
            this.txtHeaderTitle.MaxLength = 500;
            this.txtHeaderTitle.Multiline = true;
            this.txtHeaderTitle.Name = "txtHeaderTitle";
            this.txtHeaderTitle.ReadOnly = true;
            this.txtHeaderTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHeaderTitle.Size = new System.Drawing.Size(667, 50);
            this.txtHeaderTitle.TabIndex = 73;
            // 
            // lblDetailDescription
            // 
            this.lblDetailDescription.AutoSize = true;
            this.lblDetailDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetailDescription.Location = new System.Drawing.Point(4, 363);
            this.lblDetailDescription.Name = "lblDetailDescription";
            this.lblDetailDescription.Size = new System.Drawing.Size(76, 16);
            this.lblDetailDescription.TabIndex = 74;
            this.lblDetailDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescription.Location = new System.Drawing.Point(114, 343);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(667, 50);
            this.txtDescription.TabIndex = 75;
            // 
            // txtActionReq
            // 
            this.txtActionReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtActionReq.Location = new System.Drawing.Point(114, 399);
            this.txtActionReq.MaxLength = 500;
            this.txtActionReq.Multiline = true;
            this.txtActionReq.Name = "txtActionReq";
            this.txtActionReq.ReadOnly = true;
            this.txtActionReq.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActionReq.Size = new System.Drawing.Size(667, 50);
            this.txtActionReq.TabIndex = 77;
            // 
            // lblActionReq
            // 
            this.lblActionReq.AutoSize = true;
            this.lblActionReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActionReq.Location = new System.Drawing.Point(4, 417);
            this.lblActionReq.Name = "lblActionReq";
            this.lblActionReq.Size = new System.Drawing.Size(104, 16);
            this.lblActionReq.TabIndex = 76;
            this.lblActionReq.Text = "Action Required";
            // 
            // FIActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 681);
            this.Controls.Add(this.txtActionReq);
            this.Controls.Add(this.lblActionReq);
            this.Controls.Add(this.lblDetailDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.txtHeaderTitle);
            this.Controls.Add(this.txtAuditTitle);
            this.Controls.Add(this.lblAuditTitle);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtActionCode);
            this.Controls.Add(this.lblActionCode);
            this.Controls.Add(this.lblFISubId);
            this.Controls.Add(this.txtFISubId);
            this.Controls.Add(this.lblFIId);
            this.Controls.Add(this.txtFIId);
            this.Controls.Add(this.txtAuditRef);
            this.Controls.Add(this.lblAuditRef);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnAttachment);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.dtpDetail_ActionDate);
            this.Controls.Add(this.lblDetail_ActionDate);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnFontDialog);
            this.Controls.Add(this.rtbComments);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FIActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements Activity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FIActivity_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailActivityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Button btnFontDialog;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTinformIA;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTreplyIA;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholders;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityDescription;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTdelegateDT;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTreplyDT;
        private System.Windows.Forms.ToolStripMenuItem DT_tsmiDTreplyMT;
        private System.Windows.Forms.ToolStripMenuItem MT_tsmiMTextendIA;
        private System.Windows.Forms.ToolStripMenuItem IA_tsmiIAextendMT;
        private System.Windows.Forms.DateTimePicker dtpDetail_ActionDate;
        private System.Windows.Forms.Label lblDetail_ActionDate;
        public System.Windows.Forms.ContextMenuStrip cmsActivity;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnAttachment;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholdersId;
        private System.Windows.Forms.ToolStripMenuItem MIattachments;
        private System.Windows.Forms.ToolStripMenuItem MIcopyComments;
        private System.Windows.Forms.ToolStripMenuItem MIcopyAttachments;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDt;
        private System.Windows.Forms.ToolStripMenuItem IA_tsmiIAjudgeMT;
        private DevExpress.XtraGrid.Columns.GridColumn colHasAttachments;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtAuditRef;
        private System.Windows.Forms.Label lblAuditRef;
        private System.Windows.Forms.Label lblFIId;
        private System.Windows.Forms.TextBox txtFIId;
        private System.Windows.Forms.Label lblFISubId;
        private System.Windows.Forms.TextBox txtFISubId;
        public System.Windows.Forms.TextBox txtActionCode;
        private System.Windows.Forms.Label lblActionCode;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtAuditTitle;
        private System.Windows.Forms.Label lblAuditTitle;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TextBox txtHeaderTitle;
        private System.Windows.Forms.Label lblDetailDescription;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtActionReq;
        private System.Windows.Forms.Label lblActionReq;
    }
}