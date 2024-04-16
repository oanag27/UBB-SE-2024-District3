using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.LogIn
{
    public class UserInfo
    {
        private string username;
        private string email;   
        private string password;
        private string confirmationPassword;

        public string Username
        {
            get => username; set => username = value;
        }

        public string Email
        {
            get => email; set => email = value;
        }

        public string Password
        {
            get => password; set => password = value;
        }

        public string ConfirmationPassword
        {
            get => confirmationPassword;
            set => confirmationPassword = value;
        }

        public UserInfo(string username, string email, string password, string confirmationPassword)
        {
            Username = username;
            Email = email;
            Password = password;
            ConfirmationPassword = confirmationPassword;
        }

        public UserInfo(string email, string password) 
        {
            Email = email;
            Password = password;
        }
        
    }
}
