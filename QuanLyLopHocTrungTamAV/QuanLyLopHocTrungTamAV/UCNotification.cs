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

namespace QuanLyLopHocTrungTamAV
{
    public partial class UCNotification : UserControl
    {
        public UCNotification(DataRow note, LoginDAO login)
        {
            InitializeComponent();
            lbContent.Text = note["NoiDung"].ToString();
            lbDate.Text = note["NgayGui"].ToString();
            lbTitle.Text = note["TieuDe"].ToString();
            lbGroup.Text = "Nhóm: " + (login.GetSendHistory(Convert.ToInt32(note["MaThongBao"]))).Rows[0]["MaNhomHoc"].ToString();
        }
    }
}
