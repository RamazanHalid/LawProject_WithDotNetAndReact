using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.LicenceDtos
{
    public class CountOfLicenceInfo : IDto
    {
        //public int CurrentUsageAmount { get; set; }
        public int Client { get; set; }
        public int Case{ get; set; }
        public int TransactionActivity{ get; set; }
        public float CurrentBalance{ get; set; }
        public float CurrentlyUsedDiskSpace{ get; set; }
        public float TotalDiskSpace{ get; set; }
        public int Sms{ get; set; }
        public int NumberOfMember{ get; set; }
        
    }
}
