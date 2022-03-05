using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderType : IEntity
    {
        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }
    }
}
