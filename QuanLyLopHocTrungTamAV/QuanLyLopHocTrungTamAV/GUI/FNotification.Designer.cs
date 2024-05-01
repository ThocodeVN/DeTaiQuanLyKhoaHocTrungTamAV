namespace QuanLyLopHocTrungTamAV.GUI
{
    partial class FNotification
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
            this.fpnlShowNote = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateNote = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fpnlShowNote
            // 
            this.fpnlShowNote.AutoScroll = true;
            this.fpnlShowNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fpnlShowNote.Location = new System.Drawing.Point(0, 53);
            this.fpnlShowNote.Name = "fpnlShowNote";
            this.fpnlShowNote.Size = new System.Drawing.Size(818, 547);
            this.fpnlShowNote.TabIndex = 0;
            // 
            // btnCreateNote
            // 
            this.btnCreateNote.Location = new System.Drawing.Point(620, 12);
            this.btnCreateNote.Name = "btnCreateNote";
            this.btnCreateNote.Size = new System.Drawing.Size(186, 35);
            this.btnCreateNote.TabIndex = 1;
            this.btnCreateNote.Text = "Tạo Thông Báo";
            this.btnCreateNote.UseVisualStyleBackColor = true;
            this.btnCreateNote.Click += new System.EventHandler(this.btnCreateNote_Click);
            // 
            // FNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 600);
            this.Controls.Add(this.btnCreateNote);
            this.Controls.Add(this.fpnlShowNote);
            this.Name = "FNotification";
            this.Text = "FNotification";
            this.Load += new System.EventHandler(this.FNotification_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpnlShowNote;
        private System.Windows.Forms.Button btnCreateNote;
    }
}