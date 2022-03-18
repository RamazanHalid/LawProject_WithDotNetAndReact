using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICaseTypeDal : IEntityRepository<CaseType>
    {
        List<CaseType> GetAllWithInclude(Expression<Func<CaseType, bool>> filter = null);
        CaseType GetByIdWithInclude(Expression<Func<CaseType, bool>> filter);
    }
}
