using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{

    public interface ILicenceUserService
    {
        IDataResult<List<LicenceUser>> GetAll();
        IDataResult<LicenceUser> GetById(int id);
        IResult Add(LicenceUser licenceUser);
        IResult AddForCreatedNewLicence(LicenceUser licenceUser);
        IResult Update(LicenceUser licenceUser); 
        IDataResult<List<LicenceUser>> GetByUserId();
        IDataResult<List<LicenceUser>> GetByUserIdManualy(int userId);

        IDataResult<List<LicenceUser>> GetByLicenceId(int licenceId);

    }
}
