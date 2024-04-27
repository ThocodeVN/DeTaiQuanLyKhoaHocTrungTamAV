using Guna.UI.WinForms;
using QuanLyLopHocTrungTamAV.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLopHocTrungTamAV
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
          
        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            this.Hide();
            this.Show();
            form.ShowDialog();
        }
    }
}
