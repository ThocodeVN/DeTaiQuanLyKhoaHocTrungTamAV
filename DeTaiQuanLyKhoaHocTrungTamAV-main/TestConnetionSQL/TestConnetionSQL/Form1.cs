using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestConnetionSQL
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=desktop-1cii1jf\sqlexpress;Initial Catalog=TestSQLCsharp;Integrated Security=True";
        SqlConnection sqlCon = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    MessageBox.Show("Đã mở kết nối thành công");
                }
                else
                {
                    MessageBox.Show("Đã mở kết nối trước đó");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCloseConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    MessageBox.Show("đã đóng kết nối thành công");
                }
                else
                    MessageBox.Show("Kết nối đã được đóng rồi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
