using Core.Entities;
using Entities.DTOs.CaseeDtos;
using Entities.DTOs.CustomerDtos;
using Entities.DTOs.EventTypeDtos;
using Entities.DTOs.UserDtos;
using System;

namespace Entities.DTOs.EventtDtos
{
    public class EventtGetDto : IDto
    {
        public int EventtId { get; set; }
        public EventTypeGetDto EventType { get; set; }
        public CustomerGetDto Customer { get; set; }
        public string Title { get; set; }

        public CaseeGetDto Casee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public UserForLicenceUserGetDto User { get; set; }
        public string Info { get; set; }
        public bool IsActive { get; set; }
        public UserForLicenceUserGetDto Creator { get; set; }
    }
}
