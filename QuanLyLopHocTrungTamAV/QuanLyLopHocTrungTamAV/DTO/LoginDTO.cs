using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocTrungTamAV.DTO
{
    public class LoginDTO
    {
        private string _username;
        private string _password;
        private string _role;

        public LoginDTO (string username, string password, string role = "")
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Role { get => _role; set => _role = value; }
    }
}
