using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRoleTypeDal : IEntityRepository<RoleType>
    {
        List<RoleType> GetAllWithInclude(Expression<Func<RoleType, bool>> filter = null);
        RoleType GetWithInclude(Expression<Func<RoleType, bool>> filter);
    }
}
