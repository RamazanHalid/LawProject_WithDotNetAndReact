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

        public LicenceManager(ILicenceDal licenceDal)
        {
            _licenceDal = licenceDal;
        }

        public IResult Add(Licence licence)
        {
            _licenceDal.Add(licence);
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
