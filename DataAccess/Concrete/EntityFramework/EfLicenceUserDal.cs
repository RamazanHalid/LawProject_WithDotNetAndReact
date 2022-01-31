using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLicenceUserDal : EfEntityRepositoryBase<LicenceUser, HukukContext>, ILicenceUserDal
    {
        public List<LicenceUser> GetAllWithLicenceAndUser(Expression<Func<LicenceUser, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<LicenceUser>().Include(lu=>lu.Licence).ToList()
                    : context.Set<LicenceUser>().Where(filter).Include(lu => lu.Licence).ToList();
            }
        }
    }
}
