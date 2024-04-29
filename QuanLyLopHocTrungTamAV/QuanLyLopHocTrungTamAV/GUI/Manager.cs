﻿using QuanLyLopHocTrungTamAV.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLopHocTrungTamAV.GUI.Admin
{
    public partial class Manager : Form
    {
        LoginDAO loginDAO;
        public Manager(LoginDAO login)
        {
            InitializeComponent();
            loginDAO = login;
        }

        private void btnListGroup_Click(object sender, EventArgs e)
        {
            FListGroup f = new FListGroup(loginDAO);
            this.Hide();
            this.Show();
            f.ShowDialog();
        }
    }
}
