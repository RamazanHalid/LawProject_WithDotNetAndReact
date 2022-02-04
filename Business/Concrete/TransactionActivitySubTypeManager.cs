using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class TransactionActivitySubTypeManager : ITransactionActivitySubTypeService
    {
        private ITransactionActivitySubTypeDal _transactionActivitySubTypeDal;

        public TransactionActivitySubTypeManager(ITransactionActivitySubTypeDal transactionActivitySubTypeDal)
        {
            _transactionActivitySubTypeDal = transactionActivitySubTypeDal;
        }

        public IResult Add(TransactionActivitySubType transactionActivitySubType)
        {
            _transactionActivitySubTypeDal.Add(transactionActivitySubType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult ChangeActivity(int id)
        {
            var getById = GetByIdWithTransactionActivityType(id);
            if (!getById.Success)
                return new ErrorResult(getById.Message);
            var transactionActivityType = getById.Data;
            _transactionActivitySubTypeDal.Delete(transactionActivityType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var getById = GetByIdWithTransactionActivityType(id);
            if (!getById.Success)
                return new ErrorResult(getById.Message);
            var transactionActivityType = getById.Data;
            _transactionActivitySubTypeDal.Delete(transactionActivityType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<TransactionActivitySubType>> GetAllByLicenceIdWithTransactionActivityType(int licenceId, int isActive)
        {
            if (isActive == 0)
                return new SuccessDataResult<List<TransactionActivitySubType>>(_transactionActivitySubTypeDal
                    .GetAllWithTransactionActivityType(t => t.LicenceId == licenceId && t.IsActive == false)
                    , Messages.GetAllByLicenceIdSuccessfuly);
            if (isActive == 1)
                return new SuccessDataResult<List<TransactionActivitySubType>>(_transactionActivitySubTypeDal
                     .GetAllWithTransactionActivityType(t => t.LicenceId == licenceId && t.IsActive == true)
                     , Messages.GetAllByLicenceIdSuccessfuly);
            return new SuccessDataResult<List<TransactionActivitySubType>>(_transactionActivitySubTypeDal
                     .GetAllWithTransactionActivityType(t => t.LicenceId == licenceId)
                     , Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<TransactionActivitySubType> GetByIdWithTransactionActivityType(int id)
        {
            return new SuccessDataResult<TransactionActivitySubType>(_transactionActivitySubTypeDal
                .GetWithTransactionActivityType(t => t.TransactionAcitivitySubTypeId == id), Messages.GetByIdSuccessfuly);
        }

        public IResult Update(TransactionActivitySubType transactionActivitySubType)
        {
            _transactionActivitySubTypeDal.Update(transactionActivitySubType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
