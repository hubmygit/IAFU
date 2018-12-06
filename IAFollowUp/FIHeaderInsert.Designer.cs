namespace IAFollowUp
{
    partial class FIHeaderInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIHeaderInsert));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.txtHeaderTitle = new System.Windows.Forms.TextBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtAuditTitle = new System.Windows.Forms.TextBox();
            this.lblAuditTitle = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeader.Location = new System.Drawing.Point(383, 149);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(79, 24);
            this.lblHeader.TabIndex = 61;
            this.lblHeader.Text = "Header";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCategory.Location = new System.Drawing.Point(10, 273);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(73, 20);
            this.lblCategory.TabIndex = 60;
            this.lblCategory.Text = "Category";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(91, 273);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(250, 24);
            this.cbCategory.TabIndex = 57;
            // 
            // txtHeaderTitle
            // 
            this.txtHeaderTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtHeaderTitle.Location = new System.Drawing.Point(91, 176);
            this.txtHeaderTitle.MaxLength = 500;
            this.txtHeaderTitle.Multiline = true;
            this.txtHeaderTitle.Name = "txtHeaderTitle";
            this.txtHeaderTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHeaderTitle.Size = new System.Drawing.Size(741, 72);
            this.txtHeaderTitle.TabIndex = 56;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(10, 197);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(38, 20);
            this.lblHeaderTitle.TabIndex = 59;
            this.lblHeaderTitle.Text = "Title";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::IAFollowUp.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(362, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 58;
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
            this.txtCompany.Location = new System.Drawing.Point(91, 6);
            this.txtCompany.MaxLength = 3;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(741, 22);
            this.txtCompany.TabIndex = 65;
            // 
            // txtAuditTitle
            // 
            this.txtAuditTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAuditTitle.Location = new System.Drawing.Point(91, 34);
            this.txtAuditTitle.MaxLength = 500;
            this.txtAuditTitle.Multiline = true;
            this.txtAuditTitle.Name = "txtAuditTitle";
            this.txtAuditTitle.ReadOnly = true;
            this.txtAuditTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAuditTitle.Size = new System.Drawing.Size(741, 72);
            this.txtAuditTitle.TabIndex = 62;
            // 
            // lblAuditTitle
            // 
            this.lblAuditTitle.AutoSize = true;
            this.lblAuditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAuditTitle.Location = new System.Drawing.Point(11, 51);
            this.lblAuditTitle.Name = "lblAuditTitle";
            this.lblAuditTitle.Size = new System.Drawing.Size(67, 16);
            this.lblAuditTitle.TabIndex = 64;
            this.lblAuditTitle.Text = "Audit Title";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCompany.Location = new System.Drawing.Point(11, 9);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(66, 16);
            this.lblCompany.TabIndex = 63;
            this.lblCompany.Text = "Company";
            // 
            // FIHeaderInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 462);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtAuditTitle);
            this.Controls.Add(this.lblAuditTitle);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.txtHeaderTitle);
            this.Controls.Add(this.lblHeaderTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1500, 500);
            this.MinimumSize = new System.Drawing.Size(860, 500);
            this.Name = "FIHeaderInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements Header";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox txtHeaderTitle;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtAuditTitle;
        private System.Windows.Forms.Label lblAuditTitle;
        private System.Windows.Forms.Label lblCompany;
    }
}