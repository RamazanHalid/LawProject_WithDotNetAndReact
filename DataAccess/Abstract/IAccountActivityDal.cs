using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IAccountActivityDal : IEntityRepository<AccountActivity>
    {
        List<AccountActivity> GetAllWithInclude(Expression<Func<AccountActivity, bool>> filter = null);
        AccountActivity GetWithInclude(Expression<Func<AccountActivity, bool>> filter);
    }
}
