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
        public List<CaseType> GetAllWithInclude(Expression<Func<CaseType, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<CaseType>().Include(ct => ct.CourtOfficeType).ToList()
                    : context.Set<CaseType>().Where(filter).Include(ct => ct.CourtOfficeType).ToList();
            }
        }
        
        public CaseType GetByIdWithInclude(Expression<Func<CaseType, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<CaseType>().Include(ct => ct.CourtOfficeType).SingleOrDefault(filter);
            }
        }
    }
}
