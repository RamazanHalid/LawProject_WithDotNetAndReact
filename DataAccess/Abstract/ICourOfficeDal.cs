using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICourtOfficeDal : IEntityRepository<CourtOffice>
    {
        List<CourtOffice> GetAllWithInclude(Expression<Func<CourtOffice, bool>> filter = null);
        CourtOffice GetWithInclude(Expression<Func<CourtOffice, bool>> filter);
    }
}
