using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProcessTypeDal: EfEntityRepositoryBase<ProcessType, HukukContext>, IProcessTypeDal
    {
    }
}
