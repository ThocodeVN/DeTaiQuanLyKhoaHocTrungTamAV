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
    public partial class FScore : Form
    {
        LoginDAO login;
        int MaNhomHoc;
        public FScore(LoginDAO login, int manhomhoc)
        {
            InitializeComponent();
            this.login = login;
            this.MaNhomHoc = manhomhoc;
        }

        private void FScore_Load(object sender, EventArgs e)
        {
            dgvScore.DataSource = login.GetScoreOfGroup(MaNhomHoc);
            if(dgvScore.DataSource != null)
            {
                txtGroupID.DataBindings.Clear();
                txtScoreFinal.DataBindings.Clear();
                txtScoreMid.DataBindings.Clear();
                txtStudentID.DataBindings.Clear();
                txtGroupID.DataBindings.Add("Text", dgvScore.DataSource, "MaNhomHoc");
                txtStudentID.DataBindings.Add("Text", dgvScore.DataSource, "MaHocVien");
                txtScoreMid.DataBindings.Add("Text", dgvScore.DataSource, "DiemGiuaKhoa");
                txtScoreFinal.DataBindings.Add("Text", dgvScore.DataSource, "DiemCuoiKhoa");
            }    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            login.UpdateScore(Convert.ToInt32(txtGroupID.Text),Convert.ToInt32(txtStudentID.Text),Convert.ToInt32(txtScoreMid.Text),Convert.ToInt32(txtScoreFinal.Text));
            FScore_Load(sender, e );    
        }
    }
}
