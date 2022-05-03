using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ILicenceUserDal : IEntityRepository<LicenceUser>
    {
        List<LicenceUser> GetAllInclude(Expression<Func<LicenceUser, bool>> filter = null);
        LicenceUser GetInclude(Expression<Func<LicenceUser, bool>> filter);
        List<int> GetAllUserIdByLicenceId(int licenceId);
        List<User> GetAllUsersRecordedToTheLicence(Expression<Func<LicenceUser, bool>> filter = null);
        List<GetUserInfoForLicenceUserAsAdminDto> GetAllUserRecordToLicence(int pageNumber, int pageSize, int licenceId);
    }
}
