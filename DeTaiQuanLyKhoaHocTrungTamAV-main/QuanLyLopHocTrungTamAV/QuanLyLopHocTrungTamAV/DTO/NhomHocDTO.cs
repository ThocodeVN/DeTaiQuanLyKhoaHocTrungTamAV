using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocTrungTamAV.DTO
{
    public class NhomHocDTO
    {
        public int MaNhomHoc { get; set; }
        public int MaLopHoc { get; set; }
        public int MaGiaoVien { get; set; }
        public int Ca { get; set; }
        public int SoLuongHocVienToiThieu { get; set; }
        public int SoLuongHocVienToiDa { get; set; }
        public int SoHocVienHienTai { get; set; }
        public DateTime NgayBatDau { get; set; }
        public int TongBuoiHoc { get; set; }
        public bool TrangThaiMoDangKy { get; set; }
    }
}
