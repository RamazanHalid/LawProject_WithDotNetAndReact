using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICreditCardReminderDal : IEntityRepository<CreditCardReminder>
    {
        List<CreditCardReminder> GetAllWithDecrypted(Expression<Func<CreditCardReminder, bool>> filter = null);
        CreditCardReminder GetWithDecrypted(Expression<Func<CreditCardReminder, bool>> filter);
     }
}
