using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<Customer> GetAllWithInclude(Expression<Func<Customer, bool>> filter = null);
        Customer GetByIdWithInclude(Expression<Func<Customer, bool>> filter);
    }
}
