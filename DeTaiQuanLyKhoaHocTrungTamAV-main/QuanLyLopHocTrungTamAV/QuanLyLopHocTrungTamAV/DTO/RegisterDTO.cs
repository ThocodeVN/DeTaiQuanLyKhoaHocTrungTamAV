using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLopHocTrungTamAV.DTO
{
    internal class RegisterDTO
    {
        int id;
        string name;
        DateTime date;
        string sex;
        string address;
        string phone;
        string email;
        int tk;

        public RegisterDTO(string name, DateTime date, string sex, string address, string phone, string email)
        {
            Name = name;
            Date = date;
            Sex = sex;
            Address = address;
            Phone = phone;
            Email = email;
            Tk = tk;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public int Tk { get => tk; set => tk = value; }
    }
}
