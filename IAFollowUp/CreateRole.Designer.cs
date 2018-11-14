namespace IAFollowUp
{
    partial class CreateRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRole));
            this.chbIsAdmin = new System.Windows.Forms.CheckBox();
            this.chbIsAuditee = new System.Windows.Forms.CheckBox();
            this.chbIsAuditor = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chbIsAdmin
            // 
            this.chbIsAdmin.AutoSize = true;
            this.chbIsAdmin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbIsAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbIsAdmin.Location = new System.Drawing.Point(46, 154);
            this.chbIsAdmin.Name = "chbIsAdmin";
            this.chbIsAdmin.Size = new System.Drawing.Size(105, 20);
            this.chbIsAdmin.TabIndex = 10;
            this.chbIsAdmin.Text = "Administrator";
            this.chbIsAdmin.UseVisualStyleBackColor = true;
            // 
            // chbIsAuditee
            // 
            this.chbIsAuditee.AutoSize = true;
            this.chbIsAuditee.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbIsAuditee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbIsAuditee.Location = new System.Drawing.Point(78, 115);
            this.chbIsAuditee.Name = "chbIsAuditee";
            this.chbIsAuditee.Size = new System.Drawing.Size(73, 20);
            this.chbIsAuditee.TabIndex = 9;
            this.chbIsAuditee.Text = "Auditee";
            this.chbIsAuditee.UseVisualStyleBackColor = true;
            // 
            // chbIsAuditor
            // 
            this.chbIsAuditor.AutoSize = true;
            this.chbIsAuditor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbIsAuditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbIsAuditor.Location = new System.Drawing.Point(82, 76);
            this.chbIsAuditor.Name = "chbIsAuditor";
            this.chbIsAuditor.Size = new System.Drawing.Size(69, 20);
            this.chbIsAuditor.TabIndex = 8;
            this.chbIsAuditor.Text = "Auditor";
            this.chbIsAuditor.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblName.Location = new System.Drawing.Point(56, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 16);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Role Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtName.Location = new System.Drawing.Point(139, 38);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 22);
            this.txtName.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::IAFollowUp.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(182, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // CreateRole
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chbIsAdmin);
            this.Controls.Add(this.chbIsAuditee);
            this.Controls.Add(this.chbIsAuditor);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "CreateRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Role";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chbIsAdmin;
        private System.Windows.Forms.CheckBox chbIsAuditee;
        private System.Windows.Forms.CheckBox chbIsAuditor;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
    }
}