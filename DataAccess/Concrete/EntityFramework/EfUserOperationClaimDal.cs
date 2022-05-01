using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, HukukContext>, IUserOperationClaimDal
    {
        public void DeleteAsList(List<UserOperationClaim> entities)
        {
            using (var context = new HukukContext())
            {
                context.Set<UserOperationClaim>().RemoveRange(entities);
                context.SaveChanges();
            }
        }
        public void AddAsList(List<UserOperationClaim> entities)
        {
            using (var context = new HukukContext())
            {
                context.Set<UserOperationClaim>().AddRange(entities);
                context.SaveChanges();
            }
        }
        public List<int> GetAllIds(Expression<Func<UserOperationClaim, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<UserOperationClaim>()
                    .Select(w => w.OperationClaimId)
                    .ToList()
                    : context.Set<UserOperationClaim>().Where(filter).Select(w => w.OperationClaimId).ToList();
            }
        }

    }
}
