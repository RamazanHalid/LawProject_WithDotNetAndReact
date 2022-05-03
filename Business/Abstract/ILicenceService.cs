using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using Entities.DTOs.LicenceDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface ILicenceService
    {
        IDataResult<List<LicenceAfterLoginDto>> GetAllAfterLogin(int userId);
        IDataResult<LicenceGetForUpdatingDto> GetCurrentAuthUserLicence();
        IResult Add(LicenceAddDto licenceAddDto);
        IResult Update(LicenceUpdateDto licenceUpdateDro);
        IResult CheckLicenceBelongToUser(int userId, int licenceId);
        IResult AddBalance(int licenceId, float balance);
        IDataResult<CountOfLicenceInfo> GetCountInfo();
        IDataResult<Licence> GetById(int id);
        IDataResult<Licence> GetByIdAsAdmin(int licenceId);
        IDataResult<List<LicenceAfterLoginDto>> GetAllAsAdmin(int pageNumber, int pageSize, LicenceFilterAsAdmin licenceFilterAsAdmin);
    }
}
