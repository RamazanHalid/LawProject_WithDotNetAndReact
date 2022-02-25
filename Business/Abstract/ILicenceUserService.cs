using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.LicenceUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{

    public interface ILicenceUserService
    {
        IDataResult<List<LicenceUserGetDto>> GetAll();
        IDataResult<LicenceUserGetDto> GetById(int id);
        IResult Add(LicenceUserAddDto licenceUserAddDto);
        IResult Update(LicenceUserUpdateDto licenceUser);
        IDataResult<List<LicenceUserGetDto>> GetByUserIdManualy(int userId);
        IDataResult<List<LicenceUserGetDto>> GetByLicenceId(int licenceId);

    }
}
