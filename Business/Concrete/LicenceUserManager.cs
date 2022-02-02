using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Business.Concrete
{
    public class LicenceUserManager : ILicenceUserService
    {
        private ILicenceUserDal _licenceUserDal;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserOperationClaimService _userOperationClaimService;
        public LicenceUserManager(ILicenceUserDal licenceUserDal, IHttpContextAccessor httpContextAccessor, IUserOperationClaimService userOperationClaimService)
        {
            _licenceUserDal = licenceUserDal;
            _httpContextAccessor = httpContextAccessor;
            _userOperationClaimService = userOperationClaimService;
        }

        public IResult Add(LicenceUser licenceUser)
        {

            _licenceUserDal.Add(licenceUser);
            var result = _userOperationClaimService.Add(new UserOperationClaim
            {
                OperationClaimId = 1,
                UserId = licenceUser.UserId,
            });
            if (!result.Success)
                return result;
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IResult AddForCreatedNewLicence(LicenceUser licenceUser)
        {
            _licenceUserDal.Add(licenceUser);
            var result = _userOperationClaimService.Add(new UserOperationClaim
            {
                OperationClaimId = 2,
                UserId = licenceUser.UserId,

            });
            if (!result.Success)
                return result;
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
        [SecuredOperation("user")]
        public IDataResult<List<LicenceUser>> GetByUserId()
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return new SuccessDataResult<List<LicenceUser>>(_licenceUserDal.GetAllWithLicenceAndUser(lu => lu.UserId == userId), Messages.GetAllSuccessfuly);
        }
        public IResult Update(LicenceUser licenceUser)
        {
            throw new NotImplementedException();
        }
    }
}
