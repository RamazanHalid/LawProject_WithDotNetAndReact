using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonType : IEntity
    {
        public int PersonTypeId { get; set; }
        public string PersonTypeName { get; set; }
 

    }
}
