namespace QuanLyLopHocTrungTamAV.GUI
{
    partial class FListClass
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
            this.dgvListClass = new System.Windows.Forms.DataGridView();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.btnListStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListClass)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListClass
            // 
            this.dgvListClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListClass.Location = new System.Drawing.Point(311, 12);
            this.dgvListClass.Name = "dgvListClass";
            this.dgvListClass.RowHeadersWidth = 51;
            this.dgvListClass.RowTemplate.Height = 24;
            this.dgvListClass.Size = new System.Drawing.Size(571, 535);
            this.dgvListClass.TabIndex = 0;
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(25, 56);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(227, 22);
            this.txtGroupID.TabIndex = 1;
            // 
            // btnListStudent
            // 
            this.btnListStudent.Location = new System.Drawing.Point(87, 170);
            this.btnListStudent.Name = "btnListStudent";
            this.btnListStudent.Size = new System.Drawing.Size(104, 56);
            this.btnListStudent.TabIndex = 2;
            this.btnListStudent.Text = "Xem Danh Sách Học Viên";
            this.btnListStudent.UseVisualStyleBackColor = true;
            this.btnListStudent.Click += new System.EventHandler(this.btnListStudent_Click);
            // 
            // FListClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 559);
            this.Controls.Add(this.btnListStudent);
            this.Controls.Add(this.txtGroupID);
            this.Controls.Add(this.dgvListClass);
            this.Name = "FListClass";
            this.Text = "FListClass";
            this.Load += new System.EventHandler(this.FListClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListClass;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.Button btnListStudent;
    }
}