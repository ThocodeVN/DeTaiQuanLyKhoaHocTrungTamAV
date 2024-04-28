namespace TestConnetionSQL
{
    partial class Form1
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
            this.btnOpenConnect = new System.Windows.Forms.Button();
            this.btnCloseConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenConnect
            // 
            this.btnOpenConnect.Location = new System.Drawing.Point(113, 157);
            this.btnOpenConnect.Name = "btnOpenConnect";
            this.btnOpenConnect.Size = new System.Drawing.Size(117, 64);
            this.btnOpenConnect.TabIndex = 0;
            this.btnOpenConnect.Text = "Mở Kết Nối";
            this.btnOpenConnect.UseVisualStyleBackColor = true;
            this.btnOpenConnect.Click += new System.EventHandler(this.btnOpenConnect_Click);
            // 
            // btnCloseConnect
            // 
            this.btnCloseConnect.Location = new System.Drawing.Point(491, 157);
            this.btnCloseConnect.Name = "btnCloseConnect";
            this.btnCloseConnect.Size = new System.Drawing.Size(117, 64);
            this.btnCloseConnect.TabIndex = 1;
            this.btnCloseConnect.Text = "Đóng kết nối";
            this.btnCloseConnect.UseVisualStyleBackColor = true;
            this.btnCloseConnect.Click += new System.EventHandler(this.btnCloseConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 377);
            this.Controls.Add(this.btnCloseConnect);
            this.Controls.Add(this.btnOpenConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenConnect;
        private System.Windows.Forms.Button btnCloseConnect;
    }
}

