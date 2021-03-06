using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; } 
        public User(int userId, int age, string name, string surname, string email)
        {
            UserID = userId;
            Age = age;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
