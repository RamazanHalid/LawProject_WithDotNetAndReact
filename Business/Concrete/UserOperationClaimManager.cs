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
        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
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
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), Messages.GetAllSuccessfuly);
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
