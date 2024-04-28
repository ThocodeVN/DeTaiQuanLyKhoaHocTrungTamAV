using QuanLyLopHocTrungTamAV.GUI.Admin;
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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void btnshowgroupisteaching_Click(object sender, EventArgs e)
        {
            this.panelTeacher.Controls.Clear();
            GroupIsTeaching dsad = new GroupIsTeaching();
            dsad.TopLevel = false;
            this.panelTeacher.Controls.Add(dsad);
            dsad.Show();
        }
    }
}
