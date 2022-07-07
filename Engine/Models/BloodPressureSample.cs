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
        public bool IsNormal => ((MAP >= 70) && (MAP <= 100));
        private MAPPressure _pressure;
        public MAPPressure MapPressure
        {
            get
            {
                if((MAP >= 70) && (MAP <= 100))
                {
                    _pressure = MAPPressure.Normal;
                }
                else if(MAP < 70)
                {
                    _pressure = MAPPressure.Low;
                }
                else
                {
                    _pressure = MAPPressure.High;
                }
                return _pressure;
            }
            private set
            {
                _pressure = value;   
            }
        }
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

    public enum MAPPressure { 
        Normal,
        High,
        Low
    }

}
