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
        public ObservableCollection<BloodPressureSample> SamplesByUserID { get; set; }
        public ObservableCollection<User> Users { get; set; }
        private User _currentUser;
        private BloodPressureSample _selectedSample;
        public BloodPressureSample SelectedSample
        {
            get
            {
                return _selectedSample;
            }
            set
            {
                _selectedSample = value;
                OnPropertyChanged();
            }
        }
       
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
            SamplesByUserID = DataAccessFactory.FindSamplesByUserID("1002");
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
            if(DataAccessFactory.UserByID(id) != null)
            {
                CurrentUser = DataAccessFactory.UserByID(id);
            }

        }
        public void AddSample(string systolicPressure, string diastolicPressure, string UserID)
        {
            DataAccessFactory.AddSample(systolicPressure, diastolicPressure, UserID);
        }

        public void UpdateUser(string id, string age, string name, string surname, string email)
        {
            DataAccessFactory.UpdateUser(id, age, name, surname, email);
        }

        public void UpdateSampleByID(string userID)
        {
            SamplesByUserID = DataAccessFactory.FindSamplesByUserID(userID);
        }
    }
}
