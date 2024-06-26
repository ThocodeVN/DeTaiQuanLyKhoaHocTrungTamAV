﻿using QuanLyLopHocTrungTamAV.DAO;
using QuanLyLopHocTrungTamAV.DTO;
using QuanLyLopHocTrungTamAV.GUI.Admin;
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
        LoginDAO loginDAO;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string role = "";
           
            if (rbtnAdmin.Checked)
            {
                role = "Quyen3";
            }
            else
            if (rbtnStudent.Checked)
            {
                role = "Quyen2";
            }    
            else
            if (rbtnTeacher.Checked)
            {
                role = "Quyen1";
            }    
            else
            {
                MessageBox.Show("Hãy chọn đối tượng đăng nhập");
                return;
            }

            login = new LoginDTO(txt_Username.Text.Trim(), txt_Password.Text.Trim(), role);
            loginDAO = new LoginDAO(login);
            string result = loginDAO.Login();
            if (result == "Đăng nhập thất bại")
                return;
            
            if(role == "Quyen2")
            {
                RegisterDTO std = loginDAO.GetOneStudent(result);
                Student student = new Student(std, loginDAO);
                this.Hide();
                this.Show();
                DialogResult rs = student.ShowDialog();
                if (rs == DialogResult.Cancel)
                {
                    loginDAO.CloseConnection();
                }
            }

            if (role == "Quyen1")
            {
                RegisterDTO tch = loginDAO.GetOneTeacher(result);
                Teacher teacher = new Teacher(tch, loginDAO);
                this.Hide();
                this.Show();
                DialogResult rs = teacher.ShowDialog();
                if (rs == DialogResult.Cancel)
                {
                    loginDAO.CloseConnection();
                }
            }

            if (role == "Quyen3")
            {
                Manager man = new Manager(loginDAO);
                this.Hide();
                this.Show();
                DialogResult rs = man.ShowDialog();
                if (rs == DialogResult.Cancel)
                {
                    loginDAO.CloseConnection();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
