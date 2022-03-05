using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TransactionActivityTypeManager : ITransactionActivityTypeService
    {
        private ITransactionActivityTypeDal _transactionActivityTypeDal;

        public TransactionActivityTypeManager(ITransactionActivityTypeDal transactionActivityTypeDal)
        {
            _transactionActivityTypeDal = transactionActivityTypeDal;
        }

        public IResult Add(TransactionActivityType transactionActivityType)
        {
            _transactionActivityTypeDal.Add(transactionActivityType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var getById = GetById(id);
            if (!getById.Success)
                return new ErrorResult(getById.Message);
            var transactionActivityType = getById.Data;
            _transactionActivityTypeDal.Delete(transactionActivityType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<TransactionActivityType>> GetAll()
        {
            return new SuccessDataResult<List<TransactionActivityType>>(_transactionActivityTypeDal.GetAll(), Messages.GetAllSuccessfuly);
        }

        public IDataResult<TransactionActivityType> GetById(int id)
        {
            var transactionActivityType = _transactionActivityTypeDal.Get(t => t.TransactionActivityTypeId == id);
            if (transactionActivityType == null)
                return new ErrorDataResult<TransactionActivityType>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<TransactionActivityType>(transactionActivityType, Messages.GetByIdSuccessfuly);
        }

        public IResult Update(TransactionActivityType transactionActivityType)
        {
            _transactionActivityTypeDal.Update(transactionActivityType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
