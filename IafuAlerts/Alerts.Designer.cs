namespace IafuAlerts
{
    partial class Alerts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alerts));
            this.btnExpireInM = new System.Windows.Forms.Button();
            this.btnExpired = new System.Windows.Forms.Button();
            this.btnExpireIn15D = new System.Windows.Forms.Button();
            this.btnNoAction15D = new System.Windows.Forms.Button();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.btnFailedEmails = new System.Windows.Forms.Button();
            this.btnTestExpireInM = new System.Windows.Forms.Button();
            this.btnTestExpired = new System.Windows.Forms.Button();
            this.btnTestFailedEmails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExpireInM
            // 
            this.btnExpireInM.Enabled = false;
            this.btnExpireInM.Location = new System.Drawing.Point(28, 22);
            this.btnExpireInM.Name = "btnExpireInM";
            this.btnExpireInM.Size = new System.Drawing.Size(120, 50);
            this.btnExpireInM.TabIndex = 0;
            this.btnExpireInM.Text = "Expire In Month";
            this.btnExpireInM.UseVisualStyleBackColor = true;
            this.btnExpireInM.Click += new System.EventHandler(this.btnExpireInM_Click);
            // 
            // btnExpired
            // 
            this.btnExpired.Enabled = false;
            this.btnExpired.Location = new System.Drawing.Point(154, 22);
            this.btnExpired.Name = "btnExpired";
            this.btnExpired.Size = new System.Drawing.Size(120, 50);
            this.btnExpired.TabIndex = 1;
            this.btnExpired.Text = "Expired";
            this.btnExpired.UseVisualStyleBackColor = true;
            this.btnExpired.Click += new System.EventHandler(this.btnExpired_Click);
            // 
            // btnExpireIn15D
            // 
            this.btnExpireIn15D.Enabled = false;
            this.btnExpireIn15D.Location = new System.Drawing.Point(280, 22);
            this.btnExpireIn15D.Name = "btnExpireIn15D";
            this.btnExpireIn15D.Size = new System.Drawing.Size(120, 50);
            this.btnExpireIn15D.TabIndex = 2;
            this.btnExpireIn15D.Text = "Expire In 15 Days";
            this.btnExpireIn15D.UseVisualStyleBackColor = true;
            this.btnExpireIn15D.Click += new System.EventHandler(this.btnExpireIn15D_Click);
            // 
            // btnNoAction15D
            // 
            this.btnNoAction15D.Enabled = false;
            this.btnNoAction15D.Location = new System.Drawing.Point(406, 22);
            this.btnNoAction15D.Name = "btnNoAction15D";
            this.btnNoAction15D.Size = new System.Drawing.Size(120, 50);
            this.btnNoAction15D.TabIndex = 3;
            this.btnNoAction15D.Text = "No Action In 15 Days";
            this.btnNoAction15D.UseVisualStyleBackColor = true;
            this.btnNoAction15D.Click += new System.EventHandler(this.btnNoAction15D_Click);
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Enabled = false;
            this.btnOpenLog.Location = new System.Drawing.Point(217, 320);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(120, 50);
            this.btnOpenLog.TabIndex = 4;
            this.btnOpenLog.Text = "Open Most Recent Log File";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // btnFailedEmails
            // 
            this.btnFailedEmails.Enabled = false;
            this.btnFailedEmails.Location = new System.Drawing.Point(154, 78);
            this.btnFailedEmails.Name = "btnFailedEmails";
            this.btnFailedEmails.Size = new System.Drawing.Size(246, 50);
            this.btnFailedEmails.TabIndex = 5;
            this.btnFailedEmails.Text = "Send IAFU Application\'s Failed Emails";
            this.btnFailedEmails.UseVisualStyleBackColor = true;
            this.btnFailedEmails.Click += new System.EventHandler(this.btnFailedEmails_Click);
            // 
            // btnTestExpireInM
            // 
            this.btnTestExpireInM.Location = new System.Drawing.Point(28, 176);
            this.btnTestExpireInM.Name = "btnTestExpireInM";
            this.btnTestExpireInM.Size = new System.Drawing.Size(120, 50);
            this.btnTestExpireInM.TabIndex = 6;
            this.btnTestExpireInM.Text = "Expire In Month";
            this.btnTestExpireInM.UseVisualStyleBackColor = true;
            this.btnTestExpireInM.Click += new System.EventHandler(this.btnTestExpireInM_Click);
            // 
            // btnTestExpired
            // 
            this.btnTestExpired.Location = new System.Drawing.Point(154, 176);
            this.btnTestExpired.Name = "btnTestExpired";
            this.btnTestExpired.Size = new System.Drawing.Size(120, 50);
            this.btnTestExpired.TabIndex = 7;
            this.btnTestExpired.Text = "Expired";
            this.btnTestExpired.UseVisualStyleBackColor = true;
            this.btnTestExpired.Click += new System.EventHandler(this.btnTestExpired_Click);
            // 
            // btnTestFailedEmails
            // 
            this.btnTestFailedEmails.Location = new System.Drawing.Point(154, 232);
            this.btnTestFailedEmails.Name = "btnTestFailedEmails";
            this.btnTestFailedEmails.Size = new System.Drawing.Size(246, 50);
            this.btnTestFailedEmails.TabIndex = 8;
            this.btnTestFailedEmails.Text = "Send IAFU Application\'s Failed Emails";
            this.btnTestFailedEmails.UseVisualStyleBackColor = true;
            this.btnTestFailedEmails.Click += new System.EventHandler(this.btnTestFailedEmails_Click);
            // 
            // Alerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 382);
            this.Controls.Add(this.btnTestFailedEmails);
            this.Controls.Add(this.btnTestExpired);
            this.Controls.Add(this.btnTestExpireInM);
            this.Controls.Add(this.btnFailedEmails);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.btnNoAction15D);
            this.Controls.Add(this.btnExpireIn15D);
            this.Controls.Add(this.btnExpired);
            this.Controls.Add(this.btnExpireInM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Alerts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IA Follow Up - Alerts";
            this.Load += new System.EventHandler(this.Alerts_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExpireInM;
        private System.Windows.Forms.Button btnExpired;
        private System.Windows.Forms.Button btnExpireIn15D;
        private System.Windows.Forms.Button btnNoAction15D;
        private System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.Button btnFailedEmails;
        private System.Windows.Forms.Button btnTestExpireInM;
        private System.Windows.Forms.Button btnTestExpired;
        private System.Windows.Forms.Button btnTestFailedEmails;
    }
}