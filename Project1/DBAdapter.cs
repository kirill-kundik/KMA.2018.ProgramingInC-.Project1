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
            Users = new List<User> {new User("1", "1"), new User("2", "2"), new User("3", "3")};
        }

        internal static User SignIn(string login, string password)
        {
            return Users.FirstOrDefault(user => user.Login == login && user.Password == password);
        }
    }
}
