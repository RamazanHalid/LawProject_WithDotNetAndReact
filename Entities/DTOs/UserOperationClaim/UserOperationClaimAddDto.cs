using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.UserOperationClaim
{
    public class UserOperationClaimAddDto
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
