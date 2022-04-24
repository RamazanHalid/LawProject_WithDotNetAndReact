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
                    .Include(c => c.Casee).ThenInclude(f => f.RoleType)
                    .Include(c => c.Casee).ThenInclude(w => w.CaseStatus).ThenInclude(w => w.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(e => e.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(f => f.Customer).ThenInclude(f => f.City)
                    .Include(c => c.Casee).ThenInclude(f => f.CourtOffice).ThenInclude(q => q.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(f => f.CaseType).ThenInclude(q => q.CourtOfficeType)

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
                    .Include(c => c.Casee).ThenInclude(f => f.RoleType)
                    .Include(c => c.Casee).ThenInclude(w => w.CaseStatus).ThenInclude(w => w.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(e => e.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(f => f.Customer).ThenInclude(f => f.City)
                    .Include(c => c.Casee).ThenInclude(f => f.CourtOffice).ThenInclude(q => q.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(f => f.CaseType).ThenInclude(q => q.CourtOfficeType)
                    .ToList()
                    : context.Set<Taskk>()
                     .Include(l => l.Creator)
                    .Include(c => c.User)
                    .Include(c => c.Customer).ThenInclude(w => w.City)
                    .Include(c => c.TaskType)
                    .Include(c => c.TaskStatus)
                    .Include(c => c.Casee).ThenInclude(f => f.RoleType)
                    .Include(c => c.Casee).ThenInclude(w => w.CaseStatus).ThenInclude(w => w.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(e => e.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(f => f.Customer).ThenInclude(f => f.City)
                    .Include(c => c.Casee).ThenInclude(f => f.CourtOffice).ThenInclude(q => q.CourtOfficeType)
                    .Include(c => c.Casee).ThenInclude(f => f.CaseType).ThenInclude(q => q.CourtOfficeType)
                    .Where(filter).ToList();
            }
        }
    }
}
