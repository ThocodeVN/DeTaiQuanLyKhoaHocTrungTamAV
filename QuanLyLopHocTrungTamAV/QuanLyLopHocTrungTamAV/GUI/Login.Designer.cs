namespace QuanLyLopHocTrungTamAV.GUI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.txt_Username = new Guna.UI.WinForms.GunaLineTextBox();
            this.gunaGradient2Panel2 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.txt_Password = new Guna.UI.WinForms.GunaLineTextBox();
            this.rbtnStudent = new Guna.UI.WinForms.GunaRadioButton();
            this.rbtnTeacher = new Guna.UI.WinForms.GunaRadioButton();
            this.rbtnAdmin = new Guna.UI.WinForms.GunaRadioButton();
            this.btnSignUp = new Guna.UI.WinForms.GunaGradientButton();
            this.btnLogin = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaCirclePictureBox2 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.gunaCirclePictureBox1 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaGradient2Panel1.SuspendLayout();
            this.gunaGradient2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.Location = new System.Drawing.Point(458, 9);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(330, 79);
            this.gunaLabel1.TabIndex = 4;
            this.gunaLabel1.Text = "LOGIN ACCOUNT";
            this.gunaLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.gunaCirclePictureBox1);
            this.gunaGradient2Panel1.Controls.Add(this.txt_Username);
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.White;
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.White;
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(462, 155);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(326, 41);
            this.gunaGradient2Panel1.TabIndex = 5;
            // 
            // txt_Username
            // 
            this.txt_Username.BackColor = System.Drawing.Color.White;
            this.txt_Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Username.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_Username.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Username.LineColor = System.Drawing.Color.Gainsboro;
            this.txt_Username.Location = new System.Drawing.Point(81, 3);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.PasswordChar = '\0';
            this.txt_Username.SelectedText = "";
            this.txt_Username.Size = new System.Drawing.Size(187, 30);
            this.txt_Username.TabIndex = 1;
            this.txt_Username.Text = "Tên đăng nhập";
            // 
            // gunaGradient2Panel2
            // 
            this.gunaGradient2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel2.Controls.Add(this.gunaCirclePictureBox2);
            this.gunaGradient2Panel2.Controls.Add(this.txt_Password);
            this.gunaGradient2Panel2.GradientColor1 = System.Drawing.Color.White;
            this.gunaGradient2Panel2.GradientColor2 = System.Drawing.Color.White;
            this.gunaGradient2Panel2.Location = new System.Drawing.Point(462, 217);
            this.gunaGradient2Panel2.Name = "gunaGradient2Panel2";
            this.gunaGradient2Panel2.Size = new System.Drawing.Size(326, 41);
            this.gunaGradient2Panel2.TabIndex = 6;
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.White;
            this.txt_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Password.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_Password.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.LineColor = System.Drawing.Color.Gainsboro;
            this.txt_Password.Location = new System.Drawing.Point(81, 3);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '\0';
            this.txt_Password.SelectedText = "";
            this.txt_Password.Size = new System.Drawing.Size(187, 30);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.Text = "Mật khẩu";
            // 
            // rbtnStudent
            // 
            this.rbtnStudent.BaseColor = System.Drawing.SystemColors.Control;
            this.rbtnStudent.CheckedOffColor = System.Drawing.Color.Gray;
            this.rbtnStudent.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.rbtnStudent.FillColor = System.Drawing.Color.White;
            this.rbtnStudent.Location = new System.Drawing.Point(484, 82);
            this.rbtnStudent.Name = "rbtnStudent";
            this.rbtnStudent.Size = new System.Drawing.Size(85, 20);
            this.rbtnStudent.TabIndex = 8;
            this.rbtnStudent.Text = "Học Viên";
            // 
            // rbtnTeacher
            // 
            this.rbtnTeacher.BaseColor = System.Drawing.SystemColors.Control;
            this.rbtnTeacher.CheckedOffColor = System.Drawing.Color.Gray;
            this.rbtnTeacher.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.rbtnTeacher.FillColor = System.Drawing.Color.White;
            this.rbtnTeacher.Location = new System.Drawing.Point(647, 82);
            this.rbtnTeacher.Name = "rbtnTeacher";
            this.rbtnTeacher.Size = new System.Drawing.Size(89, 20);
            this.rbtnTeacher.TabIndex = 9;
            this.rbtnTeacher.Text = "Giáo Viên";
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.BaseColor = System.Drawing.SystemColors.Control;
            this.rbtnAdmin.CheckedOffColor = System.Drawing.Color.Gray;
            this.rbtnAdmin.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.rbtnAdmin.FillColor = System.Drawing.Color.White;
            this.rbtnAdmin.Location = new System.Drawing.Point(553, 117);
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Size = new System.Drawing.Size(113, 20);
            this.rbtnAdmin.TabIndex = 10;
            this.rbtnAdmin.Text = "Quản Trị Viên";
            // 
            // btnSignUp
            // 
            this.btnSignUp.AnimationHoverSpeed = 0.07F;
            this.btnSignUp.AnimationSpeed = 0.03F;
            this.btnSignUp.BaseColor1 = System.Drawing.Color.LightCyan;
            this.btnSignUp.BaseColor2 = System.Drawing.Color.MediumSeaGreen;
            this.btnSignUp.BorderColor = System.Drawing.Color.Black;
            this.btnSignUp.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSignUp.FocusedColor = System.Drawing.Color.Empty;
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Image = ((System.Drawing.Image)(resources.GetObject("btnSignUp.Image")));
            this.btnSignUp.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSignUp.Location = new System.Drawing.Point(543, 372);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.btnSignUp.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnSignUp.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSignUp.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSignUp.OnHoverImage = null;
            this.btnSignUp.OnPressedColor = System.Drawing.Color.Black;
            this.btnSignUp.Size = new System.Drawing.Size(160, 42);
            this.btnSignUp.TabIndex = 11;
            this.btnSignUp.Text = "Sign Up";
            // 
            // btnLogin
            // 
            this.btnLogin.AnimationHoverSpeed = 0.07F;
            this.btnLogin.AnimationSpeed = 0.03F;
            this.btnLogin.BaseColor1 = System.Drawing.Color.LightCyan;
            this.btnLogin.BaseColor2 = System.Drawing.Color.Crimson;
            this.btnLogin.BorderColor = System.Drawing.Color.Black;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.FocusedColor = System.Drawing.Color.Empty;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLogin.Location = new System.Drawing.Point(543, 313);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.btnLogin.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnLogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogin.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogin.OnHoverImage = null;
            this.btnLogin.OnPressedColor = System.Drawing.Color.Black;
            this.btnLogin.Size = new System.Drawing.Size(160, 42);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gunaCirclePictureBox2
            // 
            this.gunaCirclePictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaCirclePictureBox2.Image = global::QuanLyLopHocTrungTamAV.Properties.Resources.padlock;
            this.gunaCirclePictureBox2.Location = new System.Drawing.Point(22, 3);
            this.gunaCirclePictureBox2.Name = "gunaCirclePictureBox2";
            this.gunaCirclePictureBox2.Size = new System.Drawing.Size(36, 35);
            this.gunaCirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaCirclePictureBox2.TabIndex = 2;
            this.gunaCirclePictureBox2.TabStop = false;
            this.gunaCirclePictureBox2.UseTransfarantBackground = false;
            // 
            // gunaCirclePictureBox1
            // 
            this.gunaCirclePictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaCirclePictureBox1.Image = global::QuanLyLopHocTrungTamAV.Properties.Resources.idea;
            this.gunaCirclePictureBox1.Location = new System.Drawing.Point(22, 3);
            this.gunaCirclePictureBox1.Name = "gunaCirclePictureBox1";
            this.gunaCirclePictureBox1.Size = new System.Drawing.Size(36, 35);
            this.gunaCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaCirclePictureBox1.TabIndex = 2;
            this.gunaCirclePictureBox1.TabStop = false;
            this.gunaCirclePictureBox1.UseTransfarantBackground = false;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = global::QuanLyLopHocTrungTamAV.Properties.Resources.Logo;
            this.gunaPictureBox1.Location = new System.Drawing.Point(0, -1);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(428, 451);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 2;
            this.gunaPictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.rbtnAdmin);
            this.Controls.Add(this.rbtnTeacher);
            this.Controls.Add(this.rbtnStudent);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.gunaGradient2Panel2);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.gunaPictureBox1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.gunaGradient2Panel1.ResumeLayout(false);
            this.gunaGradient2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel2;
        private Guna.UI.WinForms.GunaLineTextBox txt_Username;
        private Guna.UI.WinForms.GunaLineTextBox txt_Password;
        private Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox1;
        private Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox2;
        private Guna.UI.WinForms.GunaGradientButton btnLogin;
        private Guna.UI.WinForms.GunaRadioButton rbtnStudent;
        private Guna.UI.WinForms.GunaRadioButton rbtnTeacher;
        private Guna.UI.WinForms.GunaRadioButton rbtnAdmin;
        private Guna.UI.WinForms.GunaGradientButton btnSignUp;
    }
}