using Core.DataAccess;
using Core.Entities.Concrete;
using Entities;
using Entities.DTOs.UserDtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user, int licenceId);
        List<User> ListAllUserExceptSomeIds(List<int> ids);
        GetUserInfoDto GetWithInclude(int id);
        GetUserDetailsAsAdmin GetUserDetailsAsAdmin(int id);
        List<GetUserInfoAsAdminDto> GetAllAsAdmin(int pageNumber, int pageSize, UserFilterAsAdmin userFilterAsAdmin);
        User AddWithReturn(User user);
    }
}
