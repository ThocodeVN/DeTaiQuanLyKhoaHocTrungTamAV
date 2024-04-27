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
            gunaVScrollBar1.Value = flowLayoutPanel1.VerticalScroll.Value;
            gunaVScrollBar1.Minimum = flowLayoutPanel1.VerticalScroll.Minimum;
            gunaVScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;
            flowLayoutPanel1.ControlAdded += FlowLayoutPanel1_ControlAdded;
            flowLayoutPanel1.ControlRemoved += FlowLayoutPanel1_ControlRemoved;  
        }

        private void FlowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            gunaVScrollBar1.Minimum = flowLayoutPanel1.VerticalScroll.Minimum;
        }

        private void FlowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            gunaVScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;
        }

        private void FirstForm_Load(object sender, EventArgs e)
        {
         
        }

        private void gunaVScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = gunaVScrollBar1.Value;
        }



        private void gunaTileButton1_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            this.Hide();
            form.Show();
        }
    }
}
