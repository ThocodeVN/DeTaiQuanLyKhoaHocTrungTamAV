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
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.btnListStudent = new System.Windows.Forms.Button();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.dgvlist = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).BeginInit();
            this.SuspendLayout();
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
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.Location = new System.Drawing.Point(84, 22);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(112, 18);
            this.gunaLabel1.TabIndex = 3;
            this.gunaLabel1.Text = "Mã nhóm học";
            // 
            // dgvlist
            // 
            this.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlist.Location = new System.Drawing.Point(309, 12);
            this.dgvlist.Name = "dgvlist";
            this.dgvlist.RowHeadersWidth = 51;
            this.dgvlist.RowTemplate.Height = 24;
            this.dgvlist.Size = new System.Drawing.Size(573, 535);
            this.dgvlist.TabIndex = 4;
            // 
            // FListClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(894, 559);
            this.Controls.Add(this.dgvlist);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.btnListStudent);
            this.Controls.Add(this.txtGroupID);
            this.Name = "FListClass";
            this.Text = "FListClass";
            this.Load += new System.EventHandler(this.FListClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.Button btnListStudent;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private System.Windows.Forms.DataGridView dgvlist;
    }
}