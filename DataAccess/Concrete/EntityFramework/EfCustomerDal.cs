using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, HukukContext>, ICustomerDal
    {
        public Customer GetByIdWithInclude(Expression<Func<Customer, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<Customer>().Include(l => l.City).ThenInclude(c => c.Country).SingleOrDefault(filter);
            }
        }
        public List<Customer> GetAllWithInclude(Expression<Func<Customer, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<Customer>().Include(l => l.City).ThenInclude(c => c.Country).ToList()
                    : context.Set<Customer>().Include(l => l.City).ThenInclude(c => c.Country).Where(filter).ToList();
            }
        }



    }
}
