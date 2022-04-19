using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IResult AddAsList(int userId, List<int> operationClaimsId)
        {
            var allOperationClaimsSelectedUser = GetAllByUserId(userId).Data;
            _userOperationClaimDal.DeleteAsList(allOperationClaimsSelectedUser);

            int licenceId = _currentUserService.GetLicenceId();
            List<UserOperationClaim> deneme = new List<UserOperationClaim>();
            foreach (var operationClaimId in operationClaimsId)
            {
                deneme.Add(new UserOperationClaim
                {
                    LicenceId = licenceId,
                    OperationClaimId = operationClaimId,
                    UserId = userId

                });

            }
            _userOperationClaimDal.AddAsList(deneme);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var userOperationClaim = _userOperationClaimDal.Get(u => u.Id == id);
            if (userOperationClaim == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        public IDataResult<List<UserOperationClaim>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(t => t.UserId == userId && t.LicenceId == _currentUserService.GetLicenceId()), Messages.GetAllSuccessfuly);
        }
        public IDataResult<List<int>> GetAllIds(int userId)
        {
            return new SuccessDataResult<List<int>>(_userOperationClaimDal.GetAllIds(t => t.UserId == userId && t.LicenceId == _currentUserService.GetLicenceId()), Messages.GetAllSuccessfuly);
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            var userOperationClaim = _userOperationClaimDal.Get(u => u.Id == id);
            if (userOperationClaim == null)
                return new ErrorDataResult<UserOperationClaim>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<UserOperationClaim>(userOperationClaim, Messages.GetByIdSuccessfuly);
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
