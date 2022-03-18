using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class Taskk : IEntity
    {
        public int TaskkId { get; set; }
        public int LicenceId { get; set; }
        public virtual Licence Licence { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int CaseId { get; set; }
        public virtual Casee Casee { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public string Info { get; set; }
        public int TaskStatusId { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public int TaskTypeId { get; set; }
        public virtual TaskType TaskType { get; set; }


    }
}
