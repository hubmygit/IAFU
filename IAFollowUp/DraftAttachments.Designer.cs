﻿namespace IAFollowUp
{
    partial class DraftAttachments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DraftAttachments));
            this.lvAttachedFiles = new System.Windows.Forms.ListView();
            this.AttachedFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::IAFollowUp.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(182, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnOpenFile.Image = global::IAFollowUp.Properties.Resources.OpenAttachment_16x;
            this.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.Location = new System.Drawing.Point(29, 57);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(120, 28);
            this.btnOpenFile.TabIndex = 8;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAll.Image")));
            this.btnRemoveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveAll.Location = new System.Drawing.Point(29, 137);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(120, 28);
            this.btnRemoveAll.TabIndex = 10;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRemoveFile.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveFile.Image")));
            this.btnRemoveFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveFile.Location = new System.Drawing.Point(29, 97);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(120, 28);
            this.btnRemoveFile.TabIndex = 9;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAddFiles.Image = global::IAFollowUp.Properties.Resources.AddAttachment_16x;
            this.btnAddFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFiles.Location = new System.Drawing.Point(31, 17);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(120, 28);
            this.btnAddFiles.TabIndex = 7;
            this.btnAddFiles.Text = "Add File(s)";
            this.btnAddFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFiles.UseVisualStyleBackColor = true;
            // 
            // DraftAttachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.lvAttachedFiles);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.btnAddFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "DraftAttachments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attachments";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView lvAttachedFiles;
        private System.Windows.Forms.ColumnHeader AttachedFiles;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenFile;
        public System.Windows.Forms.Button btnRemoveAll;
        public System.Windows.Forms.Button btnRemoveFile;
        public System.Windows.Forms.Button btnAddFiles;
    }
}