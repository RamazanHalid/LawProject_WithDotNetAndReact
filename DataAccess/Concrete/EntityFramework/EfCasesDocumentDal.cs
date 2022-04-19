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
    public class EfCasesDocumentDal : EfEntityRepositoryBase<CasesDocument, HukukContext>, ICasesDocumentDal
    {
        public List<CasesDocument> GetAllWithInclude(Expression<Func<CasesDocument, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<CasesDocument>()
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Casee)
                    .ToList()
                    : context.Set<CasesDocument>().Where(filter)
                    .Include(ct => ct.Creator)
                    .Include(ct => ct.Casee)
                    .ToList();
            }
        }

        public CasesDocument GetByIdWithInclude(Expression<Func<CasesDocument, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<CasesDocument>() 
                     .Include(ct => ct.Creator)
                    .Include(ct => ct.Casee)
                    .SingleOrDefault(filter);
            }
        }
    }
}
