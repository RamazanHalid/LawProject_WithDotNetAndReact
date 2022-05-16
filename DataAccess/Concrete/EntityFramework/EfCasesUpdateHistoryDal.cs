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
    public class EfCasesUpdateHistoryDal : EfEntityRepositoryBase<CasesUpdateHistory, HukukContext>, ICasesUpdateHistoryDal
    {

        public List<CasesUpdateHistory> GetAllWithInclude(int skipVal, int takeVal, Expression<Func<CasesUpdateHistory, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<CasesUpdateHistory>()
                    .Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .OrderBy(w => w.ChangeDate)
                    .Skip(skipVal)
                    .Take(takeVal)
                    .ToList()
                    : context.Set<CasesUpdateHistory>().Where(filter)
                    .Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .Skip(skipVal)
                    .Take(takeVal)
                    .OrderBy(w => w.ChangeDate)
                     .ToList();
            }
        }

        public CasesUpdateHistory GetByIdWithInclude(Expression<Func<CasesUpdateHistory, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<CasesUpdateHistory>().Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .OrderBy(w => w.ChangeDate)
                     .SingleOrDefault(filter);
            }
        }
    }
}
