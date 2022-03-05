using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class AccountActivityStatus : IEntity
    {
        public int AccountActivityStatusId { get; set; }
        public string Name { get; set; }
    }
}
