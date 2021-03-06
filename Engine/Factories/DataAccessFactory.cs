using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using System.Collections.ObjectModel;

namespace Engine.Factories
{
    public static class DataAccessFactory
    {
        private static ObservableCollection<User> _users = new ObservableCollection<User>();
        private static ObservableCollection<BloodPressureSample> _samples = new ObservableCollection<BloodPressureSample>();
        private static ObservableCollection<BloodPressureSample> _activeSamples = new ObservableCollection<BloodPressureSample>();
        private static ObservableCollection<SamplePerUser> _userSamples = new ObservableCollection<SamplePerUser>();
        public static ObservableCollection<User> Users => _users;
        
        public static ObservableCollection<BloodPressureSample> BloodPressureSamples
        {
            get
            {
                    return _samples;
                
            }
            set
            {
                _samples = value;
            }
        }
        public static ObservableCollection<SamplePerUser> SamplePerUser => _userSamples;
        private static int _currentSampleID = 9004;
        private static int _currentUserID = 0;
        private static bool _isDefinedUserID = false;

        static DataAccessFactory()
        {
            _users.Add(new User(1001, 29, "Jane", "Doe", "janedoe@@mail.com"));
            _users.Add(new User(1002, 33, "Robin", "Williams", "robinwilliams@@mail.com"));
            _users.Add(new User(1003, 31, "Jane", "Eyre", "janeeyre@@mail.com"));

            _samples.Add(new BloodPressureSample(9001, new DateTime(2022, 5, 1, 8, 30, 52), 121, 73));
            _samples.Add(new BloodPressureSample(9002, new DateTime(2022, 4, 1, 7, 30, 52), 99, 66));
            _samples.Add(new BloodPressureSample(9003, new DateTime(2022, 5, 1, 2, 30, 52), 120, 55));

            _userSamples.Add(new SamplePerUser(9002, 1002));
            _userSamples.Add(new SamplePerUser(9003, 1002));
            _userSamples.Add(new SamplePerUser(9001, 1003));
        }
        public static void AddUser(User user)
        {
            _users.Add(user);
        }
        public static User UserByID(string id)
        {
            _currentUserID = InputToInt(id);
            _isDefinedUserID = true;
            foreach (User user in Users)
            {
                if (user.UserID == InputToInt(id))
                {
                    return user;
                }
            }
            return null;
        }
        
        public static ObservableCollection<BloodPressureSample> FindSamplesByUserID(string UserID)
        {
            ObservableCollection<BloodPressureSample> sampleByUserID = new ObservableCollection<BloodPressureSample>();

            int intUserID = InputToInt(UserID);
            List<int> samplesAssignedUser = new List<int>();
            foreach(SamplePerUser smp in _userSamples)
            {
                if(smp.UserId == intUserID)
                {
                    samplesAssignedUser.Add(smp.SampleID);
                }
            }

            for(int i = 0; i < samplesAssignedUser.Count; i++)
            {
                foreach(BloodPressureSample smp1 in _samples)
                {
                    if(smp1.SampleID == samplesAssignedUser[i])
                    {
                        sampleByUserID.Add(smp1);
                    }
                }
            }
            return sampleByUserID;
        }

        public static void UpdateUser(string id, string age, string name, string surname, string email)
        {
            foreach (User user in Users)
            {
                if (user.UserID == InputToInt(id))
                {
                    user.Name = name;
                    user.Age = InputToInt(age);
                    user.Surname = surname;
                    user.Email = email;
                }
            }
        }
       
        private static int InputToInt(string value)
        {
            try
            {
                int result = Int32.Parse(value);
                return result;
            }
            catch (FormatException)
            {
                return 0;
            }
            return 0;
        }
        public static void AddSample(string systolicPressure, string dyastolicPressure, string UserID)
        {
            _samples.Add(new BloodPressureSample(_currentSampleID++, DateTime.Now, InputToInt(systolicPressure), InputToInt(dyastolicPressure)));

            int IntUserID = InputToInt(UserID);
            _userSamples.Add(new SamplePerUser(_currentSampleID, IntUserID));
        }
    }
}
