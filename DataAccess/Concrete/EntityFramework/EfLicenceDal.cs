using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs.LicenceDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        public List<Licence> GetAllAsAdmin(int pageNumber, int pageSize, LicenceFilterAsAdmin licenceFilterAsAdmin)
        {
            using (var context = new HukukContext())
            {
                var result = context.Set<Licence>();
                if (licenceFilterAsAdmin.ProfileName.Length > 0)
                    result.Where(w => w.ProfilName == licenceFilterAsAdmin.ProfileName);
                if (licenceFilterAsAdmin.UserId > 0)
                    result.Where(w => w.UserId == licenceFilterAsAdmin.UserId);
                if (licenceFilterAsAdmin.Email.Length > 0)
                    result.Where(w => w.Email == licenceFilterAsAdmin.Email);
                if (licenceFilterAsAdmin.IsActive == 0 || licenceFilterAsAdmin.IsActive == 1)
                    result.Where(w => w.IsActive == Convert.ToBoolean(licenceFilterAsAdmin.IsActive));

                return result.Include(l => l.City).ThenInclude(c => c.Country).Include(c => c.PersonType).OrderBy(w => w.StartDate)
                     .Skip(pageNumber * pageSize).Take(pageSize).ToList();
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
