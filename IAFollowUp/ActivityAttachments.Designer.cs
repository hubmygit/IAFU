namespace IAFollowUp
{
    partial class ActivityAttachments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityAttachments));
            this.lvAttachedFiles = new System.Windows.Forms.ListView();
            this.AttachedFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvAttachedFiles
            // 
            this.lvAttachedFiles.AllowDrop = true;
            this.lvAttachedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttachedFiles});
            this.lvAttachedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lvAttachedFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvAttachedFiles.Location = new System.Drawing.Point(175, 17);
            this.lvAttachedFiles.MultiSelect = false;
            this.lvAttachedFiles.Name = "lvAttachedFiles";
            this.lvAttachedFiles.Size = new System.Drawing.Size(280, 148);
            this.lvAttachedFiles.TabIndex = 11;
            this.lvAttachedFiles.UseCompatibleStateImageBehavior = false;
            this.lvAttachedFiles.View = System.Windows.Forms.View.Details;
            // 
            // AttachedFiles
            // 
            this.AttachedFiles.Text = "Sample Files";
            this.AttachedFiles.Width = 250;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnOpenFile.Image = global::IAFollowUp.Properties.Resources.OpenAttachment_16x;
            this.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.Location = new System.Drawing.Point(29, 16);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(120, 28);
            this.btnOpenFile.TabIndex = 8;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // ActivityAttachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 187);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.lvAttachedFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 225);
            this.MinimumSize = new System.Drawing.Size(500, 225);
            this.Name = "ActivityAttachments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attachments";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOpenFile;
        public System.Windows.Forms.ListView lvAttachedFiles;
        private System.Windows.Forms.ColumnHeader AttachedFiles;
    }
}