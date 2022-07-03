using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class BloodPressureSample
    {
        public int SampleID { get; set; }
        public DateTime TimeEntered { get; set; }
        public int SystolicPressure {get; set;}
        public int DiastolicPressure { get; set; }
        public int MAP => (DiastolicPressure + (SystolicPressure - DiastolicPressure) / 3);
        public BloodPressureSample(int sampleID, DateTime timeEntered, int systolicPressure, int diastolicPressure)
        {
            SampleID = sampleID;
            TimeEntered = timeEntered;
            SystolicPressure = systolicPressure;
            DiastolicPressure = diastolicPressure;
        }
        public BloodPressureSample Clone()
        {
            return new BloodPressureSample(SampleID, TimeEntered, SystolicPressure, DiastolicPressure);
        }
    }
}
