using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs.LicenceDtos;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
