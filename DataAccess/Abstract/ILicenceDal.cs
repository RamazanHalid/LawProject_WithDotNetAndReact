 using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ILicenceDal:IEntityRepository<Licence>
    {
        List<Licence> LicenceWithCity();
        Licence AddWithReturnLastId(Licence licence);
    }
}
