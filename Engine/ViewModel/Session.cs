using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Factories;
using System.Collections.ObjectModel;

namespace Engine.ViewModel
{
    public class Session
    {
        public int DefaultValue { get; set; }
        public ObservableCollection<BloodPressureSample> Samples {get;set;}
        public List<User> Users { get; set; }
        private User _currentUser;
       
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;

            }
        }
        public Session()
        {
            DefaultValue = 20;
            CurrentUser = new User(1004, 24, "Jane", "Hawking", "janehawking@@mial.rom");

            Samples = DataAccessFactory.BloodPressureSamples;
            Users = DataAccessFactory.Users;
        }
        public User GetUserByID(int id)
        {
            foreach(User user in Users)
            {
                if(user.UserID == id)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
