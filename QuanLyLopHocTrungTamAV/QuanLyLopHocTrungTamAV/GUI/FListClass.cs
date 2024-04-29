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
    public partial class FListClass : Form
    {
        RegisterDTO teacher;
        LoginDAO loginDAO;
        public FListClass(RegisterDTO teacher, LoginDAO login)
        {
            InitializeComponent();
            this.teacher = teacher;
            this.loginDAO = login;
            //ftxtGroupID.DataBindings.Add("Text", dgvListClass.DataSource, "MaNhomHoc");
        }

        private void FListClass_Load(object sender, EventArgs e)
        {
            dgvListClass.DataSource = loginDAO.ListClassTeaching(teacher);
        }

        private void btnListStudent_Click(object sender, EventArgs e)
        {
            FListStudent f = new FListStudent(loginDAO,Convert.ToInt32(txtGroupID.Text));
            this.Hide();
            this.Show();
            f.ShowDialog();
        }
    }
}
