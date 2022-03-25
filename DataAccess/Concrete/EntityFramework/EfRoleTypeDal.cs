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
    public class EfRoleTypeDal : EfEntityRepositoryBase<RoleType, HukukContext>, IRoleTypeDal
    {


        public RoleType GetWithInclude(Expression<Func<RoleType, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<RoleType>().Include(l => l.CourtOfficeType).SingleOrDefault(filter);
            }
        }
        public List<RoleType> GetAllWithInclude(Expression<Func<RoleType, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<RoleType>().Include(l => l.CourtOfficeType).ToList()
                    : context.Set<RoleType>().Include(l => l.CourtOfficeType).Where(filter).ToList();
            }
        }
    }
}
