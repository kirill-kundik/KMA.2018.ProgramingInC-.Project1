using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.Group2.Project1
{
    class User
    {
        private string _login;
        private string _password;

        public string Login 
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            private set { _password = value; }
        }

        public User(string login, string password)
        {
            _login = login;
            _password = password;
        }
    }
}
