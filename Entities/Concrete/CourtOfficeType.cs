using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class CourtOfficeType : IEntity
    {
        public int CourtOfficeTypeId { get; set; }
        public string CourtOfficeTypeName { get; set; }
    }
}
