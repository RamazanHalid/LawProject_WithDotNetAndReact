using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class LicenceManager : ILicenceService
    {
        private ILicenceDal _licenceDal;
        private ILicenceUserService _licenceUserService;

        public LicenceManager(ILicenceDal licenceDal, ILicenceUserService licenceUserService)
        {
            _licenceDal = licenceDal;
            _licenceUserService = licenceUserService;
        }

        public IResult Add(Licence licence)
        {
            var newLicence = _licenceDal.AddWithReturnLastId(licence);
            var result = _licenceUserService.Add(new LicenceUser
            {
                IsActive = true,
                LicenceId = newLicence.LicenceId,
                UserId = newLicence.UserId,
                StartDate = newLicence.StartDate,
            });
            if (!result.Success)
                return result;
            return new SuccessResult("Add success");
        }

        public IResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Licence> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Licence>> GetAll()
        {
            return new SuccessDataResult<List<Licence>>(_licenceDal.LicenceWithCity());
        }

        public IResult Update(Licence licence)
        {
            throw new System.NotImplementedException();
        }
    }
}
