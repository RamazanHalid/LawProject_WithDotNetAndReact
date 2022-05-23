using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OperationClaimGroupManager : IOperationClaimGroupService
    {
        private IOperationClaimGroupDal _operationClaimGroupDal;

        public OperationClaimGroupManager(IOperationClaimGroupDal operationClaimGroupDal)
        {
            _operationClaimGroupDal = operationClaimGroupDal;
        }

        public IDataResult<List<OperationClaimGroup>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaimGroup>>(_operationClaimGroupDal.GetAllWithInclude(s=>s.OperationClaimGroupName != "admin"));
        }

    }
}
