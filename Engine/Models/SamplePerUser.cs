using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class SamplePerUser
    {
        public int SampleID { get; set; }
        public int UserId { get; set; }

        public SamplePerUser(int sampleID, int userID)
        {
            SampleID = sampleID;
            UserId = userID;
        }
    }
}
