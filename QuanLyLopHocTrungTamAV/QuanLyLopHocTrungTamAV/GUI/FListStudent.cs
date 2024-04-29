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
        }
    }
}
