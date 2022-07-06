using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Factories;
using System.Collections.ObjectModel;
using Engine.Tools;

namespace Engine.ViewModel
{
    public class Session : BaseNotificationClass
    {
        public int DefaultValue { get; set; }
        public ObservableCollection<BloodPressureSample> Samples {get;set;}
        public ObservableCollection<User> Users { get; set; }
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
                OnPropertyChanged();
            }
        }
        public Session()
        {
            DefaultValue = 20;
            CurrentUser = new User(1004, 24, "Jane", "Hawking", "janehawking@@mial.rom");

            Samples = DataAccessFactory.BloodPressureSamples;
            Users = DataAccessFactory.Users;
        }
        private int InputIsString(string id)
        {
            try
            {
                int result = Int32.Parse(id);
                return result;
            }
            catch (FormatException)
            {
                return 0;
            }
            return 0;
        }
        public void SetUserByID(string id)
        {
            CurrentUser = DataAccessFactory.UserByID(id);
        }
        public void AddSample(string systolicPressure, string diastolicPressure)
        {
            DataAccessFactory.AddSample(systolicPressure, diastolicPressure);
        }
    }
}
