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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int _authUserLicenceId;
        public TransactionActivitySubTypeManager(ITransactionActivitySubTypeDal transactionActivitySubTypeDal, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _transactionActivitySubTypeDal = transactionActivitySubTypeDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                _authUserLicenceId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GroupSid));
        }
        public IResult Add(TransactionActivitySubTypeDto transactionActivitySubTypeDto)
        {
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            transactionActivitySubType.LicenceId = _authUserLicenceId;
            _transactionActivitySubTypeDal.Add(transactionActivitySubType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<TransactionActivitySubTypeDto>> GetAllByLicenceIdWithTransactionActivityType(int isActive)
        {
            List<TransactionActivitySubType> transactionActivitySubTypes;
            if (isActive == 0)
                transactionActivitySubTypes = _transactionActivitySubTypeDal
                    .GetAllWithTransactionActivityType(t => t.LicenceId == _authUserLicenceId && t.IsActive == false);
            else if (isActive == 1)
                transactionActivitySubTypes = _transactionActivitySubTypeDal
                     .GetAllWithTransactionActivityType(t => t.LicenceId == _authUserLicenceId && t.IsActive == true);
            else
                transactionActivitySubTypes = _transactionActivitySubTypeDal
                         .GetAllWithTransactionActivityType(t => t.LicenceId == _authUserLicenceId);
            List<TransactionActivitySubTypeDto> transactionActivitySubTypeDtos = _mapper.Map<List<TransactionActivitySubTypeDto>>(transactionActivitySubTypes);
            return new SuccessDataResult<List<TransactionActivitySubTypeDto>>(transactionActivitySubTypeDtos, Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<TransactionActivitySubTypeDto> GetByIdWithTransactionActivityType(int id)
        {
            TransactionActivitySubType transactionActivitySubType = _transactionActivitySubTypeDal
                .GetWithTransactionActivityType(t => t.TransactionAcitivitySubTypeId == id);
            TransactionActivitySubTypeDto transactionActivitySubTypeDto = _mapper.Map<TransactionActivitySubTypeDto>(transactionActivitySubType);
            return new SuccessDataResult<TransactionActivitySubTypeDto>(transactionActivitySubTypeDto, Messages.GetByIdSuccessfuly);
        }
        public IResult ChangeActivity(int id)
        {
            var getById = GetByIdWithTransactionActivityType(id);
            if (!getById.Success)
                return new ErrorResult(getById.Message);
            TransactionActivitySubTypeDto transactionActivitySubTypeDto = getById.Data;
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            _transactionActivitySubTypeDal.Delete(transactionActivitySubType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        public IResult Delete(int id)
        {
            var getById = GetByIdWithTransactionActivityType(id);
            if (!getById.Success)
                return new ErrorResult(getById.Message);
            TransactionActivitySubTypeDto transactionActivitySubTypeDto = getById.Data;
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            transactionActivitySubType.LicenceId = _authUserLicenceId;
            _transactionActivitySubTypeDal.Delete(transactionActivitySubType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
     
        public IResult Update(TransactionActivitySubTypeDto transactionActivitySubTypeDto)
        {
            TransactionActivitySubType transactionActivitySubType = _mapper.Map<TransactionActivitySubType>(transactionActivitySubTypeDto);
            transactionActivitySubType.LicenceId = _authUserLicenceId;
            _transactionActivitySubTypeDal.Update(transactionActivitySubType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
