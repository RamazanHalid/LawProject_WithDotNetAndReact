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
    public class EfCaseIgnoreUserDal : EfEntityRepositoryBase<CaseIgnoreUser, HukukContext>, ICaseIgnoreUserDal
    {
        public void AddWithRange(List<CaseIgnoreUser> caseIgnoreUsers)
        {
            using (var context = new HukukContext())
            {
                context.CaseIgnoreUsers.AddRange(caseIgnoreUsers);
                context.SaveChanges();
            }
        }
        //Get all CaseIgnores by id and delete them
        public void DeleteWithRange(List<int> caseIgnoreUserIds)
        {
            using (var context = new HukukContext())
            {

                var listOfCI = context.Set<CaseIgnoreUser>();
                foreach (var id in caseIgnoreUserIds)
                {
                    listOfCI.Where(w => w.CaseIgnoreUserId == id);
                }
                context.CaseIgnoreUsers.RemoveRange(listOfCI.ToList());
                context.SaveChanges();
            }
        }
        //Get all CaseIgnores by id and delete them
        public void DeleteByCaseeId(int caseId, int licenceId)
        {
            using (var context = new HukukContext())
            {

                var listOfCI = context.Set<CaseIgnoreUser>().Where(w => w.CaseeId == caseId && w.LicenceId == licenceId).ToList();
                context.CaseIgnoreUsers.RemoveRange(listOfCI);
                context.SaveChanges();
            }
        }
        public List<CaseIgnoreUser> GetAllWithInclude(Expression<Func<CaseIgnoreUser, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {

                return filter == null ?
                       context.Set<CaseIgnoreUser>().Include(e => e.User).ToList()
                       : context.Set<CaseIgnoreUser>().Include(e => e.User).Where(filter).ToList();
            }
        }
        public List<int> GetAllIdsWithInclude(Expression<Func<CaseIgnoreUser, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {

                return filter == null ?
                       context.Set<CaseIgnoreUser>().Include(e => e.CaseeId).Select(x=>x.CaseIgnoreUserId).ToList()
                       : context.Set<CaseIgnoreUser>().Where(filter).Select(x => x.CaseeId).ToList();
            }
        }
    }
}
