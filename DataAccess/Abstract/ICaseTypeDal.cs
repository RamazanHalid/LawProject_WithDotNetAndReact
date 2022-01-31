using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICaseTypeDal : IEntityRepository<CaseType>
    {
        List<CaseType> GetAllWithCourtOfficeType(Expression<Func<CaseType, bool>> filter = null);
        CaseType GetByIdWithCourtOfficeType(Expression<Func<CaseType, bool>> filter);
    }
}
