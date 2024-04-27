﻿using QuanLyLopHocTrungTamAV.DTO;
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
            conn = new SqlConnection(@"Data Source=DESKTOP-1CII1JF\SQLEXPRESS;Initial Catalog=DBhqt;User Id=" + loginDTO.Username + ";Password=" + loginDTO.Password + ";");
            DataTable dt = new DataTable();
            string role = "";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TAIKHOAN WHERE TenDangNhap = '" + loginDTO.Username + "'", conn);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["QuyenNguoiDung"].ToString() == "Quyen1")
                    {
                        role = "Quyen1";
                    }    
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
    }
}
