namespace QuanLyLopHocTrungTamAV.GUI
{
    partial class FListStudent
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
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnListCheck = new System.Windows.Forms.Button();
            this.btnListStudent = new System.Windows.Forms.Button();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.cbxCheck = new System.Windows.Forms.ComboBox();
            this.dtpCheck = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudent
            // 
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Location = new System.Drawing.Point(234, 12);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 51;
            this.dgvStudent.RowTemplate.Height = 24;
            this.dgvStudent.Size = new System.Drawing.Size(628, 513);
            this.dgvStudent.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(41, 291);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(140, 74);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Điểm Danh";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(41, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 22);
            this.txtName.TabIndex = 2;
            // 
            // btnListCheck
            // 
            this.btnListCheck.Location = new System.Drawing.Point(41, 371);
            this.btnListCheck.Name = "btnListCheck";
            this.btnListCheck.Size = new System.Drawing.Size(140, 74);
            this.btnListCheck.TabIndex = 3;
            this.btnListCheck.Text = "Xem Bảng Điểm Danh";
            this.btnListCheck.UseVisualStyleBackColor = true;
            this.btnListCheck.Click += new System.EventHandler(this.btnListCheck_Click);
            // 
            // btnListStudent
            // 
            this.btnListStudent.Location = new System.Drawing.Point(41, 451);
            this.btnListStudent.Name = "btnListStudent";
            this.btnListStudent.Size = new System.Drawing.Size(140, 74);
            this.btnListStudent.TabIndex = 4;
            this.btnListStudent.Text = "Xem Danh Sách Học Viên";
            this.btnListStudent.UseVisualStyleBackColor = true;
            this.btnListStudent.Click += new System.EventHandler(this.btnListStudent_Click);
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(41, 127);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(140, 22);
            this.txtStudentID.TabIndex = 5;
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(41, 83);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(140, 22);
            this.txtGroupID.TabIndex = 7;
            // 
            // cbxCheck
            // 
            this.cbxCheck.FormattingEnabled = true;
            this.cbxCheck.Items.AddRange(new object[] {
            "Có mặt",
            "Vắng"});
            this.cbxCheck.Location = new System.Drawing.Point(41, 225);
            this.cbxCheck.Name = "cbxCheck";
            this.cbxCheck.Size = new System.Drawing.Size(140, 24);
            this.cbxCheck.TabIndex = 8;
            // 
            // dtpCheck
            // 
            this.dtpCheck.Location = new System.Drawing.Point(12, 173);
            this.dtpCheck.Name = "dtpCheck";
            this.dtpCheck.Size = new System.Drawing.Size(200, 22);
            this.dtpCheck.TabIndex = 9;
            // 
            // FListStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 537);
            this.Controls.Add(this.dtpCheck);
            this.Controls.Add(this.cbxCheck);
            this.Controls.Add(this.txtGroupID);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.btnListStudent);
            this.Controls.Add(this.btnListCheck);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dgvStudent);
            this.Name = "FListStudent";
            this.Text = "FListStudent";
            this.Load += new System.EventHandler(this.FListStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnListCheck;
        private System.Windows.Forms.Button btnListStudent;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.ComboBox cbxCheck;
        private System.Windows.Forms.DateTimePicker dtpCheck;
    }
}