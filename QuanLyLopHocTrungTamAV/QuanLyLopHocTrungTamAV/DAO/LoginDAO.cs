using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Mask.Design;
using DevExpress.XtraPrinting;
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
        public RegisterDTO GetOneStudent(string maTk)
        {
            string sql = string.Format("SELECT * FROM HOCVIEN WHERE MaTK = '{0}'", maTk);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            RegisterDTO student = null;
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                student = new RegisterDTO(dr["TenHocVien"].ToString(), Convert.ToDateTime(dr["NgaySinh"]), dr["GioiTinh"].ToString(), dr["DiaChi"].ToString(), dr["SoDienThoai"].ToString(), dr["Email"].ToString());
                student.Id = Convert.ToInt32(dr["MaHocVien"]);
            }
            return student;
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

        public void CreateNote(RegisterDTO teacher, string title, string content)
        {
            string sqlStr = string.Format("EXEC proc_ThemThongBao @MaGiaoVien, @TieuDe, @NoiDung");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaGiaoVien", teacher.Id);
            cmd.Parameters.AddWithValue("@TieuDe", title);
            cmd.Parameters.AddWithValue("@NoiDung", content);
            cmd.ExecuteNonQuery();
        }

        public DataTable ViewNoteByTeacher(RegisterDTO teacher)
        {
            string sqlStr = string.Format("SELECT * FROM uf_XemThongBaoGiaoVien (@MaGiaoVien)");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaGiaoVien", teacher.Id);
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

        public void SendMessage(string MaNhomHoc)
        {
            try
            {
                string sqlStr = string.Format("EXEC proc_ThemTruyenTin @MaNhomHoc");
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@MaNhomHoc", MaNhomHoc);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Gửi Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetSendHistory(int MaThongBao)
        {
            string sqlStr = string.Format("SELECT * FROM dbo.uf_XemLichSuGui(@MaThongBao)");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaThongBao", MaThongBao);
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

        public void UpdateInforTeacher(RegisterDTO Teacher)
        {
            string sqlStr = string.Format("EXEC proc_SuaThongTinGiaoVien @MaGiaoVien, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaGiaoVien", Teacher.Id);
            cmd.Parameters.AddWithValue("@HoTen", Teacher.Name);
            cmd.Parameters.AddWithValue("@NgaySinh", Teacher.Date);
            cmd.Parameters.AddWithValue("@GioiTinh", Teacher.Sex);
            cmd.Parameters.AddWithValue("@DiaChi", Teacher.Address);
            cmd.Parameters.AddWithValue("@SoDienThoai", Teacher.Phone);
            cmd.ExecuteNonQuery();
        }
        public void UpdateInforStudent(RegisterDTO Student)
        {
            string sqlStr = string.Format("EXEC proc_SuaThongTinHocVien @MaHocVien, @TenHocVien, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaHocVien", Student.Id);
            cmd.Parameters.AddWithValue("@TenHocVien", Student.Name);
            cmd.Parameters.AddWithValue("@NgaySinh", Student.Date);
            cmd.Parameters.AddWithValue("@GioiTinh", Student.Sex);
            cmd.Parameters.AddWithValue("@DiaChi", Student.Address);
            cmd.Parameters.AddWithValue("@SoDienThoai", Student.Phone);
            cmd.ExecuteNonQuery();
        }

        public void UpdateScore(int MaNhomHoc, int MaHocVien, float DiemGiuaKhoa, float DiemCuoiKhoa)
        {
            try
            {
                string sqlStr = string.Format("EXEC proc_SuaBangDiem @MaHocVien, @MaNhomHoc, @DiemGiuaKhoa, @DiemCuoiKhoa");
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@MaHocVien", MaHocVien);
                cmd.Parameters.AddWithValue("@MaNhomHoc", MaNhomHoc);
                cmd.Parameters.AddWithValue("@DiemGiuaKhoa", DiemGiuaKhoa);
                cmd.Parameters.AddWithValue("@DiemCuoiKhoa", DiemCuoiKhoa);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật điểm thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetListCourse()
        {
            string sqlStr = string.Format("SELECT * FROM uf_LayDanhSachKhoa()");
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

        public void AddCourse(string TenKH)
        {
            try
            {
                string sqlStr = string.Format("EXEC proc_ThemKhoaHoc @TenKhoaHoc");
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@TenKhoaHoc", TenKH);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Khóa Học Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetListClass()
        {
            string sqlStr = string.Format("SELECT * FROM uf_LayDanhSachLop()");
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

        public DataTable GetListClassFollowCourse(int MaKH)
        {
            string sqlStr = string.Format("SELECT * FROM uf_LayDanhSachLopTheoKhoa(@MaKhoaHoc)");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaKhoaHoc", MaKH);
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

        public void AddClass(int MaKH, string TenLH, int tongBuoi, float HocPhi)
        {
            try
            {
                string sqlStr = string.Format("EXEC proc_ThemLopHoc @MaKhoaHoc, @TenLopHoc, @TongSoBuoiHoc, @HocPhi");
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@MaKhoaHoc", MaKH);
                cmd.Parameters.AddWithValue("@TenLopHoc", TenLH);
                cmd.Parameters.AddWithValue("@TongSoBuoiHoc", tongBuoi);
                cmd.Parameters.AddWithValue("@HocPhi", HocPhi);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm lớp học thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public DataTable GetListGroupFollowClass(int MaLH)
        {
            string sqlStr = string.Format("SELECT * FROM uf_LayDanhSachNhomTheoLop(@MaLopHoc)");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@MaLopHoc", MaLH);
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

        public void AddGroup()
        {

            try
            {
                string sqlStr = string.Format("EXEC proc_ThemNhomHoc @MaLopHoc, @MaGiaoVien, @Ca, @SoLuongHocVienToiThieu, @SoLuongHocVienToiDa, @NgayBatDau, @TongBuoiHoc");
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@MaKhoaHoc", MaKH);
                cmd.Parameters.AddWithValue("@TenLopHoc", TenLH);
                cmd.Parameters.AddWithValue("@TongSoBuoiHoc", tongBuoi);
                cmd.Parameters.AddWithValue("@HocPhi", HocPhi);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm lớp học thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
