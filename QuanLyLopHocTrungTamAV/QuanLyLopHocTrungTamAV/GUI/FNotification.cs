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
    public partial class FNotification : Form
    {
        RegisterDTO RegisterDTO;
        LoginDAO LoginDAO;
        string person;
        public FNotification(RegisterDTO re ,LoginDAO login ,string person)
        {
            InitializeComponent();
            this.person = person;
            this.RegisterDTO = re;
            this.LoginDAO = login;
        }

        private void FNotification_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            fpnlShowNote.Controls.Clear();
            if (person == "GiaoVien")
            {
                btnCreateNote.Show();
                dt = LoginDAO.ViewNoteByTeacher(RegisterDTO);
            }
            else
            {
                btnCreateNote.Hide();
            }

            foreach (DataRow dr in dt.Select("", "MaThongBao DESC"))
            {
                UCNotification uc = new UCNotification(dr, LoginDAO);
                fpnlShowNote.Controls.Add(uc);
            }
        }

        private void btnCreateNote_Click(object sender, EventArgs e)
        {
            FCreateNote f = new FCreateNote(LoginDAO, RegisterDTO);
            this.Hide();
            this.Show();
            DialogResult res = f.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                FNotification_Load(sender, e);  
            }
        }
    }
}
