using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Concrete;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLicenceUserDal : EfEntityRepositoryBase<LicenceUser, HukukContext>, ILicenceUserDal
    {
        public List<LicenceUser> GetAllInclude(Expression<Func<LicenceUser, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<LicenceUser>().Include(lu => lu.Licence).Include(lu => lu.User).ToList()
                    : context.Set<LicenceUser>().Where(filter).Include(lu => lu.Licence).Include(lu => lu.User).ToList();
            }
        }
        public LicenceUser GetInclude(Expression<Func<LicenceUser, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<LicenceUser>().Include(lu => lu.Licence).Include(lu => lu.User).FirstOrDefault(filter);
            }
        }
    }
}
