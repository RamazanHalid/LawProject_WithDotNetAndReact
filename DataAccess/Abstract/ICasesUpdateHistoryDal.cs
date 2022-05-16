using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICasesUpdateHistoryDal : IEntityRepository<CasesUpdateHistory>
    {
        List<CasesUpdateHistory> GetAllWithInclude(int skipVal, int takeVal, Expression<Func<CasesUpdateHistory, bool>> filter = null);
        CasesUpdateHistory GetByIdWithInclude(Expression<Func<CasesUpdateHistory, bool>> filter);
    }
}
