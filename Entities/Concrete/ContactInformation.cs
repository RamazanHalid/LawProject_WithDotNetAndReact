using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class ContactInformation : IEntity
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string CellPhone { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
