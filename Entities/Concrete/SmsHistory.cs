using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class SmsHistory : IEntity
    {
        public int SmsHistoryId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientRole { get; set; }
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
    }
}
