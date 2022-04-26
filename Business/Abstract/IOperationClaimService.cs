using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<OperationClaim> GetByName(string claimsName);
        IDataResult<List<OperationClaim>> GetAllByCategoryId(int operationClaimCategoryId);
    }
}
