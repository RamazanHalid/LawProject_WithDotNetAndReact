using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICaseIgnoreUserDal : IEntityRepository<CaseIgnoreUser>
    {
        void AddWithRange(List<CaseIgnoreUser> caseIgnoreUsers);
        void DeleteByCaseeId(int caseId, int licenceId);
        void DeleteWithRange(List<int> caseIgnoreUsers);
        List<int> GetAllIdsWithInclude(Expression<Func<CaseIgnoreUser, bool>> filter = null);
        List<CaseIgnoreUser> GetAllWithInclude(Expression<Func<CaseIgnoreUser, bool>> filter = null);
    }
}
