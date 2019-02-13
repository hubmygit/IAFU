namespace IAFollowUp
{
    partial class Voting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Voting));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbVoting = new System.Windows.Forms.GroupBox();
            this.rbReturn = new System.Windows.Forms.RadioButton();
            this.rbForwardNo = new System.Windows.Forms.RadioButton();
            this.rbForwardAlternative = new System.Windows.Forms.RadioButton();
            this.rbForwardCompleted = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.fIDetailVotingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditorRoleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassificationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCurrent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuditorRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserFname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassificationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassificationDecisionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusStrip1.SuspendLayout();
            this.gbVoting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailVotingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLblUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 360);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(824, 22);
            this.statusStrip1.TabIndex = 72;
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
            // gbVoting
            // 
            this.gbVoting.Controls.Add(this.rbReturn);
            this.gbVoting.Controls.Add(this.rbForwardNo);
            this.gbVoting.Controls.Add(this.rbForwardAlternative);
            this.gbVoting.Controls.Add(this.rbForwardCompleted);
            this.gbVoting.Location = new System.Drawing.Point(14, 34);
            this.gbVoting.Name = "gbVoting";
            this.gbVoting.Size = new System.Drawing.Size(251, 193);
            this.gbVoting.TabIndex = 73;
            this.gbVoting.TabStop = false;
            this.gbVoting.Text = "Decision";
            // 
            // rbReturn
            // 
            this.rbReturn.AutoSize = true;
            this.rbReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rbReturn.ForeColor = System.Drawing.Color.Red;
            this.rbReturn.Image = global::IAFollowUp.Properties.Resources.Failing_16x;
            this.rbReturn.Location = new System.Drawing.Point(15, 159);
            this.rbReturn.Name = "rbReturn";
            this.rbReturn.Size = new System.Drawing.Size(81, 20);
            this.rbReturn.TabIndex = 8;
            this.rbReturn.TabStop = true;
            this.rbReturn.Text = "Return";
            this.rbReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbReturn.UseVisualStyleBackColor = true;
            // 
            // rbForwardNo
            // 
            this.rbForwardNo.AutoSize = true;
            this.rbForwardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rbForwardNo.ForeColor = System.Drawing.Color.Green;
            this.rbForwardNo.Image = global::IAFollowUp.Properties.Resources.Passing_16x;
            this.rbForwardNo.Location = new System.Drawing.Point(15, 114);
            this.rbForwardNo.Name = "rbForwardNo";
            this.rbForwardNo.Size = new System.Drawing.Size(228, 20);
            this.rbForwardNo.TabIndex = 7;
            this.rbForwardNo.TabStop = true;
            this.rbForwardNo.Text = "Forward - (Action: Business No)";
            this.rbForwardNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbForwardNo.UseVisualStyleBackColor = true;
            // 
            // rbForwardAlternative
            // 
            this.rbForwardAlternative.AutoSize = true;
            this.rbForwardAlternative.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rbForwardAlternative.ForeColor = System.Drawing.Color.Green;
            this.rbForwardAlternative.Image = global::IAFollowUp.Properties.Resources.Passing_16x;
            this.rbForwardAlternative.Location = new System.Drawing.Point(15, 69);
            this.rbForwardAlternative.Name = "rbForwardAlternative";
            this.rbForwardAlternative.Size = new System.Drawing.Size(215, 20);
            this.rbForwardAlternative.TabIndex = 6;
            this.rbForwardAlternative.TabStop = true;
            this.rbForwardAlternative.Text = "Forward - (Action: Alternative)";
            this.rbForwardAlternative.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbForwardAlternative.UseVisualStyleBackColor = true;
            // 
            // rbForwardCompleted
            // 
            this.rbForwardCompleted.AutoSize = true;
            this.rbForwardCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rbForwardCompleted.ForeColor = System.Drawing.Color.Green;
            this.rbForwardCompleted.Image = global::IAFollowUp.Properties.Resources.Passing_16x;
            this.rbForwardCompleted.Location = new System.Drawing.Point(15, 24);
            this.rbForwardCompleted.Name = "rbForwardCompleted";
            this.rbForwardCompleted.Size = new System.Drawing.Size(211, 20);
            this.rbForwardCompleted.TabIndex = 5;
            this.rbForwardCompleted.TabStop = true;
            this.rbForwardCompleted.Text = "Forward (Action: Completed)";
            this.rbForwardCompleted.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbForwardCompleted.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::IAFollowUp.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(352, 317);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 74;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.fIDetailVotingBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(272, 41);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(540, 186);
            this.gridControl1.TabIndex = 75;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // fIDetailVotingBindingSource
            // 
            this.fIDetailVotingBindingSource.DataSource = typeof(IAFollowUp.FIDetailVoting);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDetailId,
            this.colUserId,
            this.colAuditorRoleId,
            this.colClassificationId,
            this.colIsCurrent,
            this.colAuditorRoleName,
            this.colUserFname,
            this.colClassificationName,
            this.colClassificationDecisionName,
            this.colInsDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
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
            // colUserId
            // 
            this.colUserId.Caption = "UserId";
            this.colUserId.FieldName = "User.Id";
            this.colUserId.Name = "colUserId";
            // 
            // colAuditorRoleId
            // 
            this.colAuditorRoleId.Caption = "AuditorRoleId";
            this.colAuditorRoleId.FieldName = "AuditorRole.Id";
            this.colAuditorRoleId.Name = "colAuditorRoleId";
            // 
            // colClassificationId
            // 
            this.colClassificationId.Caption = "ClassificationId";
            this.colClassificationId.FieldName = "Classification.Id";
            this.colClassificationId.Name = "colClassificationId";
            // 
            // colIsCurrent
            // 
            this.colIsCurrent.FieldName = "IsCurrent";
            this.colIsCurrent.Name = "colIsCurrent";
            // 
            // colAuditorRoleName
            // 
            this.colAuditorRoleName.Caption = "Role";
            this.colAuditorRoleName.FieldName = "AuditorRole.Name";
            this.colAuditorRoleName.Name = "colAuditorRoleName";
            this.colAuditorRoleName.Visible = true;
            this.colAuditorRoleName.VisibleIndex = 0;
            // 
            // colUserFname
            // 
            this.colUserFname.Caption = "Full Name";
            this.colUserFname.FieldName = "User.FullName";
            this.colUserFname.Name = "colUserFname";
            this.colUserFname.Visible = true;
            this.colUserFname.VisibleIndex = 1;
            // 
            // colClassificationName
            // 
            this.colClassificationName.Caption = "Classification";
            this.colClassificationName.FieldName = "Classification.Name";
            this.colClassificationName.Name = "colClassificationName";
            this.colClassificationName.Visible = true;
            this.colClassificationName.VisibleIndex = 2;
            // 
            // colClassificationDecisionName
            // 
            this.colClassificationDecisionName.Caption = "Decision";
            this.colClassificationDecisionName.FieldName = "Classification.Decision.Name";
            this.colClassificationDecisionName.Name = "colClassificationDecisionName";
            this.colClassificationDecisionName.Visible = true;
            this.colClassificationDecisionName.VisibleIndex = 3;
            // 
            // colInsDate
            // 
            this.colInsDate.FieldName = "InsDate";
            this.colInsDate.Name = "colInsDate";
            this.colInsDate.Visible = true;
            this.colInsDate.VisibleIndex = 4;
            // 
            // Voting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 382);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbVoting);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(840, 420);
            this.Name = "Voting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Decision";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbVoting.ResumeLayout(false);
            this.gbVoting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIDetailVotingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
        private System.Windows.Forms.GroupBox gbVoting;
        private System.Windows.Forms.RadioButton rbReturn;
        private System.Windows.Forms.RadioButton rbForwardNo;
        private System.Windows.Forms.RadioButton rbForwardAlternative;
        private System.Windows.Forms.RadioButton rbForwardCompleted;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource fIDetailVotingBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailId;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditorRoleId;
        private DevExpress.XtraGrid.Columns.GridColumn colClassificationId;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCurrent;
        private DevExpress.XtraGrid.Columns.GridColumn colInsDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUserFname;
        private DevExpress.XtraGrid.Columns.GridColumn colAuditorRoleName;
        private DevExpress.XtraGrid.Columns.GridColumn colClassificationName;
        private DevExpress.XtraGrid.Columns.GridColumn colClassificationDecisionName;
    }
}