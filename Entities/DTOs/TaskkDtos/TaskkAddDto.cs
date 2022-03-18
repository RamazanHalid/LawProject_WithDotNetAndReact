using Core.Entities;
using System;

namespace Entities.DTOs.TaskkDtos
{
    public class TaskkAddDto : IDto
    {
        public int CustomerId { get; set; }
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public string Info { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public int TaskTypeId { get; set; }
    }
}
