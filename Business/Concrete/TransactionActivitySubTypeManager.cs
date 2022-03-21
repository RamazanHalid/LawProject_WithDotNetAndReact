using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.TransactionActivitySubTypeDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TransactionActivitySubTypeManager : ITransactionActivitySubTypeService
    {
        private readonly ITransactionActivitySubTypeDal _transactionActivitySubTypeDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public TransactionActivitySubTypeManager(ITransactionActivitySubTypeDal transactionActivitySubTypeDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _transactionActivitySubTypeDal = transactionActivitySubTypeDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public IResult Add(TransactionActivitySubTypeAddDto transactionActivitySubTypeAddDto)
        {
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeAddDto);
            transactionActivitySubType.LicenceId = _currentUserService.GetLicenceId();
            _transactionActivitySubTypeDal.Add(transactionActivitySubType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<TransactionActivitySubTypeGetDto>> GetAll()
        {
            List<TransactionActivitySubType> transactionActivitySubTypes = _transactionActivitySubTypeDal
                    .GetAllWithTransactionActivityType(t => t.LicenceId == _currentUserService.GetLicenceId());
            List<TransactionActivitySubTypeGetDto> transactionActivitySubTypeDtos = _mapper.Map<List<TransactionActivitySubTypeGetDto>>(transactionActivitySubTypes);
            return new SuccessDataResult<List<TransactionActivitySubTypeGetDto>>(transactionActivitySubTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<List<TransactionActivitySubTypeGetDto>> GetAllByTransactionActovotyId(int id)
        {
            List<TransactionActivitySubType> transactionActivitySubTypes = _transactionActivitySubTypeDal
                    .GetAllWithTransactionActivityType(t => t.LicenceId == _currentUserService.GetLicenceId() && t.TransactionActivityTypeId == id);
            List<TransactionActivitySubTypeGetDto> transactionActivitySubTypeDtos = _mapper.Map<List<TransactionActivitySubTypeGetDto>>(transactionActivitySubTypes);
            return new SuccessDataResult<List<TransactionActivitySubTypeGetDto>>(transactionActivitySubTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<List<TransactionActivitySubTypeGetDto>> GetAllActive()
        {
            List<TransactionActivitySubType> transactionActivitySubTypes = _transactionActivitySubTypeDal
                    .GetAllWithTransactionActivityType(t => t.LicenceId == _currentUserService.GetLicenceId() && t.IsActive == true);
            List<TransactionActivitySubTypeGetDto> transactionActivitySubTypeDtos = _mapper.Map<List<TransactionActivitySubTypeGetDto>>(transactionActivitySubTypes);
            return new SuccessDataResult<List<TransactionActivitySubTypeGetDto>>(transactionActivitySubTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<TransactionActivitySubTypeGetDto> GetById(int id)
        {
            TransactionActivitySubType transactionActivitySubType = _transactionActivitySubTypeDal
                .GetWithTransactionActivityType(t => t.TransactionActivitySubTypeId == id);
            TransactionActivitySubTypeGetDto transactionActivitySubTypeDto = _mapper.Map<TransactionActivitySubTypeGetDto>(transactionActivitySubType);
            return new SuccessDataResult<TransactionActivitySubTypeGetDto>(transactionActivitySubTypeDto, Messages.GetByIdSuccessfuly);
        }
        public IResult ChangeActivity(int id)
        {
            var transactionActivitySubType = _transactionActivitySubTypeDal.Get(t => t.TransactionActivitySubTypeId == id);
            if (transactionActivitySubType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            transactionActivitySubType.IsActive = !transactionActivitySubType.IsActive;
            _transactionActivitySubTypeDal.Update(transactionActivitySubType);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }
        public IResult Delete(int id)
        {

            var transactionActivitySubType = _transactionActivitySubTypeDal.Get(t => t.TransactionActivitySubTypeId == id);
            if (transactionActivitySubType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _transactionActivitySubTypeDal.Delete(transactionActivitySubType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IResult Update(TransactionActivitySubTypeUpdateDto transactionActivitySubTypeDto)
        {
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            transactionActivitySubType.LicenceId = _currentUserService.GetLicenceId();
            _transactionActivitySubTypeDal.Update(transactionActivitySubType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
