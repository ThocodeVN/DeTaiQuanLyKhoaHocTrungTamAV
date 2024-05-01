using QuanLyLopHocTrungTamAV.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLopHocTrungTamAV.DTO;


namespace QuanLyLopHocTrungTamAV.GUI
{
    public partial class Student : Form
    {
        RegisterDTO student;
        LoginDAO loginDAO;

        public Student(RegisterDTO student, LoginDAO login)
        {
            InitializeComponent();
            this.student = student;
            this.loginDAO = login;
        }

        private void Student_Load(object sender, EventArgs e)
        {
            txtName.Text = student.Name;
            txtSex.Text = student.Sex;
            txtPhone.Text = student.Phone;
            txtEmail.Text = student.Email;
            txtAddress.Text = student.Address;
            dtpBirth.Value = student.Date;
            lbStudentname.Text = student.Name;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                student.Name = txtName.Text.ToString().Trim();
                student.Sex = txtSex.Text.ToString().Trim();
                student.Address = txtAddress.Text.ToString().Trim();
                student.Date = dtpBirth.Value;
                student.Phone = txtPhone.Text.ToString().Trim();
                loginDAO.UpdateInforStudent(student);
                MessageBox.Show("Sửa thông tin cá nhân thành công, chúc mừng bạn");
                Student_Load(sender, e);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

    }
}

