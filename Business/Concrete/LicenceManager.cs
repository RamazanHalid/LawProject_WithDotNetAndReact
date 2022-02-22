using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            var result = _licenceUserService.AddForCreatedNewLicence(new LicenceUser
            {
                IsActive = true,
                LicenceId = newLicence.LicenceId,
                UserId = newLicence.UserId,
                StartDate = newLicence.StartDate,
            });
            if (!result.Success)
                return result;
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IDataResult<Licence> GetById(int id)
        {
            var licence = _licenceDal.GetByIdWithCity(l => l.LicenceId == id);
            if (licence == null)
                return new ErrorDataResult<Licence>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<Licence>(licence, Messages.GetByIdSuccessfuly);
        }

        public IDataResult<List<Licence>> GetAll()
        {
            return new SuccessDataResult<List<Licence>>(_licenceDal.LicenceWithCity());
        }

        public IResult Update(Licence licence)
        {
            _licenceDal.Update(licence);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
