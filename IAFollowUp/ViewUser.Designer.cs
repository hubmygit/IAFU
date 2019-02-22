namespace IAFollowUp
{
    partial class ViewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUser));
            this.dgvUserView = new System.Windows.Forms.DataGridView();
            this.cmsOnGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIupdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MIinitPass = new System.Windows.Forms.ToolStripMenuItem();
            this.MIdisable = new System.Windows.Forms.ToolStripMenuItem();
            this.MIenable = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasActivePassword = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserView)).BeginInit();
            this.cmsOnGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUserView
            // 
            this.dgvUserView.AllowUserToAddRows = false;
            this.dgvUserView.AllowUserToDeleteRows = false;
            this.dgvUserView.AllowUserToOrderColumns = true;
            this.dgvUserView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.UserName,
            this.FullName,
            this.Email,
            this.Role,
            this.InsDate,
            this.HasActivePassword});
            this.dgvUserView.ContextMenuStrip = this.cmsOnGrid;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserView.Location = new System.Drawing.Point(0, 49);
            this.dgvUserView.MultiSelect = false;
            this.dgvUserView.Name = "dgvUserView";
            this.dgvUserView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserView.Size = new System.Drawing.Size(1034, 393);
            this.dgvUserView.TabIndex = 1;
            this.dgvUserView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvUserView_MouseDown);
            // 
            // cmsOnGrid
            // 
            this.cmsOnGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIupdate,
            this.MIinitPass,
            this.MIdisable,
            this.MIenable});
            this.cmsOnGrid.Name = "cmsOnGrid";
            this.cmsOnGrid.Size = new System.Drawing.Size(195, 92);
            // 
            // MIupdate
            // 
            this.MIupdate.Name = "MIupdate";
            this.MIupdate.Size = new System.Drawing.Size(194, 22);
            this.MIupdate.Text = "Edit";
            this.MIupdate.Click += new System.EventHandler(this.MIupdate_Click);
            // 
            // MIinitPass
            // 
            this.MIinitPass.Name = "MIinitPass";
            this.MIinitPass.Size = new System.Drawing.Size(194, 22);
            this.MIinitPass.Text = "Initialize Password";
            this.MIinitPass.Click += new System.EventHandler(this.MIinitPass_Click);
            // 
            // MIdisable
            // 
            this.MIdisable.Name = "MIdisable";
            this.MIdisable.Size = new System.Drawing.Size(194, 22);
            this.MIdisable.Text = "Disable";
            this.MIdisable.Click += new System.EventHandler(this.MIdisable_Click);
            // 
            // MIenable
            // 
            this.MIenable.Name = "MIenable";
            this.MIenable.Size = new System.Drawing.Size(194, 22);
            this.MIenable.Text = "Enable (Last password)";
            this.MIenable.Click += new System.EventHandler(this.MIenable_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 31);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New User";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 180;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 260;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // Role
            // 
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            this.Role.Width = 130;
            // 
            // InsDate
            // 
            this.InsDate.HeaderText = "InsDate";
            this.InsDate.Name = "InsDate";
            this.InsDate.ReadOnly = true;
            this.InsDate.Width = 170;
            // 
            // HasActivePassword
            // 
            this.HasActivePassword.HeaderText = "Active";
            this.HasActivePassword.Name = "HasActivePassword";
            this.HasActivePassword.ReadOnly = true;
            this.HasActivePassword.Width = 80;
            // 
            // ViewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 442);
            this.Controls.Add(this.dgvUserView);
            this.Controls.Add(this.btnNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1050, 480);
            this.Name = "ViewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View User";
            this.Load += new System.EventHandler(this.ViewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserView)).EndInit();
            this.cmsOnGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvUserView;
        public System.Windows.Forms.ContextMenuStrip cmsOnGrid;
        private System.Windows.Forms.ToolStripMenuItem MIupdate;
        private System.Windows.Forms.ToolStripMenuItem MIinitPass;
        private System.Windows.Forms.ToolStripMenuItem MIdisable;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ToolStripMenuItem MIenable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasActivePassword;
    }
}