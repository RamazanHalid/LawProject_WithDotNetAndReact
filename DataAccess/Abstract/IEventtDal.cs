using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IEventtDal : IEntityRepository<Eventt>
    {
        List<Eventt> GetAllWithInclude(Expression<Func<Eventt, bool>> filter = null);
        Eventt GetByIdWithInclude(Expression<Func<Eventt, bool>> filter);
        List<Eventt> GetAllWithIncludeLastEventsByNumber(int number, Expression<Func<Eventt, bool>> filter = null);
    }
}
