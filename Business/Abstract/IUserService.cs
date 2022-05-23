using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities;
using Entities.DTOs.UserDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user, int licenceId);
        void Add(User user);
        void Update(User user);
        User GetByCellPhone(string cellPhone);
        IDataResult<List<UserForAddAnOtherLicenceInfo>> GetAllUsersForAddingOtherLicence();
        GetUserInfoDto GetUserInfoByUserId(int userId);
        User GetByUserId(int userId);
        IDataResult<List<GetUserInfoAsAdminDto>> GetAllAsAdmin(int pageNumber, int pageSize, UserFilterAsAdmin userFilterAsAdmin);
        IDataResult<GetUserDetailsAsAdmin> GetUserDetailsAsAdmin(int id);
        User AddWithReturn(User user);
    }
}
