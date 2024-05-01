using QuanLyLopHocTrungTamAV.DAO;
using QuanLyLopHocTrungTamAV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLopHocTrungTamAV.GUI
{
    public partial class Teacher : Form
    {
        RegisterDTO teacher;
        LoginDAO loginDAO;
        public Teacher(RegisterDTO teacher, LoginDAO login)
        {
            InitializeComponent();
            this.teacher = teacher;
            this.loginDAO = login;
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            txtName.Text = teacher.Name;
            txtSex.Text = teacher.Sex;
            txtPhone.Text = teacher.Phone;
            txtEmail.Text = teacher.Email;
            txtAddress.Text = teacher.Address;
            dtpBirth.Value = teacher.Date;
            lbTeacherName.Text = teacher.Name;
        }

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {

        }

        private void btnListClass_Click(object sender, EventArgs e)
        {
            FListClass f = new FListClass(teacher, loginDAO);
            this.Hide();
            this.Show();
            f.ShowDialog();
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            FNotification f = new FNotification(teacher, loginDAO, "GiaoVien");
            this.Hide();
            this.Show();
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            teacher.Name = txtName.Text;
            teacher.Sex = txtSex.Text;
            teacher.Phone = txtPhone.Text;
            teacher.Email = txtEmail.Text;
            teacher.Address = txtAddress.Text;
            teacher.Date = dtpBirth.Value;
            loginDAO.UpdateInforTeacher(teacher);
            MessageBox.Show("Sửa thông tin thành công, chúc mừng bạn");
            Teacher_Load(sender, e);
        }
    }
}
