namespace IAFollowUp
{
    partial class FIView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIView));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCreateNewHeader = new System.Windows.Forms.Button();
            this.btnCreateNewDetail = new System.Windows.Forms.Button();
            this.btnUpdateDetail = new System.Windows.Forms.Button();
            this.btnUpdateHeader = new System.Windows.Forms.Button();
            this.btnDeleteDetail = new System.Windows.Forms.Button();
            this.btnDeleteHeader = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(984, 75);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnCreateNewHeader
            // 
            this.btnCreateNewHeader.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnCreateNewHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewHeader.Location = new System.Drawing.Point(12, 131);
            this.btnCreateNewHeader.Name = "btnCreateNewHeader";
            this.btnCreateNewHeader.Size = new System.Drawing.Size(120, 45);
            this.btnCreateNewHeader.TabIndex = 36;
            this.btnCreateNewHeader.Text = "New Header";
            this.btnCreateNewHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewHeader.UseVisualStyleBackColor = true;
            this.btnCreateNewHeader.Click += new System.EventHandler(this.btnCreateNewHeader_Click);
            // 
            // btnCreateNewDetail
            // 
            this.btnCreateNewDetail.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnCreateNewDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewDetail.Location = new System.Drawing.Point(138, 131);
            this.btnCreateNewDetail.Name = "btnCreateNewDetail";
            this.btnCreateNewDetail.Size = new System.Drawing.Size(120, 45);
            this.btnCreateNewDetail.TabIndex = 37;
            this.btnCreateNewDetail.Text = "New Detail";
            this.btnCreateNewDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewDetail.UseVisualStyleBackColor = true;
            // 
            // btnUpdateDetail
            // 
            this.btnUpdateDetail.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnUpdateDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateDetail.Location = new System.Drawing.Point(138, 199);
            this.btnUpdateDetail.Name = "btnUpdateDetail";
            this.btnUpdateDetail.Size = new System.Drawing.Size(120, 45);
            this.btnUpdateDetail.TabIndex = 39;
            this.btnUpdateDetail.Text = "Upd Detail";
            this.btnUpdateDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateDetail.UseVisualStyleBackColor = true;
            // 
            // btnUpdateHeader
            // 
            this.btnUpdateHeader.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnUpdateHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateHeader.Location = new System.Drawing.Point(12, 199);
            this.btnUpdateHeader.Name = "btnUpdateHeader";
            this.btnUpdateHeader.Size = new System.Drawing.Size(120, 45);
            this.btnUpdateHeader.TabIndex = 38;
            this.btnUpdateHeader.Text = "Upd Header";
            this.btnUpdateHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateHeader.UseVisualStyleBackColor = true;
            this.btnUpdateHeader.Click += new System.EventHandler(this.btnUpdateHeader_Click);
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnDeleteDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDetail.Location = new System.Drawing.Point(138, 269);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Size = new System.Drawing.Size(120, 45);
            this.btnDeleteDetail.TabIndex = 41;
            this.btnDeleteDetail.Text = "Del Detail";
            this.btnDeleteDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            // 
            // btnDeleteHeader
            // 
            this.btnDeleteHeader.Image = global::IAFollowUp.Properties.Resources.Create_32x;
            this.btnDeleteHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteHeader.Location = new System.Drawing.Point(12, 269);
            this.btnDeleteHeader.Name = "btnDeleteHeader";
            this.btnDeleteHeader.Size = new System.Drawing.Size(120, 45);
            this.btnDeleteHeader.TabIndex = 40;
            this.btnDeleteHeader.Text = "Del Header";
            this.btnDeleteHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteHeader.UseVisualStyleBackColor = true;
            this.btnDeleteHeader.Click += new System.EventHandler(this.btnDeleteHeader_Click);
            // 
            // FIView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnDeleteDetail);
            this.Controls.Add(this.btnDeleteHeader);
            this.Controls.Add(this.btnUpdateDetail);
            this.Controls.Add(this.btnUpdateHeader);
            this.Controls.Add(this.btnCreateNewDetail);
            this.Controls.Add(this.btnCreateNewHeader);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FIView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Findings and Improvements View";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnCreateNewHeader;
        private System.Windows.Forms.Button btnCreateNewDetail;
        private System.Windows.Forms.Button btnUpdateDetail;
        private System.Windows.Forms.Button btnUpdateHeader;
        private System.Windows.Forms.Button btnDeleteDetail;
        private System.Windows.Forms.Button btnDeleteHeader;
    }
}