using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.Group2.Project1
{
    static class DBAdapter
    {
        public static List<User> Users { get; }

        static DBAdapter()
        {
            Users = new List<User> {new User("1", "1", "One", "LOne", "one@1.com", DateTime.Today), new User("2", "2", "Two", "LTwo", "two@2.com", DateTime.Today), new User("3", "3", "Three", "LThree", "three@3.com", DateTime.Today) };
        }

        internal static User SignIn(string login, string password)
        {
            return Users.FirstOrDefault(user => user.Login == login && user.Password == password);
        }

        internal static User SignUp(string login, string password, string firstName, string lastName, string email, DateTime dateOfBirth)
        {

            if (Users.Any(user => user.Login == login))
                throw new Exception($"User with login: {login} already exists");
             User newUser = new User(login, password, firstName, lastName, email, dateOfBirth);
            Users.Add(newUser);
            return newUser;
        }
    }
}
