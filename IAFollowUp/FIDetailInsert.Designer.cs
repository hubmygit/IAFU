namespace IAFollowUp
{
    partial class FIDetailInsert
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIDetailInsert));
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblDetailDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtActionReq = new System.Windows.Forms.TextBox();
            this.lblActionReq = new System.Windows.Forms.Label();
            this.txtActionCode = new System.Windows.Forms.TextBox();
            this.lblActionCode = new System.Windows.Forms.Label();
            this.lblActionDate = new System.Windows.Forms.Label();
            this.dtpActionDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtAuditTitle = new System.Windows.Forms.TextBox();
            this.lblAuditTitle = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtHeaderTitle = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.dgvOwners = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOwners = new System.Windows.Forms.Label();
            this.chbIsClosed = new System.Windows.Forms.CheckBox();
            this.lblIsClosed = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.detailOwnersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IsOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaceholderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaceholderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailOwnersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetail
            // 
            this.lblDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetail.Location = new System.Drawing.Point(386, 237);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(73, 25);
            this.lblDetail.TabIndex = 0;
            this.lblDetail.Text = "Detail";
            // 
            // lblDetailDescription
            // 
            this.lblDetailDescription.AutoSize = true;
            this.lblDetailDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDetailDescription.Location = new System.Drawing.Point(10, 290);
            this.lblDetailDescription.Name = "lblDetailDescription";
            this.lblDetailDescription.Size = new System.Drawing.Size(89, 20);
            this.lblDetailDescription.TabIndex = 0;
            this.lblDetailDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDescription.Location = new System.Drawing.Point(139, 265);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(693, 72);
            this.txtDescription.TabIndex = 1;
            // 
            // txtActionReq
            // 
            this.txtActionReq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActionReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtActionReq.Location = new System.Drawing.Point(139, 419);
            this.txtActionReq.MaxLength = 500;
            this.txtActionReq.Multiline = true;
            this.txtActionReq.Name = "txtActionReq";
            this.txtActionReq.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActionReq.Size = new System.Drawing.Size(693, 72);
            this.txtActionReq.TabIndex = 5;
            // 
            // lblActionReq
            // 
            this.lblActionReq.AutoSize = true;
            this.lblActionReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActionReq.Location = new System.Drawing.Point(10, 445);
            this.lblActionReq.Name = "lblActionReq";
            this.lblActionReq.Size = new System.Drawing.Size(123, 20);
            this.lblActionReq.TabIndex = 0;
            this.lblActionReq.Text = "Action Required";
            // 
            // txtActionCode
            // 
            this.txtActionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtActionCode.Location = new System.Drawing.Point(139, 343);
            this.txtActionCode.MaxLength = 3;
            this.txtActionCode.Name = "txtActionCode";
            this.txtActionCode.Size = new System.Drawing.Size(200, 22);
            this.txtActionCode.TabIndex = 2;
            // 
            // lblActionCode
            // 
            this.lblActionCode.AutoSize = true;
            this.lblActionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActionCode.Location = new System.Drawing.Point(10, 343);
            this.lblActionCode.Name = "lblActionCode";
            this.lblActionCode.Size = new System.Drawing.Size(96, 20);
            this.lblActionCode.TabIndex = 0;
            this.lblActionCode.Text = "Action Code";
            // 
            // lblActionDate
            // 
            this.lblActionDate.AutoSize = true;
            this.lblActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActionDate.Location = new System.Drawing.Point(10, 373);
            this.lblActionDate.Name = "lblActionDate";
            this.lblActionDate.Size = new System.Drawing.Size(93, 20);
            this.lblActionDate.TabIndex = 0;
            this.lblActionDate.Text = "Action Date";
            // 
            // dtpActionDate
            // 
            this.dtpActionDate.CustomFormat = " ";
            this.dtpActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActionDate.Location = new System.Drawing.Point(139, 371);
            this.dtpActionDate.Name = "dtpActionDate";
            this.dtpActionDate.Size = new System.Drawing.Size(200, 22);
            this.dtpActionDate.TabIndex = 3;
            this.dtpActionDate.ValueChanged += new System.EventHandler(this.dtpActionDate_ValueChanged);
            this.dtpActionDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpActionDate_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::IAFollowUp.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(362, 664);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCompany
            // 
            this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtCompany.Location = new System.Drawing.Point(97, 12);
            this.txtCompany.MaxLength = 3;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(735, 22);
            this.txtCompany.TabIndex = 0;
            // 
            // txtAuditTitle
            // 
            this.txtAuditTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAuditTitle.Location = new System.Drawing.Point(97, 40);
            this.txtAuditTitle.MaxLength = 500;
            this.txtAuditTitle.Multiline = true;
            this.txtAuditTitle.Name = "txtAuditTitle";
            this.txtAuditTitle.ReadOnly = true;
            this.txtAuditTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAuditTitle.Size = new System.Drawing.Size(735, 72);
            this.txtAuditTitle.TabIndex = 0;
            // 
            // lblAuditTitle
            // 
            this.lblAuditTitle.AutoSize = true;
            this.lblAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditTitle.Location = new System.Drawing.Point(11, 57);
            this.lblAuditTitle.Name = "lblAuditTitle";
            this.lblAuditTitle.Size = new System.Drawing.Size(67, 16);
            this.lblAuditTitle.TabIndex = 0;
            this.lblAuditTitle.Text = "Audit Title";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(11, 15);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 16);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company";
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtCategory.Location = new System.Drawing.Point(97, 118);
            this.txtCategory.MaxLength = 3;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(735, 22);
            this.txtCategory.TabIndex = 0;
            // 
            // txtHeaderTitle
            // 
            this.txtHeaderTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtHeaderTitle.Location = new System.Drawing.Point(97, 146);
            this.txtHeaderTitle.MaxLength = 500;
            this.txtHeaderTitle.Multiline = true;
            this.txtHeaderTitle.Name = "txtHeaderTitle";
            this.txtHeaderTitle.ReadOnly = true;
            this.txtHeaderTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHeaderTitle.Size = new System.Drawing.Size(735, 72);
            this.txtHeaderTitle.TabIndex = 0;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCategory.Location = new System.Drawing.Point(11, 121);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 16);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(11, 173);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(80, 16);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "HeaderTitle";
            // 
            // dgvOwners
            // 
            this.dgvOwners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOwners.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOwners.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOwners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOwners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FullName,
            this.Role});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOwners.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOwners.Location = new System.Drawing.Point(139, 497);
            this.dgvOwners.MultiSelect = false;
            this.dgvOwners.Name = "dgvOwners";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOwners.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOwners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOwners.Size = new System.Drawing.Size(693, 19);
            this.dgvOwners.TabIndex = 6;
            this.dgvOwners.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOwners_CellValueChanged);
            this.dgvOwners.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvOwners_CurrentCellDirtyStateChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 50;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FullName.Width = 320;
            // 
            // Role
            // 
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            this.Role.Width = 310;
            // 
            // lblOwners
            // 
            this.lblOwners.AutoSize = true;
            this.lblOwners.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblOwners.Location = new System.Drawing.Point(10, 524);
            this.lblOwners.Name = "lblOwners";
            this.lblOwners.Size = new System.Drawing.Size(63, 20);
            this.lblOwners.TabIndex = 0;
            this.lblOwners.Text = "Owners";
            // 
            // chbIsClosed
            // 
            this.chbIsClosed.AutoSize = true;
            this.chbIsClosed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbIsClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbIsClosed.Location = new System.Drawing.Point(139, 399);
            this.chbIsClosed.Name = "chbIsClosed";
            this.chbIsClosed.Size = new System.Drawing.Size(15, 14);
            this.chbIsClosed.TabIndex = 4;
            this.chbIsClosed.UseVisualStyleBackColor = true;
            // 
            // lblIsClosed
            // 
            this.lblIsClosed.AutoSize = true;
            this.lblIsClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblIsClosed.Location = new System.Drawing.Point(10, 395);
            this.lblIsClosed.Name = "lblIsClosed";
            this.lblIsClosed.Size = new System.Drawing.Size(58, 20);
            this.lblIsClosed.TabIndex = 0;
            this.lblIsClosed.Text = "Closed";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.detailOwnersBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(139, 524);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(693, 134);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // detailOwnersBindingSource
            // 
            this.detailOwnersBindingSource.DataSource = typeof(IAFollowUp.DetailOwners);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IsOwner,
            this.colId,
            this.colPlaceholderId,
            this.colPlaceholderName,
            this.colUserId,
            this.colUserName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // IsOwner
            // 
            this.IsOwner.Caption = "Owner";
            this.IsOwner.FieldName = "gcIsOwner";
            this.IsOwner.Name = "IsOwner";
            this.IsOwner.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.IsOwner.Visible = true;
            this.IsOwner.VisibleIndex = 0;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 1;
            // 
            // colPlaceholderId
            // 
            this.colPlaceholderId.Caption = "PlaceholderId";
            this.colPlaceholderId.FieldName = "Placeholder.Department.Id";
            this.colPlaceholderId.Name = "colPlaceholderId";
            this.colPlaceholderId.Visible = true;
            this.colPlaceholderId.VisibleIndex = 2;
            // 
            // colPlaceholderName
            // 
            this.colPlaceholderName.Caption = "Department";
            this.colPlaceholderName.FieldName = "Placeholder.Department.Name";
            this.colPlaceholderName.Name = "colPlaceholderName";
            this.colPlaceholderName.Visible = true;
            this.colPlaceholderName.VisibleIndex = 3;
            // 
            // colUserId
            // 
            this.colUserId.Caption = "UserId";
            this.colUserId.FieldName = "User.Id";
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = true;
            this.colUserId.VisibleIndex = 4;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Full Name";
            this.colUserName.FieldName = "User.FullName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 5;
            // 
            // FIDetailInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 716);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblIsClosed);
            this.Controls.Add(this.chbIsClosed);
            this.Controls.Add(this.lblOwners);
            this.Controls.Add(this.dgvOwners);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtHeaderTitle);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtAuditTitle);
            this.Controls.Add(this.lblAuditTitle);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpActionDate);
            this.Controls.Add(this.txtActionCode);
            this.Controls.Add(this.lblActionCode);
            this.Controls.Add(this.lblActionDate);
            this.Controls.Add(this.txtActionReq);
            this.Controls.Add(this.lblActionReq);
            this.Controls.Add(this.lblDetailDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(860, 754);
            this.Name = "FIDetailInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements Detail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailOwnersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblDetailDescription;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtActionReq;
        private System.Windows.Forms.Label lblActionReq;
        public System.Windows.Forms.TextBox txtActionCode;
        private System.Windows.Forms.Label lblActionCode;
        private System.Windows.Forms.Label lblActionDate;
        private System.Windows.Forms.DateTimePicker dtpActionDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtAuditTitle;
        private System.Windows.Forms.Label lblAuditTitle;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtHeaderTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblHeaderTitle;
        public System.Windows.Forms.DataGridView dgvOwners;
        private System.Windows.Forms.Label lblOwners;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewComboBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.CheckBox chbIsClosed;
        private System.Windows.Forms.Label lblIsClosed;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource detailOwnersBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholderId;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaceholderName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn IsOwner;
    }
}