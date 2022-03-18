using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace DataAccess.Abstract
{
    public interface ITaskkDal : IEntityRepository<Taskk>
    {
        List<Taskk> GetAllWithInclude(Expression<Func<Taskk, bool>> filter = null);
        Taskk GetByIdWithInclude(Expression<Func<Taskk, bool>> filter);
    }
}
