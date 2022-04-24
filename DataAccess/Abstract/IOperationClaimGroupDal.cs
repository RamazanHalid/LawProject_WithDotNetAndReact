using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IOperationClaimGroupDal : IEntityRepository<OperationClaimGroup>
    {
        List<OperationClaimGroup> GetAllWithInclude(Expression<Func<OperationClaimGroup, bool>> filter = null);
    }
}
