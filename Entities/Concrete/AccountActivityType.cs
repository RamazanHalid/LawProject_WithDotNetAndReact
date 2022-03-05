using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class AccountActivityType : IEntity
    {
        public int AccountActivityTypeId { get; set; }
        public string Name { get; set; }
    }
}
