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
    public partial class FCreateNote : Form
    {
        LoginDAO LoginDAO;
        RegisterDTO Teacher;
        public FCreateNote(LoginDAO login, RegisterDTO re)
        {
            InitializeComponent();
            LoginDAO = login;
            Teacher = re;
        }

        private void FCreateNote_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = LoginDAO.ListClassTeaching(Teacher);
            if (dgvList.DataSource != null )
            {
                txtGroupID.DataBindings.Add("Text", dgvList.DataSource, "MaNhomHoc");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            LoginDAO.CreateNote(Teacher, txtTitle.Text, rtxtContent.Text);
            LoginDAO.SendMessage(txtGroupID.Text);
        }
    }
}
