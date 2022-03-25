using Core.Entities;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class OperationClaimGroup : IEntity
    {
        public int OperationClaimGroupId { get; set; }
        public string OperationClaimGroupName { get; set; }
        public virtual ICollection<OperationClaim> OperationClaims { get; set; }
    }
}
