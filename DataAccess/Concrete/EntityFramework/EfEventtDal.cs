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
    public class EfEventtDal : EfEntityRepositoryBase<Eventt, HukukContext>, IEventtDal
    {
        public List<Eventt> GetAllWithInclude(Expression<Func<Eventt, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<Eventt>()
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.Casee)
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.EventType)
                    .Include(ct => ct.User)
                    .OrderBy(d => d.StartDate).ToList()
                    : context.Set<Eventt>().Where(filter)
                   .Include(ct => ct.Customer)
                    .Include(ct => ct.Casee)
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.EventType)
                    .Include(ct => ct.User)
                    .OrderBy(d => d.StartDate).ToList();
            }
        }
        public List<Eventt> GetAllWithIncludeLastEventsByNumber(int number, Expression<Func<Eventt, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<Eventt>()
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.Casee)
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.EventType)
                    .Include(ct => ct.User)
                    .Take(number)
                    .OrderBy(d => d.StartDate)
                    .ToList()
                    : context.Set<Eventt>().Where(filter)
                   .Include(ct => ct.Customer)
                    .Include(ct => ct.Casee)
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.EventType)
                    .Include(ct => ct.User)
                    .Take(number)
                    .OrderBy(d => d.StartDate)
                    .ToList();
            }
        }
        public Eventt GetByIdWithInclude(Expression<Func<Eventt, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<Eventt>().Include(ct => ct.Customer)
                    .Include(ct => ct.Casee)
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.EventType)
                    .Include(ct => ct.User)
                    .SingleOrDefault(filter);
            }
        }
    }
}
