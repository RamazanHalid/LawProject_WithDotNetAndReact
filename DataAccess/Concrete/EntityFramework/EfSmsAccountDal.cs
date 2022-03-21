using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSmsAccountDal : EfEntityRepositoryBase<SmsAccount, HukukContext>, ISmsAccountDal
    {
    }
}
