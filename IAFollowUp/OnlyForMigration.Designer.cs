namespace IAFollowUp
{
    partial class OnlyForMigration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlyForMigration));
            this.dtpALInsDt = new System.Windows.Forms.DateTimePicker();
            this.lblALInsDt = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblActivityDescription = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpALInsDt
            // 
            this.dtpALInsDt.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpALInsDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtpALInsDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpALInsDt.Location = new System.Drawing.Point(281, 107);
            this.dtpALInsDt.Name = "dtpALInsDt";
            this.dtpALInsDt.Size = new System.Drawing.Size(180, 22);
            this.dtpALInsDt.TabIndex = 0;
            // 
            // lblALInsDt
            // 
            this.lblALInsDt.AutoSize = true;
            this.lblALInsDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblALInsDt.Location = new System.Drawing.Point(124, 110);
            this.lblALInsDt.Name = "lblALInsDt";
            this.lblALInsDt.Size = new System.Drawing.Size(151, 16);
            this.lblALInsDt.TabIndex = 1;
            this.lblALInsDt.Text = "Activity Log [Insert Date]";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Location = new System.Drawing.Point(255, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblActivityDescription
            // 
            this.lblActivityDescription.AutoSize = true;
            this.lblActivityDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblActivityDescription.Location = new System.Drawing.Point(124, 75);
            this.lblActivityDescription.Name = "lblActivityDescription";
            this.lblActivityDescription.Size = new System.Drawing.Size(124, 16);
            this.lblActivityDescription.TabIndex = 3;
            this.lblActivityDescription.Text = "ActivityDescription: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(281, 21);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Text = "OnlyForMigration@moh.gr";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblEmail.Location = new System.Drawing.Point(124, 22);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 16);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email: ";
            // 
            // OnlyForMigration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 212);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblActivityDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblALInsDt);
            this.Controls.Add(this.dtpALInsDt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 250);
            this.MinimumSize = new System.Drawing.Size(600, 250);
            this.Name = "OnlyForMigration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Only For Migration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpALInsDt;
        private System.Windows.Forms.Label lblALInsDt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblActivityDescription;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
    }
}