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
    public class EfTaskkDal : EfEntityRepositoryBase<Taskk, HukukContext>, ITaskkDal
    {
        public Taskk GetByIdWithInclude(Expression<Func<Taskk, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<Taskk>()
                    .Include(l => l.Creator)
                    .Include(c => c.User)
                    .Include(c => c.Customer).ThenInclude(w => w.City)
                    .Include(c => c.TaskType)
                    .Include(c => c.TaskStatus)
                    .SingleOrDefault(filter);
            }
        }
        public List<Taskk> GetAllWithInclude(Expression<Func<Taskk, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<Taskk>()
                    .Include(l => l.Creator)
                    .Include(c => c.User)
                    .Include(c => c.Customer).ThenInclude(w => w.City)
                    .Include(c => c.TaskType)
                    .Include(c => c.TaskStatus)
                    .ToList()
                    : context.Set<Taskk>()
                    .Include(l => l.Creator)
                    .Include(c => c.User)
                    .Include(c => c.Customer).ThenInclude(w=>w.City)
                    .Include(c => c.TaskType)
                    .Include(c => c.TaskStatus)
                    .Where(filter).ToList();
            }
        }
    }
}
