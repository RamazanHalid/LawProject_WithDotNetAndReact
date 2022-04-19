using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAllByUserId(int userId);
        IDataResult<List<int>> GetAllIds(int userId);
        IDataResult<UserOperationClaim> GetById(int id);
        IResult AddAsList(int userId, List<int> operationClaimsId);
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        IResult Delete(int id);
    }
}
