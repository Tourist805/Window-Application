using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using System.Collections.ObjectModel;

namespace Engine.Factories
{
    public static class DataAccessFactory
    {
        private static List<User> _users = new List<User>();
        private static ObservableCollection<BloodPressureSample> _samples = new ObservableCollection<BloodPressureSample>();
        private static List<SamplePerUser> _userSamples = new List<SamplePerUser>();
        public static List<User> Users => _users;
        public static ObservableCollection<BloodPressureSample> BloodPressureSamples => _samples;
        public static List<SamplePerUser> SamplePerUser => _userSamples;

        static DataAccessFactory()
        {
            _users.Add(new User(1001, 29, "Jane", "Doe", "janedoe@@mail.com"));
            _users.Add(new User(1002, 33, "Robin", "Williams", "robinwilliams@@mail.com"));
            _users.Add(new User(1003, 31, "Jane", "Eyre", "janeeyre@@mail.com"));

            _samples.Add(new BloodPressureSample(9001, new DateTime(2022, 5, 1, 8, 30, 52), 121, 73));
            _samples.Add(new BloodPressureSample(9002, new DateTime(2022, 4, 1, 7, 30, 52), 99, 66));
            _samples.Add(new BloodPressureSample(9003, new DateTime(2022, 5, 1, 2, 30, 52), 120, 55));

            _userSamples.Add(new SamplePerUser(1002, 9002));
            _userSamples.Add(new SamplePerUser(1002, 9003));
            _userSamples.Add(new SamplePerUser(1003, 9001));
        }
    }
}
