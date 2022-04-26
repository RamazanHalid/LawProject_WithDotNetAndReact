using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IDataResult<List<OperationClaim>> GetAllByCategoryId(int operationClaimCategoryId)
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(o => o.OperationClaimCategoryId == operationClaimCategoryId));
        }
        public IDataResult<OperationClaim> GetByName(string claimsName)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Name == claimsName));
        }
    }
}