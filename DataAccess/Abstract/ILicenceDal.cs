using Core.DataAccess;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace DataAccess.Abstract
{
    public interface ILicenceDal : IEntityRepository<Licence>
    {
        List<Licence> GetAllWithInclude(Expression<Func<Licence, bool>> filter = null);
        Licence GetByIdWithInclude(Expression<Func<Licence, bool>> filter);
        Licence AddWithReturn(Licence licence);
        List<Licence> GetAllAsAdmin(int pageNumber, int pageSize, LicenceFilterAsAdmin licenceFilterAsAdmin);
    }
}
