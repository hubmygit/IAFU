namespace IAFollowUp
{
    partial class ViewRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewRole));
            this.dgvRoleView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAuditor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAuditee = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PassExp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIupdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleView)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRoleView
            // 
            this.dgvRoleView.AllowUserToAddRows = false;
            this.dgvRoleView.AllowUserToDeleteRows = false;
            this.dgvRoleView.AllowUserToOrderColumns = true;
            this.dgvRoleView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRoleView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoleView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoleView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.RoleName,
            this.IsAuditor,
            this.IsAuditee,
            this.IsAdmin,
            this.PassExp,
            this.InsDate});
            this.dgvRoleView.ContextMenuStrip = this.cmsOnGrid;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoleView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoleView.Location = new System.Drawing.Point(0, 49);
            this.dgvRoleView.MultiSelect = false;
            this.dgvRoleView.Name = "dgvRoleView";
            this.dgvRoleView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoleView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoleView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoleView.Size = new System.Drawing.Size(964, 393);
            this.dgvRoleView.TabIndex = 15;
            this.dgvRoleView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvRoleView_MouseDown);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 50;
            // 
            // RoleName
            // 
            this.RoleName.HeaderText = "Role Name";
            this.RoleName.Name = "RoleName";
            this.RoleName.ReadOnly = true;
            this.RoleName.Width = 280;
            // 
            // IsAuditor
            // 
            this.IsAuditor.HeaderText = "Auditor";
            this.IsAuditor.Name = "IsAuditor";
            this.IsAuditor.ReadOnly = true;
            this.IsAuditor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsAuditor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsAuditee
            // 
            this.IsAuditee.HeaderText = "Auditee";
            this.IsAuditee.Name = "IsAuditee";
            this.IsAuditee.ReadOnly = true;
            // 
            // IsAdmin
            // 
            this.IsAdmin.HeaderText = "Admin";
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.ReadOnly = true;
            // 
            // PassExp
            // 
            this.PassExp.HeaderText = "Password Exp";
            this.PassExp.Name = "PassExp";
            this.PassExp.ReadOnly = true;
            this.PassExp.Width = 140;
            // 
            // InsDate
            // 
            this.InsDate.HeaderText = "InsDate";
            this.InsDate.Name = "InsDate";
            this.InsDate.ReadOnly = true;
            this.InsDate.Width = 170;
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIupdate});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(95, 26);
            // 
            // MIupdate
            // 
            this.MIupdate.Name = "MIupdate";
            this.MIupdate.Size = new System.Drawing.Size(94, 22);
            this.MIupdate.Text = "Edit";
            this.MIupdate.Click += new System.EventHandler(this.MIupdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 31);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "New Role";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // ViewRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 442);
            this.Controls.Add(this.dgvRoleView);
            this.Controls.Add(this.btnNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(980, 480);
            this.Name = "ViewRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View / Edit Role";
            this.Load += new System.EventHandler(this.ViewRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleView)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvRoleView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAuditor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAuditee;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsDate;
        public System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem MIupdate;
        private System.Windows.Forms.Button btnNew;
    }
}