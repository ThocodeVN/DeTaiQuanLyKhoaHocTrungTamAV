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
        }
    }
}
