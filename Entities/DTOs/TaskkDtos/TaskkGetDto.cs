using Core.Entities;
using Entities.DTOs.CaseeDtos;
using Entities.DTOs.CustomerDtos;
using Entities.DTOs.TaskStatusDtos;
using Entities.DTOs.TaskTypeDtos;
using Entities.DTOs.UserDtos;
using System;

namespace Entities.DTOs.TaskkDtos
{
    public class TaskkGetDto : IDto
    {
        public int TaskkId { get; set; }
        public CustomerGetDto Customer { get; set; }
        public CaseeGetDto Casee { get; set; }
        public UserForLicenceUserGetDto User { get; set; }
        public UserForLicenceUserGetDto Creator { get; set; }
        public string Info { get; set; }
        public TaskStatusGetDto TaskStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public TaskTypeGetDto TaskType { get; set; }
    }
}
