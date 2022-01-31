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
        List<CaseStatus> GetAllWithCourtOfficeType(Expression<Func<CaseStatus, bool>> filter = null);
        CaseStatus GetByIdWithCourtOfficeType(Expression<Func<CaseStatus, bool>> filter);
    }
}
