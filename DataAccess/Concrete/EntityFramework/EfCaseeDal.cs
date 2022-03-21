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
    public class EfCaseeDal : EfEntityRepositoryBase<Casee, HukukContext>, ICaseeDal
    {
        public List<Casee> GetAllWithInclude(Expression<Func<Casee, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<Casee>()
                    .Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .ToList()
                    : context.Set<Casee>().Where(filter)
                    .Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice).ToList();
            }
        }

        public Casee GetByIdWithInclude(Expression<Func<Casee, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<Casee>().Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .SingleOrDefault(filter);
            }
        }
    }
}
