using QuanLyLopHocTrungTamAV.DTO;
using QuanLyLopHocTrungTamAV.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLopHocTrungTamAV.DAO
{
    class LoginDAO
    {
        SqlConnection conn = null;
        public string Login (LoginDTO loginDTO)
        {
            MessageBox.Show(loginDTO.Username + " " + loginDTO.Password);
            conn = new SqlConnection(@"Data Source=DESKTOP-1CII1JF\SQLEXPRESS;Initial Catalog=HQT;User Id=" + loginDTO.Username + ";Password=" + loginDTO.Password + ";");
            DataTable dt = new DataTable();
            string role = "";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TAIKHOAN WHERE TenDangNhap = '" + loginDTO.Username + "' and " + " QuyenNguoiDung = '" + loginDTO.Role +"'" , conn);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    role = dr["QuyenNguoiDung"].ToString();
                }    
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message);
                role = "Đăng nhập thất bại";
            }

            return role;
        }

        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void SignUp(RegisterDTO re, string role)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-1CII1JF\SQLEXPRESS;Initial Catalog=HQT;Integrated Security=True");
            try
            {
                conn.Open();
                string sqlStr = "";
                if (role == "Quyen1")
                {
                    sqlStr = string.Format("INSERT INTO GIAOVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", re.Name, DateTime.Now, re.Sex, re.Address, re.Phone, re.Email);
                }
                else
                {
                    sqlStr = string.Format("INSERT INTO HOCVIEN (TenHocVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", re.Name, DateTime.Now, re.Sex, re.Address, re.Phone, re.Email);
                }    
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
