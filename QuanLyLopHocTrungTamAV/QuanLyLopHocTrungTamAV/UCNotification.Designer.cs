namespace QuanLyLopHocTrungTamAV
{
    partial class UCNotification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTitle_Date = new System.Windows.Forms.Panel();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.fpnlContent = new System.Windows.Forms.FlowLayoutPanel();
            this.lbContent = new System.Windows.Forms.Label();
            this.lbGroup = new System.Windows.Forms.Label();
            this.pnlTitle_Date.SuspendLayout();
            this.fpnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle_Date
            // 
            this.pnlTitle_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlTitle_Date.Controls.Add(this.lbDate);
            this.pnlTitle_Date.Controls.Add(this.lbGroup);
            this.pnlTitle_Date.Controls.Add(this.lbTitle);
            this.pnlTitle_Date.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTitle_Date.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle_Date.Name = "pnlTitle_Date";
            this.pnlTitle_Date.Size = new System.Drawing.Size(371, 105);
            this.pnlTitle_Date.TabIndex = 0;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(20, 76);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(44, 16);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "label1";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(20, 17);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(53, 20);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "label1";
            // 
            // fpnlContent
            // 
            this.fpnlContent.AutoScroll = true;
            this.fpnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpnlContent.Controls.Add(this.lbContent);
            this.fpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlContent.Location = new System.Drawing.Point(371, 0);
            this.fpnlContent.Name = "fpnlContent";
            this.fpnlContent.Size = new System.Drawing.Size(530, 105);
            this.fpnlContent.TabIndex = 1;
            // 
            // lbContent
            // 
            this.lbContent.AutoSize = true;
            this.lbContent.Location = new System.Drawing.Point(3, 0);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(44, 16);
            this.lbContent.TabIndex = 0;
            this.lbContent.Text = "label1";
            // 
            // lbGroup
            // 
            this.lbGroup.AutoSize = true;
            this.lbGroup.Location = new System.Drawing.Point(250, 76);
            this.lbGroup.Name = "lbGroup";
            this.lbGroup.Size = new System.Drawing.Size(49, 16);
            this.lbGroup.TabIndex = 1;
            this.lbGroup.Text = "Nhóm: ";
            // 
            // UCNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpnlContent);
            this.Controls.Add(this.pnlTitle_Date);
            this.Name = "UCNotification";
            this.Size = new System.Drawing.Size(901, 105);
            this.pnlTitle_Date.ResumeLayout(false);
            this.pnlTitle_Date.PerformLayout();
            this.fpnlContent.ResumeLayout(false);
            this.fpnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle_Date;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.FlowLayoutPanel fpnlContent;
        private System.Windows.Forms.Label lbContent;
        private System.Windows.Forms.Label lbGroup;
    }
}
