using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocTrungTamAV.DTO
{
    public class LopHocDTO
    {
        public int MaLopHoc { get; set; }
        public int MaKhoaHoc { get; set; }
        public string TenLopHoc { get; set; }
        public int TongSoBuoiHoc { get; set; }
        public double HocPhi { get; set; }
        public string TenGiaoVien { get; set; }
    }
}
