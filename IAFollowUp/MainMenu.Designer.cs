namespace IAFollowUp
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.auditorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertNewAuditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewChangeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLblUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(603, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLblUser
            // 
            this.tsStatusLblUser.BackColor = System.Drawing.SystemColors.Control;
            this.tsStatusLblUser.Image = global::IAFollowUp.Properties.Resources.User_16x;
            this.tsStatusLblUser.Name = "tsStatusLblUser";
            this.tsStatusLblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsStatusLblUser.Size = new System.Drawing.Size(103, 17);
            this.tsStatusLblUser.Text = "User: Unknown";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auditorsToolStripMenuItem,
            this.auditeesToolStripMenuItem,
            this.administratorToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(603, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // auditorsToolStripMenuItem
            // 
            this.auditorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auditViewToolStripMenuItem,
            this.insertNewAuditToolStripMenuItem});
            this.auditorsToolStripMenuItem.Name = "auditorsToolStripMenuItem";
            this.auditorsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.auditorsToolStripMenuItem.Tag = "1";
            this.auditorsToolStripMenuItem.Text = "Auditors";
            this.auditorsToolStripMenuItem.Visible = false;
            // 
            // auditViewToolStripMenuItem
            // 
            this.auditViewToolStripMenuItem.Name = "auditViewToolStripMenuItem";
            this.auditViewToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.auditViewToolStripMenuItem.Tag = "";
            this.auditViewToolStripMenuItem.Text = "Audit View";
            this.auditViewToolStripMenuItem.Click += new System.EventHandler(this.auditViewToolStripMenuItem_Click);
            // 
            // insertNewAuditToolStripMenuItem
            // 
            this.insertNewAuditToolStripMenuItem.Name = "insertNewAuditToolStripMenuItem";
            this.insertNewAuditToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.insertNewAuditToolStripMenuItem.Text = "Insert New Audit";
            this.insertNewAuditToolStripMenuItem.Click += new System.EventHandler(this.insertNewAuditToolStripMenuItem_Click);
            // 
            // auditeesToolStripMenuItem
            // 
            this.auditeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem1});
            this.auditeesToolStripMenuItem.Name = "auditeesToolStripMenuItem";
            this.auditeesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.auditeesToolStripMenuItem.Tag = "2";
            this.auditeesToolStripMenuItem.Text = "Auditees";
            this.auditeesToolStripMenuItem.Visible = false;
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
            this.testToolStripMenuItem1.Tag = "1";
            this.testToolStripMenuItem1.Text = "Test";
            // 
            // administratorToolStripMenuItem
            // 
            this.administratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRolesToolStripMenuItem,
            this.createRoleToolStripMenuItem,
            this.viewUsersToolStripMenuItem,
            this.createUserToolStripMenuItem,
            this.viewChangeLogToolStripMenuItem});
            this.administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            this.administratorToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.administratorToolStripMenuItem.Tag = "3";
            this.administratorToolStripMenuItem.Text = "Administrator";
            this.administratorToolStripMenuItem.Visible = false;
            // 
            // viewRolesToolStripMenuItem
            // 
            this.viewRolesToolStripMenuItem.Name = "viewRolesToolStripMenuItem";
            this.viewRolesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.viewRolesToolStripMenuItem.Text = "View / Edit Roles";
            this.viewRolesToolStripMenuItem.Click += new System.EventHandler(this.viewRolesToolStripMenuItem_Click);
            // 
            // createRoleToolStripMenuItem
            // 
            this.createRoleToolStripMenuItem.Name = "createRoleToolStripMenuItem";
            this.createRoleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.createRoleToolStripMenuItem.Text = "Create New Role";
            this.createRoleToolStripMenuItem.Click += new System.EventHandler(this.createRoleToolStripMenuItem_Click);
            // 
            // viewUsersToolStripMenuItem
            // 
            this.viewUsersToolStripMenuItem.Name = "viewUsersToolStripMenuItem";
            this.viewUsersToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.viewUsersToolStripMenuItem.Text = "View / Edit Users";
            this.viewUsersToolStripMenuItem.Click += new System.EventHandler(this.viewUsersToolStripMenuItem_Click);
            // 
            // createUserToolStripMenuItem
            // 
            this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            this.createUserToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.createUserToolStripMenuItem.Text = "Create New User";
            this.createUserToolStripMenuItem.Click += new System.EventHandler(this.createUserToolStripMenuItem_Click);
            // 
            // viewChangeLogToolStripMenuItem
            // 
            this.viewChangeLogToolStripMenuItem.Name = "viewChangeLogToolStripMenuItem";
            this.viewChangeLogToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.viewChangeLogToolStripMenuItem.Text = "View Change Log";
            this.viewChangeLogToolStripMenuItem.Click += new System.EventHandler(this.viewChangeLogToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::IAFollowUp.Properties.Resources.InternalAuditFollowUp_MainImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(603, 404);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(619, 442);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Internal Audit";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem auditorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertNewAuditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewChangeLogToolStripMenuItem;
    }
}