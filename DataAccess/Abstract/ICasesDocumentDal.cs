using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICasesDocumentDal : IEntityRepository<CasesDocument>
    {
        List<CasesDocument> GetAllWithInclude(Expression<Func<CasesDocument, bool>> filter = null);
        CasesDocument GetByIdWithInclude(Expression<Func<CasesDocument, bool>> filter);
    }
}
