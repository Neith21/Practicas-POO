using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCatorce.Login
{
    public class UserManager
    {
        private const string FilePath = "C:\\users.txt";
        private List<User> _users;

        public UserManager()
        {
            _users = new List<User>();
            LoadUsers();
        }

        private void LoadUsers()
        {
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                { 
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        _users.Add(new User(parts[0], parts[1]));
                    }
                }
            }
        }

        private void SaveUser(User user)
        {
            File.AppendAllLines(FilePath, new[] { $"{user.Username},{user.Password}" });
        }

        public bool Register(string username, string password)
        {
            if (_users.Any(u => u.Username == username))
            {
                return false;
            }

            var user = new User(username, password);
            _users.Add(user);
            SaveUser(user);
            return true;
        }

        public bool Login(string username, string password)
        {
            return _users.Any(u => u.Username == username && u.Password == password);
        }
    }
}
