using Core.Entities;
using System;

namespace Entities.DTOs.EventtDtos
{
    public class EventtUpdateDto : IDto
    {
        public int EventtId { get; set; }
        public int EventTypeId { get; set; }
        public int CustomerId { get; set; }
        public int CaseeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public string Info { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
