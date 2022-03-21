using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.AccountActivityTypeDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AccountActivityTypeManager : IAccountActivityTypeService
    {
        private IAccountActivityTypeDal _accountActivityTypeDal;
        private readonly IMapper _mapper;

        public AccountActivityTypeManager(IAccountActivityTypeDal accountActivityTypeDal, IMapper mapper)
        {
            _accountActivityTypeDal = accountActivityTypeDal;
            _mapper = mapper;
        }
        [SecuredOperation("AccountActivityTypeAdd")]
        public IResult Add(AccountActivityTypeAddDto accountActivityTypeAddDto)
        {
            AccountActivityType accountActivityType = _mapper.Map<AccountActivityType>(accountActivityTypeAddDto);
            _accountActivityTypeDal.Add(accountActivityType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        [SecuredOperation("AccountActivityTypeDelete")]
        public IResult Delete(int id)
        {
            var accountActivityType = _accountActivityTypeDal.Get(a => a.AccountActivityTypeId == id);
            if (accountActivityType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _accountActivityTypeDal.Delete(accountActivityType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        [SecuredOperation("AccountActivityTypeGetAll")]
        public IDataResult<List<AccountActivityTypeGetDto>> GetAll()
        {
            List<AccountActivityType> accountActivityTypees = _accountActivityTypeDal.GetAll();
            List<AccountActivityTypeGetDto> accountActivityTypeGetDto = _mapper.Map<List<AccountActivityTypeGetDto>>(accountActivityTypees);
            return new SuccessDataResult<List<AccountActivityTypeGetDto>>(accountActivityTypeGetDto, Messages.GetAllSuccessfuly);
        }
        [SecuredOperation("AccountActivityTypeGetAll")]
        public IDataResult<AccountActivityTypeGetDto> GetById(int id)
        {
            AccountActivityType accountActivityType = _accountActivityTypeDal.Get(t => t.AccountActivityTypeId == id);
            if (accountActivityType ==  null)
                return new ErrorDataResult<AccountActivityTypeGetDto>(Messages.TheItemDoesNotExists);
            AccountActivityTypeGetDto accountActivityTypeGetDto = _mapper.Map<AccountActivityTypeGetDto>(accountActivityType);
            return new SuccessDataResult<AccountActivityTypeGetDto>(accountActivityTypeGetDto, Messages.GetByIdSuccessfuly);
        }
        [SecuredOperation("AccountActivityTypeUpdate")]
        public IResult Update(AccountActivityTypeUpdateDto accountActivityTypeUpdateDto)
        {
            AccountActivityType accountActivityType = _mapper.Map<AccountActivityType>(accountActivityTypeUpdateDto);
            _accountActivityTypeDal.Update(accountActivityType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
