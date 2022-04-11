using Core.Utilities.Results;
using Entities.DTOs.TransactionActivityDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITransactionActivityService
    {
        IDataResult<List<TransactionActivityGetDto>> GetAll();
        IDataResult<TransactionActivityGetDto> GetById(int id);
        IResult ApproveTransactionActivity(int id);
        IResult Add(TransactionActivityAddDto transactionActivityAddDto);
        IResult Update(TransactionActivityUpdateDto transactionActivityUpdateDto);
        IResult Delete(int id);
        IDataResult<int> GetCountByLicenceId(int licenceId);
        IDataResult<float> TotalBalance();
        IDataResult<float> TotalIncome();
        IDataResult<float> TotalExpense();
    }
}
