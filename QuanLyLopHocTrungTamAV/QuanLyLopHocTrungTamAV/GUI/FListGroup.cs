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
        }
    }
}
