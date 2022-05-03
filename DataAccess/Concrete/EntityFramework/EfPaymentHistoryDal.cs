using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs.PaymentHistoryDtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentHistoryDal : EfEntityRepositoryBase<PaymentHistory, HukukContext>, IPaymentHistoryDal
    {
        public List<PaymentHistoryListAsAdmin> GetAllAsAdmin(int pageNumber, int pageSize, int licenceId)
        {
            using (var context = new HukukContext())
            {
                var result = context.Set<PaymentHistory>();
                result.Include(l => l.Licence);
                if (licenceId > 0)
                    result.Where(w => w.LicenceId == licenceId);
                result.Skip(pageNumber * pageSize).Take(pageSize);
                return result.Select(x => new PaymentHistoryListAsAdmin
                {
                    Balance = x.Balance,
                    Id = x.Id,
                    LicenceId = x.LicenceId,
                    LicenceProfileName = x.Licence.ProfilName,
                    PaymentDate = x.PaymentDate

                }).ToList();
            }
        }

    }
}
