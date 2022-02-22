using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user, int licenceId);
        void Add(User user);
        void Update(User user);
        User GetByCellPhone(string cellPhone);
    }
}
