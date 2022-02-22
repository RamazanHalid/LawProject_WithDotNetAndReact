using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICaseStatusDal : IEntityRepository<CaseStatus>
    {
        List<CaseStatus> GetAllExpressionWithInclude(Expression<Func<CaseStatus, bool>> filter = null);
        List<CaseStatus> GetAllFilterWithInclude(int licenceId, int courtOfficeId, int isActive);
        CaseStatus GetWithInclude(Expression<Func<CaseStatus, bool>> filter);
    }
}
