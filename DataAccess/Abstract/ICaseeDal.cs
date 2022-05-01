using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICaseeDal : IEntityRepository<Casee>
    {
        Casee AddWithReturn(Casee casee);
        List<Casee> GetAllWithCaseIgnoreUserList(int userId, Expression<Func<Casee, bool>> filter = null);
        List<Casee> GetAllWithInclude(Expression<Func<Casee, bool>> filter = null);
        Casee GetByIdWithInclude(Expression<Func<Casee, bool>> filter);
    }
}
