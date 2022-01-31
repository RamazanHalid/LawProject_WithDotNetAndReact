using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LicenceUserManager : ILicenceUserService
    {
        private ILicenceUserDal _licenceUserDal;

        public LicenceUserManager(ILicenceUserDal licenceUserDal)
        {
            _licenceUserDal = licenceUserDal;
        }

        public IResult Add(LicenceUser licenceUser)
        {
            _licenceUserDal.Add(licenceUser);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<LicenceUser>> GetAll()
        {
            return new SuccessDataResult<List<LicenceUser>>(_licenceUserDal.GetAllWithLicenceAndUser(), Messages.GetAllSuccessfuly);
        }

        public IDataResult<LicenceUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<LicenceUser>> GetByLicenceId(int licenceId)
        {
            return new SuccessDataResult<List<LicenceUser>>(_licenceUserDal.GetAllWithLicenceAndUser(lu => lu.LicenceId == licenceId), Messages.GetAllSuccessfuly);
        }

        public IDataResult<List<LicenceUser>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<LicenceUser>>(_licenceUserDal.GetAllWithLicenceAndUser(lu => lu.UserId == userId), Messages.GetAllSuccessfuly);
        }
        public IResult Update(LicenceUser licenceUser)
        {
            throw new NotImplementedException();
        }
    }
}
