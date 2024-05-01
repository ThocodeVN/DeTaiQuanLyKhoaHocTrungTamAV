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
    public partial class FCreateCourse : Form
    {
        LoginDAO loginDAO;
        public FCreateCourse(LoginDAO login)
        {
            InitializeComponent();
            loginDAO = login;
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            loginDAO.AddCourse(txtNameCourse.Text);
        }
    }
}
