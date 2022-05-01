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
    public class EfCaseeDal : EfEntityRepositoryBase<Casee, HukukContext>, ICaseeDal
    {

        public Casee AddWithReturn(Casee casee)
        {
            using (var context = new HukukContext())
            {
                context.Add(casee);
                context.SaveChanges();
                return casee;
            }
        }

        public List<Casee> GetAllWithInclude(Expression<Func<Casee, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<Casee>()
                    .Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .Include(ct => ct.CaseIgnoreUsers).ThenInclude(w => w.User)
                    .ToList()
                    : context.Set<Casee>().Where(filter)
                    .Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .Include(ct => ct.CaseIgnoreUsers).ThenInclude(w => w.User)
                    .ToList();
            }
        }
        public List<Casee> GetAllWithCaseIgnoreUserList(int userId,Expression<Func<Casee, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                var result = from casees in context.Casees
                             join caseIgnoreUser in context.CaseIgnoreUsers
                             on casees.LicenceId equals caseIgnoreUser.LicenceId
                             where casees.LicenceId == caseIgnoreUser.LicenceId && caseIgnoreUser.UserId != userId
                             
                             select casees;
                return filter == null
                    ?
                      result
                    .Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .Include(ct => ct.CaseIgnoreUsers).ThenInclude(w => w.User)
                    .ToList()
                    : result
                    .Where(filter)
                    .Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .Include(ct => ct.CaseIgnoreUsers).ThenInclude(w => w.User)
                    .ToList();
            }

        }




        public Casee GetByIdWithInclude(Expression<Func<Casee, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<Casee>().Include(ct => ct.CourtOfficeType)
                    .Include(ct => ct.RoleType)
                    .Include(ct => ct.CaseStatus)
                    .Include(ct => ct.CaseType)
                    .Include(ct => ct.Customer)
                    .Include(ct => ct.CourtOffice)
                    .Include(ct => ct.CaseIgnoreUsers).ThenInclude(w => w.User)
                    .SingleOrDefault(filter);
            }
        }
    }
}
