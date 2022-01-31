using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CustomerUserRelation : IEntity
    {
        public int CustomerUserRelationId { get; set; }
        public int CustomerUserId { get; set; }
        public int RelationTypeId { get; set; }
        public int RelationId { get; set; }
        public int SideId { get; set; }
        public bool IsActive { get; set; }

    }
}
