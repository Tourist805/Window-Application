using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Engine.Models;

namespace Engine.Factories
{
    public static class UserFactory
    {
        private static List<User> _users = new List<User>();
        public static List<User> Users { 
            get
            {
                return _users;
            }
            private set
            {
                _users = value;
            }
        }
        static UserFactory()
        {
            _users.Add(new User(9001, 28, "Laura", "Doe", "laura.doe@@maild.com"));
            _users.Add(new User(9002, 29, "Anna", "Williams", "annawilliams@maild.com"));
            _users.Add(new User(9003, 34, "Hannah", "Montana", "hannahmontana@@maild.com"));
        }
        public static User CreateUser(int userID)
        {
            return _users.FirstOrDefault(user => user.UserID == userID);
        }
    }
}
