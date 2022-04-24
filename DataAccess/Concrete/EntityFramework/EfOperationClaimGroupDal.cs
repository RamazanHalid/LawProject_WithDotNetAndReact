using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimGroupDal : EfEntityRepositoryBase<OperationClaimGroup, HukukContext>, IOperationClaimGroupDal
    {
        public List<OperationClaimGroup> GetAllWithInclude(Expression<Func<OperationClaimGroup, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<OperationClaimGroup>()
                    .Include(ct => ct.OperationClaims)

                    .ToList()
                    : context.Set<OperationClaimGroup>().Where(filter)
                     .Include(ct => ct.OperationClaims)
                     .ToList();
            }
        }


    }
}
