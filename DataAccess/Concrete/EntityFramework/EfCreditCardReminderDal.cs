using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Encryption;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardReminderDal : EfEntityRepositoryBase<CreditCardReminder, HukukContext>, ICreditCardReminderDal
    {
        public List<CreditCardReminder> GetAllWithDecrypted(Expression<Func<CreditCardReminder, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<CreditCardReminder>()
                    .Select(w =>
                    new CreditCardReminder
                    {
                        Id = w.Id,
                        FullName = w.FullName,
                        CreditCardNo = SecurityString.DecryptString(w.CreditCardNo),
                        LatestMonth = w.LatestMonth,
                        LatestYear = w.LatestYear,
                        SecurityCode = w.SecurityCode,
                        LicenceId = w.LicenceId
                    }
                    )
                    .ToList()
                    :
                    context.Set<CreditCardReminder>().Where(filter)
                    .Select(w =>
                    new CreditCardReminder
                    {
                        Id = w.Id,
                        FullName = w.FullName,
                        CreditCardNo = SecurityString.DecryptString(w.CreditCardNo),
                        LatestMonth = w.LatestMonth,
                        LatestYear = w.LatestYear,
                        SecurityCode = w.SecurityCode,
                        LicenceId = w.LicenceId
                    }
                    )
                    .ToList();
            }
        }
        public CreditCardReminder GetWithDecrypted(Expression<Func<CreditCardReminder, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<CreditCardReminder>()
                    .Select(w =>
                    new CreditCardReminder
                    {
                        Id = w.Id,
                        FullName = w.FullName,
                        CreditCardNo = SecurityString.DecryptString(w.CreditCardNo),
                        LatestMonth = w.LatestMonth,
                        LatestYear = w.LatestYear,
                        SecurityCode = w.SecurityCode,
                        LicenceId = w.LicenceId
                    }
                    )
                    .FirstOrDefault(filter);
            }
        }
    }
}
