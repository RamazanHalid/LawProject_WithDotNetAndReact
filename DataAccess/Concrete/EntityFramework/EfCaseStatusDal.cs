using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCaseStatusDal : EfEntityRepositoryBase<CaseStatus, HukukContext>, ICaseStatusDal
    {
        public List<CaseStatus> GetAllWithCourtOfficeType(Expression<Func<CaseStatus, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<CaseStatus>().Include(cs => cs.CourtOfficeType).ToList()
                    : context.Set<CaseStatus>().Where(filter).Include(cs => cs.CourtOfficeType).ToList();
            }
        }

        public CaseStatus GetByIdWithCourtOfficeType(Expression<Func<CaseStatus, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<CaseStatus>().Include(cs => cs.CourtOfficeType).SingleOrDefault(filter);
            }
        }
 
    }
}
