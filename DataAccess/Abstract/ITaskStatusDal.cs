using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ITaskStatusDal : IEntityRepository<TaskStatus>
    {
    }
}
