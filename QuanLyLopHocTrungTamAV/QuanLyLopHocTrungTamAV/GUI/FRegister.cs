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
    public partial class FRegister : Form
    {
        RegisterDTO re;
        LoginDAO loginDAO = new LoginDAO();
        public FRegister()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string role = "";
            if(rbtnStudent.Checked )
            {
                role = "Quyen2";
            }
            else
            {
                role = "Quyen1";
            }
            re = new RegisterDTO(txtName.Text,dtpBirth.Value, txtSex.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text);
            loginDAO.SignUp(re, role);
        }
    }
}
