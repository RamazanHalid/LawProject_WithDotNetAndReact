using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user, int licenceId);
        List<User> ListAllUserExceptSomeIds(List<int> ids);
        GetUserInfoDto GetWithInclude(int id);
    }
}
