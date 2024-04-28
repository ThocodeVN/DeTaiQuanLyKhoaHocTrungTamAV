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

namespace Func_Spr
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=desktop-1cii1jf\sqlexpress;Initial Catalog=TestSQLCsharp;Integrated Security=True";
        SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select dbo.Hello()", sqlCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();
        }

        private void btnGoodNight_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            string q = string.Format("select dbo.Goodnight('{0}')", txtParFunc.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(q, sqlCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();
        }

        private void btnInfor_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("exec Info", sqlCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();
        }

        private void btnInfor_ID_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            string q = string.Format("exec Info_ID {0}", txtParProc.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(q, sqlCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();
        }
    }
}
