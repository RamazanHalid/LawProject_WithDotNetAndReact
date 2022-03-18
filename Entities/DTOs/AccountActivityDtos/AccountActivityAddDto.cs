using Microsoft.AspNetCore.Http;
using System;

namespace Entities.DTOs.AccountActivityDtos
{
    public class AccountActivityAddDto
    {
        public int OrderTypeId { get; set; }
        public int AccountActivityTypeId { get; set; }
        public int AccountActivityStatusId { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public DateTime Expiry { get; set; }
        public float TaxCost { get; set; }
        public float Coast { get; set; }
        public string FilePath { get; set; }
        public IFormFile FilePathFile { get; set; }
        public bool IsActive { get; set; }
        public int OrderCount { get; set; }
    }
}
