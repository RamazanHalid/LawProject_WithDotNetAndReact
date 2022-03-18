using Entities.Concrete;
using Entities.DTOs.AccountActivityStatusDtos;
using Entities.DTOs.AccountActivityTypeDtos;
using System;

namespace Entities.DTOs.AccountActivityDtos
{
    public class AccountActivityGetDto
    {
        public int AccountActivityId { get; set; }
        public OrderType OrderType { get; set; }
        public AccountActivityTypeGetDto AccountActivityTypeGetDto { get; set; }
        public AccountActivityStatusGetDto AccountActivityStatusGetDto { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public DateTime Expiry { get; set; }
        public float TaxCost { get; set; }
        public float Coast { get; set; }
        public string FilePath { get; set; }
        public bool IsActive { get; set; }
        public int OrderCount { get; set; }
    }
}
