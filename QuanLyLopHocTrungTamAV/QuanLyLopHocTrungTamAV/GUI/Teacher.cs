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
        public Teacher(RegisterDTO teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            txtName.Text = teacher.Name;
            txtSex.Text = teacher.Sex;
            txtPhone.Text = teacher.Phone;
            txtEmail.Text = teacher.Email;
            txtAddress.Text = teacher.Address;
            txtBirth.Text = teacher.Date;
            lbTeacherName.Text = teacher.Name;
        }
    }
}
