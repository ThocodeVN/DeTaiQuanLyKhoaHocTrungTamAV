using QuanLyLopHocTrungTamAV.DAO;
using QuanLyLopHocTrungTamAV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyLopHocTrungTamAV.GUI
{
    public partial class Login : Form
    {
        LoginDTO login;
        LoginDAO loginDAO = new LoginDAO();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login = new LoginDTO(txt_Username.Text.Trim(), txt_Password.Text.Trim());
            string result = loginDAO.Login(login);
            Student st = new Student();
            if(result == "Quyen1")
            {
                this.Hide();
                this.Show();
                DialogResult rs = st.ShowDialog();
                if(rs == DialogResult.Cancel)
                {
                    loginDAO.CloseConnection();
                }    
            }    

            if(result == "Đăng nhập thất bại")
            {
                MessageBox.Show(result);
            }    
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }
    }
}
