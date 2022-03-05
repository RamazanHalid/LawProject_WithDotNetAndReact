using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

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
        public IResult Add(TransactionActivitySubTypeDto transactionActivitySubTypeDto)
        {
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            transactionActivitySubType.LicenceId = _currentUserService.GetLicenceId();
            _transactionActivitySubTypeDal.Add(transactionActivitySubType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<TransactionActivitySubTypeDto>> GetAll()
        {
            List<TransactionActivitySubType> transactionActivitySubTypes = _transactionActivitySubTypeDal
                    .GetAllWithTransactionActivityType(t => t.LicenceId == _currentUserService.GetLicenceId());
            List<TransactionActivitySubTypeDto> transactionActivitySubTypeDtos = _mapper.Map<List<TransactionActivitySubTypeDto>>(transactionActivitySubTypes);
            return new SuccessDataResult<List<TransactionActivitySubTypeDto>>(transactionActivitySubTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<List<TransactionActivitySubTypeDto>> GetAllActive()
        {
            List<TransactionActivitySubType> transactionActivitySubTypes = _transactionActivitySubTypeDal
                    .GetAllWithTransactionActivityType(t => t.LicenceId == _currentUserService.GetLicenceId() && t.IsActive == true);
            List<TransactionActivitySubTypeDto> transactionActivitySubTypeDtos = _mapper.Map<List<TransactionActivitySubTypeDto>>(transactionActivitySubTypes);
            return new SuccessDataResult<List<TransactionActivitySubTypeDto>>(transactionActivitySubTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<TransactionActivitySubTypeDto> GetById(int id)
        {
            TransactionActivitySubType transactionActivitySubType = _transactionActivitySubTypeDal
                .GetWithTransactionActivityType(t => t.TransactionAcitivitySubTypeId == id);
            TransactionActivitySubTypeDto transactionActivitySubTypeDto = _mapper.Map<TransactionActivitySubTypeDto>(transactionActivitySubType);
            return new SuccessDataResult<TransactionActivitySubTypeDto>(transactionActivitySubTypeDto, Messages.GetByIdSuccessfuly);
        }
        public IResult ChangeActivity(int id)
        {
            var getById = GetById(id);
            if (!getById.Success)
                return new ErrorResult(getById.Message);
            TransactionActivitySubTypeDto transactionActivitySubTypeDto = getById.Data;
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            _transactionActivitySubTypeDal.Delete(transactionActivitySubType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        public IResult Delete(int id)
        {
            var getById = GetById(id);
            if (!getById.Success)
                return new ErrorResult(getById.Message);
            TransactionActivitySubTypeDto transactionActivitySubTypeDto = getById.Data;
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            transactionActivitySubType.LicenceId = _currentUserService.GetLicenceId();
            _transactionActivitySubTypeDal.Delete(transactionActivitySubType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IResult Update(TransactionActivitySubTypeDto transactionActivitySubTypeDto)
        {
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            transactionActivitySubType.LicenceId = _currentUserService.GetLicenceId();
            _transactionActivitySubTypeDal.Update(transactionActivitySubType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
