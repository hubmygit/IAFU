namespace IAFollowUp
{
    partial class DeadlineExtension
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeadlineExtension));
            this.dtpCurrentActionDate = new System.Windows.Forms.DateTimePicker();
            this.lblCurrentActionDate = new System.Windows.Forms.Label();
            this.dtpNewActionDate = new System.Windows.Forms.DateTimePicker();
            this.lblNewActionDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpCurrentActionDate
            // 
            this.dtpCurrentActionDate.CustomFormat = " ";
            this.dtpCurrentActionDate.Enabled = false;
            this.dtpCurrentActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpCurrentActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentActionDate.Location = new System.Drawing.Point(277, 49);
            this.dtpCurrentActionDate.Name = "dtpCurrentActionDate";
            this.dtpCurrentActionDate.Size = new System.Drawing.Size(200, 22);
            this.dtpCurrentActionDate.TabIndex = 5;
            // 
            // lblCurrentActionDate
            // 
            this.lblCurrentActionDate.AutoSize = true;
            this.lblCurrentActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCurrentActionDate.Location = new System.Drawing.Point(87, 51);
            this.lblCurrentActionDate.Name = "lblCurrentActionDate";
            this.lblCurrentActionDate.Size = new System.Drawing.Size(150, 20);
            this.lblCurrentActionDate.TabIndex = 4;
            this.lblCurrentActionDate.Text = "Current Action Date";
            // 
            // dtpNewActionDate
            // 
            this.dtpNewActionDate.CustomFormat = " ";
            this.dtpNewActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpNewActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNewActionDate.Location = new System.Drawing.Point(277, 121);
            this.dtpNewActionDate.Name = "dtpNewActionDate";
            this.dtpNewActionDate.Size = new System.Drawing.Size(200, 22);
            this.dtpNewActionDate.TabIndex = 7;
            this.dtpNewActionDate.ValueChanged += new System.EventHandler(this.dtpNewActionDate_ValueChanged);
            this.dtpNewActionDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpNewActionDate_KeyDown);
            // 
            // lblNewActionDate
            // 
            this.lblNewActionDate.AutoSize = true;
            this.lblNewActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblNewActionDate.Location = new System.Drawing.Point(87, 123);
            this.lblNewActionDate.Name = "lblNewActionDate";
            this.lblNewActionDate.Size = new System.Drawing.Size(128, 20);
            this.lblNewActionDate.TabIndex = 6;
            this.lblNewActionDate.Text = "New Action Date";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::IAFollowUp.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(222, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DeadlineExtension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 282);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpNewActionDate);
            this.Controls.Add(this.lblNewActionDate);
            this.Controls.Add(this.dtpCurrentActionDate);
            this.Controls.Add(this.lblCurrentActionDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(580, 320);
            this.MinimumSize = new System.Drawing.Size(580, 320);
            this.Name = "DeadlineExtension";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deadline Extension";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCurrentActionDate;
        private System.Windows.Forms.Label lblCurrentActionDate;
        private System.Windows.Forms.DateTimePicker dtpNewActionDate;
        private System.Windows.Forms.Label lblNewActionDate;
        private System.Windows.Forms.Button btnSave;
    }
}