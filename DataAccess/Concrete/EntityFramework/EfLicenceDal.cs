using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLicenceDal : EfEntityRepositoryBase<Licence, HukukContext>, ILicenceDal
    {
        public Licence AddWithReturnLastId(Licence licence)
        {
            using (var context = new HukukContext())
            {
                var AddLicence = context.Entry(licence);
                AddLicence.State = EntityState.Added;
                context.SaveChanges();
                return licence;
            }
        }

        public Licence GetByIdWithCity(Expression<Func<Licence, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<Licence>().Include(l => l.City).ThenInclude(c => c.Country).SingleOrDefault(filter);
            }
        }

        public List<Licence> LicenceWithCity(Expression<Func<Licence, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<Licence>().Include(l => l.City).ThenInclude(c => c.Country).ToList()
                    : context.Set<Licence>().Include(l => l.City).ThenInclude(c => c.Country).Where(filter).ToList();
            }
        }
    }
}
