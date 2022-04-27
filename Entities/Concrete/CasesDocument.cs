using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public class CasesDocument : IEntity
    {
        public int CasesDocumentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string DocumentPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int CaseeId { get; set; }
        public Casee Casee { get; set; }
    }
}
