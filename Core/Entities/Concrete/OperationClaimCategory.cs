using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Concrete
{
    public class OperationClaimCategory : IEntity
    {
        public int OperationClaimCategoryId { get; set; }
        public string OperationCategoryName { get; set; }
    }
}
