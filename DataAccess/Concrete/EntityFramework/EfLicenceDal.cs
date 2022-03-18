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
    public class EfLicenceDal : EfEntityRepositoryBase<Licence, HukukContext>, ILicenceDal
    {
        public Licence GetByIdWithInclude(Expression<Func<Licence, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<Licence>().Include(l => l.City).ThenInclude(c => c.Country).Include(c => c.PersonType).SingleOrDefault(filter);
            }
        }
        public List<Licence> GetAllWithInclude(Expression<Func<Licence, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<Licence>().Include(l => l.City).ThenInclude(c => c.Country).Include(c => c.PersonType).ToList()
                    : context.Set<Licence>().Include(l => l.City).ThenInclude(c => c.Country).Include(c => c.PersonType).Where(filter).ToList();
            }
        }
        public Licence AddWithReturn(Licence licence)
        {
            //IDisposable pattern implementation of c#
            using (var context = new HukukContext())
            {
                var addedLicence = context.Entry(licence);
                addedLicence.State = EntityState.Added;
                context.SaveChanges();
                return licence;
            }

        }
     

    }
}
