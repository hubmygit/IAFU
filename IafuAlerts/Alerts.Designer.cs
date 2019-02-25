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
            this.SuspendLayout();
            // 
            // btnExpireInM
            // 
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
            this.btnOpenLog.Location = new System.Drawing.Point(217, 170);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(120, 50);
            this.btnOpenLog.TabIndex = 4;
            this.btnOpenLog.Text = "Open Most Recent Log File";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // Alerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 232);
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
    }
}