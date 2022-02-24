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
    public class EfCaseTypeDal : EfEntityRepositoryBase<CaseType, HukukContext>, ICaseTypeDal
    {
        public List<CaseType> GetAllFilter(int courtOfficeTypeId, int isActive)
        {
            using (var context = new HukukContext())
            {
                var operation = context.Set<CaseType>().Include(ct => ct.CourtOfficeType);
                if (courtOfficeTypeId > 0)
                    operation.Where(c => c.CourtOfficeTypeId == courtOfficeTypeId);
                if (isActive == 0 || isActive == 1)
                    operation.Where(c => c.IsActive == Convert.ToBoolean(isActive));

                return operation.ToList();
            }
        }

        public List<CaseType> GetAllWithCourtOfficeType(Expression<Func<CaseType, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<CaseType>().Include(ct => ct.CourtOfficeType).ToList()
                    : context.Set<CaseType>().Where(filter).Include(ct => ct.CourtOfficeType).ToList();
            }
        }

        public CaseType GetByIdWithCourtOfficeType(Expression<Func<CaseType, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<CaseType>().Include(ct => ct.CourtOfficeType).SingleOrDefault(filter);
            }
        }
    }
}
