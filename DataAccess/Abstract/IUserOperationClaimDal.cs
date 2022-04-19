using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        void DeleteAsList(List<UserOperationClaim> entities);
        void AddAsList(List<UserOperationClaim> entities);
        List<int> GetAllIds(Expression<Func<UserOperationClaim, bool>> filter = null);
    }
}
