using Core.Entities;
using System;

namespace Entities.DTOs.PaymentHistoryDtos
{
    public class PaymentHistoryListAsAdmin : IDto
    {
        public int Id { get; set; }
        public int LicenceId { get; set; }
        public string LicenceProfileName { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Balance { get; set; }
    }
}
