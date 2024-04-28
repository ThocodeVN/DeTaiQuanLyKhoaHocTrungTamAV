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
    public partial class GroupIsTeaching : Form
    {
        private NhomHocDAO nhomHocDAO; // Khai báo thể hiện của lớp NhomHocDAO
        private string connectionString = "Data Source=DESKTOP-91FFOHP;Initial Catalog=HQT;Integrated Security=True"; // Thay thế bằng chuỗi kết nối của bạn
        public GroupIsTeaching()
        {
            InitializeComponent();
            nhomHocDAO = new NhomHocDAO(connectionString);
        }

        private void GroupIsTeaching_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhom();
        }
        private void HienThiDanhSachNhom()
        {
            // Lấy danh sách nhóm từ lớp NhomHocDAO
            List<NhomHocDTO> danhSachNhom = nhomHocDAO.LayDanhSachNhom();

            // Gán danh sách nhóm vào DataSource của DataGridView
            DataGridViewGroupIsTeaching.DataSource = danhSachNhom;
        }

    }
}
