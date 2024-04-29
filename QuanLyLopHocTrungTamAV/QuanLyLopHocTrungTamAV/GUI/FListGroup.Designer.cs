namespace QuanLyLopHocTrungTamAV.GUI
{
    partial class FListGroup
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
            this.dgvListGroup = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListGroup
            // 
            this.dgvListGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListGroup.Location = new System.Drawing.Point(12, 12);
            this.dgvListGroup.Name = "dgvListGroup";
            this.dgvListGroup.RowHeadersWidth = 51;
            this.dgvListGroup.RowTemplate.Height = 24;
            this.dgvListGroup.Size = new System.Drawing.Size(656, 568);
            this.dgvListGroup.TabIndex = 0;
            // 
            // FListGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 592);
            this.Controls.Add(this.dgvListGroup);
            this.Name = "FListGroup";
            this.Text = "FListGroup";
            this.Load += new System.EventHandler(this.FListGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListGroup;
    }
}