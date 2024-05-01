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
    public partial class FListGroup : Form
    {
        LoginDAO loginDAO;
        public FListGroup(LoginDAO login)
        {
            InitializeComponent();
            this.loginDAO = login;  
        }

        private void FListGroup_Load(object sender, EventArgs e)
        {
             dgvListGroup.DataSource = loginDAO.ListClass();
            if(dgvListGroup.DataSource != null )
            {
                txtGroupID.DataBindings.Add("Text", dgvListGroup.DataSource, "MaNhomHoc");
            }
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            FScore score = new FScore(loginDAO, Convert.ToInt32(txtGroupID.Text));
            this.Hide();
            this.Show();
            score.ShowDialog();
        }
    }
}
