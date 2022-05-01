using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLicenceUserDal : EfEntityRepositoryBase<LicenceUser, HukukContext>, ILicenceUserDal
    {
        public List<LicenceUser> GetAllInclude(Expression<Func<LicenceUser, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<LicenceUser>().Include(lu => lu.Licence).Include(lu => lu.User2).ToList()
                    : context.Set<LicenceUser>().Where(filter).Include(lu => lu.Licence).Include(lu => lu.User2).ToList();
            }
        }
        public LicenceUser GetInclude(Expression<Func<LicenceUser, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<LicenceUser>().Include(lu => lu.Licence).Include(lu => lu.User2).FirstOrDefault(filter);
            }
        }
        public List<int> GetAllUserIdByLicenceId(int licenceId)
        {
            using (var context = new HukukContext())
            {
                return context.Set<LicenceUser>().Where(l => l.LicenceId == licenceId).Select(w => w.UserId).ToList();
            }
        }
        public List<User> GetAllUsersRecordedToTheLicence(Expression<Func<LicenceUser, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return context.Set<LicenceUser>().Where(filter).Select(w => w.User2).ToList();
            }
        }
    }
}
