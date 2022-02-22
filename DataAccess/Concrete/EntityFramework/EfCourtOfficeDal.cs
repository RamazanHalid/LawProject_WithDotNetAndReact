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
    public class EfCourtOfficeDal : EfEntityRepositoryBase<CourtOffice, HukukContext>, ICourtOfficeDal
    {
        public List<CourtOffice> GetAllWithInclude(Expression<Func<CourtOffice, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null ? context.Set<CourtOffice>()
                                 .Include(c => c.City).ThenInclude(c => c.Country)
                                 .Include(c => c.CourtOfficeType).ToList()
                                : context.Set<CourtOffice>()
                                 .Where(filter)
                                 .Include(c => c.City).ThenInclude(c => c.Country)
                                 .Include(c => c.CourtOfficeType).ToList();
            }
        }
        public CourtOffice GetWithInclude(Expression<Func<CourtOffice, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<CourtOffice>()
                                 .Include(c => c.City).ThenInclude(c => c.Country)
                                 .Include(c => c.CourtOfficeType).SingleOrDefault(filter);
            }
        }
    }
}
