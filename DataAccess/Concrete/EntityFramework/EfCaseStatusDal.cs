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
    public class EfCaseStatusDal : EfEntityRepositoryBase<CaseStatus, HukukContext>, ICaseStatusDal
    {
        public List<CaseStatus> GetAllExpressionWithInclude(Expression<Func<CaseStatus, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return
                    filter == null
                    ? context.Set<CaseStatus>().Include(cs => cs.CourtOfficeType).ToList()
                    : context.Set<CaseStatus>().Where(filter).Include(cs => cs.CourtOfficeType).ToList();
            }
        }

        public List<CaseStatus> GetAllFilterWithInclude(int licenceId, int courtOfficeId, int isActive)
        {
            using (var context = new HukukContext())
            {
                var caseStasuses = context.Set<CaseStatus>().Include(cs => cs.CourtOfficeType);
                if (courtOfficeId > 0)
                    caseStasuses.Where(c => c.CourtOfficeTypeId == courtOfficeId);
                if (isActive == 1 || isActive == 0)
                {
                    bool boolIsActive = isActive == 1;
                    caseStasuses.Where(c => c.IsActive == boolIsActive);
                }
                if (licenceId > 0)
                    caseStasuses.Where(c => c.LicenceId == licenceId);
                return caseStasuses.ToList();
            }
        }

        public CaseStatus GetWithInclude(Expression<Func<CaseStatus, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<CaseStatus>().Include(cs => cs.CourtOfficeType).SingleOrDefault(filter);
            }
        }

    }
}
