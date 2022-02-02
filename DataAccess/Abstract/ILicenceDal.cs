using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ILicenceDal : IEntityRepository<Licence>
    {
        List<Licence> LicenceWithCity(Expression<Func<Licence,bool>> filter = null);
        Licence GetByIdWithCity(Expression<Func<Licence, bool>> filter);
        Licence AddWithReturnLastId(Licence licence);
    }
}
