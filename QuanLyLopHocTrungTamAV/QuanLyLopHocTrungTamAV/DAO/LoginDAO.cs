using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Mask.Design;
using QuanLyLopHocTrungTamAV.DTO;
using QuanLyLopHocTrungTamAV.GUI;
using QuanLyLopHocTrungTamAV.GUI.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.RightsManagement;
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
                teacher = new RegisterDTO(dr["HoTen"].ToString(),Convert.ToDateTime(dr["NgaySinh"]), dr["GioiTinh"].ToString(), dr["DiaChi"].ToString(), dr["SoDienThoai"].ToString(), dr["Email"].ToString());
                teacher.Id = Convert.ToInt32(dr["MaGiaoVien"]);
            }
            return teacher;
        }

        public DataTable ListClassTeaching(RegisterDTO teacher)
        {
            try
            {
                string sqlStr = string.Format("SELECT * FROM dbo.uf_LayDanhSachNhom_DangDay(@MaGiaoVien)");
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@MaGiaoVien", teacher.Id);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable listClass = new DataTable();
                    adapter.Fill(listClass);

                    if (listClass.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu.");
                    }
                    return listClass;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable ListClass()
        {
            string sqlStr = string.Format("SELECT * FROM dbo.uf_LayDanhSachNhom()");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable list = new DataTable();
                adapter.Fill(list);

                if (list.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu.");
                }
                return list ;
            }
        }

        public DataTable LoadStudentOfGroup(int MaNhomHoc)
        {
            string sqlStr = string.Format("SELECT * FROM dbo.func_layDSHocVienNhomHoc(@MaNhomHoc)");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaNhomHoc", MaNhomHoc);
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable list = new DataTable();
                adapter.Fill(list);

                if (list.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu.");
                }
                return list;
            }
        }    

        public DataTable GetScoreOfGroup(int MaNhomHoc) 
        {
            string sqlStr = string.Format("EXEC proc_LapBangDiem @MaNhomHoc");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaNhomHoc", MaNhomHoc);
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable list = new DataTable();
                adapter.Fill(list);

                if (list.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu.");
                }
                return list;
            }
        }

        public void CheckStudent(int MaNhomHoc, int MaHocVien, int HienDien, DateTime NgayHoc)
        {
            string sqlStr = string.Format("EXEC proc_DiemDanhHocVien @NgayHoc, @MaNhomHoc, @MaHocVien, @HienDien");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaNhomHoc", MaNhomHoc);
            cmd.Parameters.AddWithValue("@MaHocVien", MaHocVien);
            cmd.Parameters.AddWithValue("@HienDien", HienDien);
            cmd.Parameters.AddWithValue("@NgayHoc", NgayHoc);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetListCheck()
        {
            string sqlStr = string.Format("SELECT * FROM dbo.uf_LayBangDiemDanh()");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable list = new DataTable();
                adapter.Fill(list);

                if (list.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu.");
                }
                return list;
            }
        }

        public void CheckDate(DateTime date)
        {
            string sqlStr = string.Format("EXEC proc_KiemTraNgayDiemDanh @day");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@day", date);
            cmd.ExecuteNonQuery();
        }
    }
}
