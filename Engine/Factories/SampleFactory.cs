using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Engine.Models;

namespace Engine.Factories
{
    public static class SampleFactory
    {
        private static List<BloodPressureSample> _samples = new List<BloodPressureSample>();

        static SampleFactory()
        {
            _samples.Add(new BloodPressureSample(1001, new DateTime(2022, 5, 1, 8, 30, 52), 121, 73));
            _samples.Add(new BloodPressureSample(1002, new DateTime(2022, 4, 1, 7, 30, 52), 99, 66));
            _samples.Add(new BloodPressureSample(1003, new DateTime(2022, 5, 1, 2, 30, 52), 120, 55));
        }

        public static BloodPressureSample CreateSample(int sampleID)
        {
            BloodPressureSample standardSample = _samples.FirstOrDefault(sample => sample.SampleID == sampleID);

            if(standardSample != null)
            {
                return standardSample.Clone();
            }
            return null;
        }
    }
}
