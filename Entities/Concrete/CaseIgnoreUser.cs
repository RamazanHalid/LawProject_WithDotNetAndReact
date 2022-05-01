using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class CaseIgnoreUser : IEntity
    {
        public int CaseIgnoreUserId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int CaseeId { get; set; }
        public Casee Casee { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
    }
}
