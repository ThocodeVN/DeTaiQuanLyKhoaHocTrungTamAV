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
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.btnScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListGroup
            // 
            this.dgvListGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListGroup.Location = new System.Drawing.Point(220, 12);
            this.dgvListGroup.Name = "dgvListGroup";
            this.dgvListGroup.RowHeadersWidth = 51;
            this.dgvListGroup.RowTemplate.Height = 24;
            this.dgvListGroup.Size = new System.Drawing.Size(656, 568);
            this.dgvListGroup.TabIndex = 0;
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(29, 48);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(117, 22);
            this.txtGroupID.TabIndex = 1;
            // 
            // btnScore
            // 
            this.btnScore.Location = new System.Drawing.Point(29, 135);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(105, 83);
            this.btnScore.TabIndex = 2;
            this.btnScore.Text = "Xem Điểm";
            this.btnScore.UseVisualStyleBackColor = true;
            this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
            // 
            // FListGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 592);
            this.Controls.Add(this.btnScore);
            this.Controls.Add(this.txtGroupID);
            this.Controls.Add(this.dgvListGroup);
            this.Name = "FListGroup";
            this.Text = "FListGroup";
            this.Load += new System.EventHandler(this.FListGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListGroup;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.Button btnScore;
    }
}