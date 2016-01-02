using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPD_layout
{
    public class Account
    {
        string username;
        string password;
        string email;

        #region Accessors and Mutators
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        #endregion

        public Account(string username, string pw, string email)
        {
            this.username = username;
            this.password = pw;
            this.email = email;
        }
    }
}
