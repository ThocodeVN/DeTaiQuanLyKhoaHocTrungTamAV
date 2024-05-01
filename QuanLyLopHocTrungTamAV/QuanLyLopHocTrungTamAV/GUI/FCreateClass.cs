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
    public partial class FCreateClass : Form
    {
        LoginDAO login;
        int MaKH;
        public FCreateClass(LoginDAO login, int MaKH)
        {
            InitializeComponent();
            this.login = login;
            this.MaKH = MaKH;
        }

        private void FCreateClass_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = login.GetListClassFollowCourse(MaKH);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            login.AddClass(MaKH, txtNameClass.Text,Convert.ToInt32(txtTotal.Text), Convert.ToInt32(txtFee.Text));
            FCreateClass_Load(sender, e);
        }
    }
}
