using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ISmsHistoryDal : IEntityRepository<SmsHistory>
    {
        List<SmsHistory> GetAllWithPagination(int pageNumber, int pageSize, Expression<Func<SmsHistory, bool>> filter = null);
    }
}
