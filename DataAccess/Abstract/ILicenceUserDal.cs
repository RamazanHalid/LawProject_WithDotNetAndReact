using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ILicenceUserDal : IEntityRepository<LicenceUser>
    {
        List<LicenceUser> GetAllWithLicenceAndUser(Expression<Func<LicenceUser, bool>> filter = null);
    }
}
