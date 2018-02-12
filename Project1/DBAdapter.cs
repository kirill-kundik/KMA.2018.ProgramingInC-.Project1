using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.Group2.Project1
{
    static class DBAdapter
    {
        public static List<User> Users { get; }

        static DBAdapter()
        {
            var filepath = Path.Combine(GetAndCreateDataPath(), User.filename);
            if (File.Exists(filepath))
            {
                try
                {
                    Users = SerializeHelper.Deserialize<List<User>>(filepath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to get users from file.{Environment.NewLine}{ex.Message}");
                    throw;
                }
            }
            else
            {
                Users = new List<User>();
            }
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

        internal static void SaveData()
        {
            SerializeHelper.Serialize(Users, Path.Combine(GetAndCreateDataPath(), User.filename));
        }

        private static string GetAndCreateDataPath()
        {
            string dir = StationManager.WorkingDirectory;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }
    }
}
