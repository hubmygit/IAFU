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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Voting));
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbVoting = new System.Windows.Forms.GroupBox();
            this.rbForwardNo = new System.Windows.Forms.RadioButton();
            this.rbForwardAlternative = new System.Windows.Forms.RadioButton();
            this.rbForwardCompleted = new System.Windows.Forms.RadioButton();
            this.rbReturn = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.gbVoting.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCategory.Location = new System.Drawing.Point(222, 15);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 16);
            this.lblCategory.TabIndex = 70;
            this.lblCategory.Text = "Category";
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtCategory.Location = new System.Drawing.Point(291, 12);
            this.txtCategory.MaxLength = 3;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(271, 22);
            this.txtCategory.TabIndex = 71;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLblUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
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
            this.gbVoting.Location = new System.Drawing.Point(14, 83);
            this.gbVoting.Name = "gbVoting";
            this.gbVoting.Size = new System.Drawing.Size(240, 193);
            this.gbVoting.TabIndex = 73;
            this.gbVoting.TabStop = false;
            // 
            // rbForwardNo
            // 
            this.rbForwardNo.AutoSize = true;
            this.rbForwardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rbForwardNo.ForeColor = System.Drawing.Color.Green;
            this.rbForwardNo.Location = new System.Drawing.Point(15, 109);
            this.rbForwardNo.Name = "rbForwardNo";
            this.rbForwardNo.Size = new System.Drawing.Size(212, 20);
            this.rbForwardNo.TabIndex = 7;
            this.rbForwardNo.TabStop = true;
            this.rbForwardNo.Text = "Forward - (Action: Business No)";
            this.rbForwardNo.UseVisualStyleBackColor = true;
            // 
            // rbForwardAlternative
            // 
            this.rbForwardAlternative.AutoSize = true;
            this.rbForwardAlternative.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rbForwardAlternative.ForeColor = System.Drawing.Color.Green;
            this.rbForwardAlternative.Location = new System.Drawing.Point(15, 64);
            this.rbForwardAlternative.Name = "rbForwardAlternative";
            this.rbForwardAlternative.Size = new System.Drawing.Size(199, 20);
            this.rbForwardAlternative.TabIndex = 6;
            this.rbForwardAlternative.TabStop = true;
            this.rbForwardAlternative.Text = "Forward - (Action: Alternative)";
            this.rbForwardAlternative.UseVisualStyleBackColor = true;
            // 
            // rbForwardCompleted
            // 
            this.rbForwardCompleted.AutoSize = true;
            this.rbForwardCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rbForwardCompleted.ForeColor = System.Drawing.Color.Green;
            this.rbForwardCompleted.Location = new System.Drawing.Point(15, 19);
            this.rbForwardCompleted.Name = "rbForwardCompleted";
            this.rbForwardCompleted.Size = new System.Drawing.Size(195, 20);
            this.rbForwardCompleted.TabIndex = 5;
            this.rbForwardCompleted.TabStop = true;
            this.rbForwardCompleted.Text = "Forward (Action: Completed)";
            this.rbForwardCompleted.UseVisualStyleBackColor = true;
            // 
            // rbReturn
            // 
            this.rbReturn.AutoSize = true;
            this.rbReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.rbReturn.ForeColor = System.Drawing.Color.Red;
            this.rbReturn.Location = new System.Drawing.Point(15, 154);
            this.rbReturn.Name = "rbReturn";
            this.rbReturn.Size = new System.Drawing.Size(65, 20);
            this.rbReturn.TabIndex = 8;
            this.rbReturn.TabStop = true;
            this.rbReturn.Text = "Return";
            this.rbReturn.UseVisualStyleBackColor = true;
            // 
            // Voting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.gbVoting);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 480);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "Voting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Decision";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbVoting.ResumeLayout(false);
            this.gbVoting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLblUser;
        private System.Windows.Forms.GroupBox gbVoting;
        private System.Windows.Forms.RadioButton rbReturn;
        private System.Windows.Forms.RadioButton rbForwardNo;
        private System.Windows.Forms.RadioButton rbForwardAlternative;
        private System.Windows.Forms.RadioButton rbForwardCompleted;
    }
}