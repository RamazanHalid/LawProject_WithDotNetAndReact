using Core.Utilities.Results;
using Entities.DTOs.LicenceUserDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface ILicenceUserService
    {
        IDataResult<List<LicenceUserGetDto>> GetAll();
        IDataResult<LicenceUserGetDto> GetById(int id);
        IResult Add(LicenceUserAddDto licenceUserAddDto);
        IResult ChangeAcceptence(int id);
        IResult Update(LicenceUserUpdateDto licenceUser);
        IDataResult<List<LicenceUserGetDto>> GetAllAcceptByUserId(int userId);
        IDataResult<List<LicenceUserGetDto>> GetAllByUserId();
        IResult CheckLicenceBelongToUser(int userId, int licenceId);
        IDataResult<List<LicenceUserGetDto>> GetByLicenceId(int licenceId);
        IDataResult<List<int>> GetAllUserIdsRecordedUser();
        IDataResult<int> GetCountByLicenceId(int licenceId);

    }
}
