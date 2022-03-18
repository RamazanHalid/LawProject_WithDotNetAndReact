using Core.Entities;
using Entities.DTOs.TransactionActivitySubTypeDtos;
using Entities.DTOs.UserDtos;
using System;
namespace Entities.DTOs.TransactionActivityDtos
{
    public class TransactionActivityGetDto : IDto
    {
        public int TransactionActivityId { get; set; }
        public TransactionActivitySubTypeGetDto TransactionActivitySubTypeGetDto { get; set; }
        public UserForAddAnOtherLicenceInfo UserWhoAdd { get; set; }
        public string Info { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsItExpense { get; set; }
        public bool IsApproved { get; set; }
        public UserForAddAnOtherLicenceInfo WhoApproved { get; set; }
    }
}
