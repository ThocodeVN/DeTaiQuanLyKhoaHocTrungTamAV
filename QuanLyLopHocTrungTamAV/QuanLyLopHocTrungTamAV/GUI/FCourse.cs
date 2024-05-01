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
    public partial class FCourse : Form
    {
        LoginDAO loginDAO;
        int Type;
        public FCourse(LoginDAO login, int Type)
        {
            InitializeComponent();
            loginDAO = login;
            this.Type = Type;
            btnAddClass.Hide();
            btnAddCourse.Hide();
            btnAddGroup.Hide();
            
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            FCreateCourse f = new FCreateCourse(loginDAO);
            this.Hide();
            this.Show();
            f.ShowDialog();
            FCourse_Load(sender, e);
            
        }

        private void FCourse_Load(object sender, EventArgs e)
        {
            txtID.DataBindings.Clear();
            if(Type == 1)
            {
                btnAddCourse.Show();
                btnAddClass.Show();
                dgvList.DataSource = loginDAO.GetListCourse();
                if (dgvList.DataSource != null)
                {
                    txtID.DataBindings.Add("Text", dgvList.DataSource, "MaKhoaHoc");
                }
            }

            if(Type == 2)
            {
                btnAddGroup.Show();
                dgvList.DataSource = loginDAO.GetListClass();
                if (dgvList.DataSource != null)
                {
                    txtID.DataBindings.Add("Text", dgvList.DataSource, "MaLopHoc");
                }
            }

            if(Type == 3)
            {
                dgvList.DataSource = loginDAO.ListClass();
                if(dgvList.DataSource != null)
                {
                    txtID.DataBindings.Add("Text", dgvList.DataSource, "MaNhomHoc");
                }
            }
           
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            FCreateClass f = new FCreateClass(loginDAO,Convert.ToInt32(txtID.Text));
            this.Hide();
            this.Show();
            f.ShowDialog(); 
        }
    }
}
