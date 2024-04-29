using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Mask.Design;
using QuanLyLopHocTrungTamAV.DTO;
using QuanLyLopHocTrungTamAV.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLopHocTrungTamAV.DAO
{
    public class LoginDAO
    {
        SqlConnection conn = null;
        LoginDTO loginDTO;

        public LoginDAO()
        {

        }

        public LoginDAO(LoginDTO login)
        {
            loginDTO = login;
            conn = new SqlConnection(@"Data Source=DESKTOP-1CII1JF\SQLEXPRESS;Initial Catalog=HQTpr;User Id=" + loginDTO.Username + ";Password=" + loginDTO.Password + ";");
        }

        public string Login ()
        {
            MessageBox.Show(loginDTO.Username + " " + loginDTO.Password);
            DataTable dt = new DataTable();
            string matk = "";
            try
            {
                conn.Open();
                string sqlStr = "SELECT * FROM TAIKHOAN WHERE TenDangNhap = '" + loginDTO.Username + "' and QuyenNguoiDung = '" + loginDTO.Role + "'";
                MessageBox.Show(sqlStr);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    matk = dr["MaTaiKhoan"].ToString();
                }    
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message);
                matk = "Đăng nhập thất bại";
            }
            MessageBox.Show(matk);
            return matk;
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
            conn = new SqlConnection(@"Data Source=DESKTOP-1CII1JF\SQLEXPRESS;Initial Catalog=HQTpr;Integrated Security=True");
            try
            {
                conn.Open();
                string sqlStr = "";
                if (role == "Quyen1")
                {
                    sqlStr = string.Format("INSERT INTO GIAOVIEN (HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", re.Name, re.Date, re.Sex, re.Address, re.Phone, re.Email);
                }
                
                if (role == "Quyen2")
                {
                    sqlStr = string.Format("INSERT INTO HOCVIEN (TenHocVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", re.Name, re.Date, re.Sex, re.Address, re.Phone, re.Email);
                }    
                SqlCommand sqlCommand = new SqlCommand(sqlStr, conn);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public RegisterDTO GetOneTeacher(string maTk)
        {
            string sql = string.Format("SELECT * FROM GIAOVIEN WHERE MaTK = '{0}'", maTk);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            RegisterDTO teacher = null;
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                MessageBox.Show(dr["DiaChi"].ToString());
                teacher = new RegisterDTO(dr["HoTen"].ToString(),Convert.ToDateTime(dr["NgaySinh"]), dr["GioiTinh"].ToString(), dr["DiaChi"].ToString(), dr["SoDienThoai"].ToString(), dr["Email"].ToString());
            }
            return teacher;
        }

        public DataTable ListClassTeaching(RegisterDTO teacher)
        {
            string sqlStr = string.Format("SELECT * FROM dbo.uf_LayDanhSachNhom_DangDay(@MaGiaoVien)");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaGiaoVien", teacher.Id);
            object result = cmd.ExecuteScalar();
            DataTable listClass = new DataTable();
            listClass = result as DataTable;
            return listClass;
        }

        public DataTable ListClass()
        {
            string sqlStr = string.Format("SELECT * FROM dbo.uf_LayDanhSachNhom()");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            object result = cmd.ExecuteScalar();
            DataTable listClass = new DataTable();
            listClass = result as DataTable;
            return listClass;
        }

        public DataTable LoadStudentOfGroup(int MaNhomHoc)
        {
            string sqlStr = string.Format("SELECT * FROM dbo.func_layDSHocVienNhomHoc(@MaNhomHoc)");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaNhomHoc", MaNhomHoc);
            object result = cmd.ExecuteScalar();
            DataTable list = new DataTable();
            list = result as DataTable;
            return list;
        }    
    }
}
