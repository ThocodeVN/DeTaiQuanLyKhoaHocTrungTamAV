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

namespace QuanLyLopHocTrungTamAV.GUI
{
    public partial class FListStudent : Form
    {
        LoginDAO login;
        int MaNhomHoc;
        public FListStudent(LoginDAO login, int ma)
        {
            InitializeComponent();
            this.login = login;
            MaNhomHoc = ma;
        }

        private void FListStudent_Load(object sender, EventArgs e)
        {
            dgvStudent.DataSource = login.LoadStudentOfGroup(MaNhomHoc);
            if(dgvStudent.DataSource != null)
            {
                txtName.DataBindings.Add("Text", dgvStudent.DataSource, "TenHocVien");
                txtGroupID.DataBindings.Add("Text", dgvStudent.DataSource, "MaNhomHoc");
                txtStudentID.DataBindings.Add("Text", dgvStudent.DataSource, "MaHocVien");
            }    
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int check;
            if (cbxCheck.Text == "Có mặt")
            {
                check = 1;
            }    
            else
            {
                check = 0;
            }
            login.CheckDate(dtpCheck.Value);
            login.CheckStudent(Convert.ToInt32(txtGroupID.Text) ,Convert.ToInt32(txtStudentID.Text), check, dtpCheck.Value);
        }

        private void btnListCheck_Click(object sender, EventArgs e)
        {
            txtGroupID.DataBindings.Clear();
            txtStudentID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            dgvStudent.DataSource = login.GetListCheck();
        }

        private void btnListStudent_Click(object sender, EventArgs e)
        {
            FListStudent_Load(sender, e);
        }
    }
}
