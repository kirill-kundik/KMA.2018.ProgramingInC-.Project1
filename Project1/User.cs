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
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth;

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

        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            private set { _dateOfBirth = value; }
        }

        public User(string login, string password, string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            _login = login;
            _password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
    }
}
