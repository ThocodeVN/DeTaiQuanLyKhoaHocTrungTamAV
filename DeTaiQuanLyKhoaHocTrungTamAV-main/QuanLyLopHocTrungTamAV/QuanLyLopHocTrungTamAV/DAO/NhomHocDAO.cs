using QuanLyLopHocTrungTamAV.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocTrungTamAV.DAO
{
    public class NhomHocDAO
    {
        private string connectionString;

        public NhomHocDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<NhomHocDTO> LayDanhSachNhom()
        {
            List<NhomHocDTO> danhSachNhom = new List<NhomHocDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "SELECT * FROM uf_LayDanhSachNhom()";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhomHocDTO nhom = new NhomHocDTO();
                            nhom.MaNhomHoc = (int)reader["MaNhomHoc"];
                            nhom.MaLopHoc = (int)reader["MaLopHoc"];
                            nhom.MaGiaoVien = (int)reader["MaGiaoVien"];
                            // Gán các thuộc tính khác của nhóm
                            danhSachNhom.Add(nhom);
                        }
                    }
                }
            }

            return danhSachNhom;
        }
    }
}
