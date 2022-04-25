using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CustomerDtos;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly ICurrentUserService _authenticatedUserInfoService;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDal customerDal, IMapper mapper, ICurrentUserService authenticatedUserInfoService)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _authenticatedUserInfoService = authenticatedUserInfoService;
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CustomerAdd")]
        [ValidationAspect(typeof(CustomerAddDtoValidator))]
         public IResult Add(CustomerAddDto customerAddDto)
        {
            Customer customer = _mapper.Map<Customer>(customerAddDto);
            customer.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CustomerUpdate")]
        public IResult ChangeActivity(int id)
        {
            var customer = _customerDal.Get(c => c.CustomerId == id);
            if (customer == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            customer.IsActive = !customer.IsActive;
            _customerDal.Update(customer);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CustomerDelete")]
        public IResult Delete(int id)
        {
            var customer = _customerDal.Get(cs => cs.CustomerId == id);
            if (customer == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CustomerGetAll")]
        public IDataResult<List<CustomerGetDto>> GetAll()
        {
            List<Customer> customeres = _customerDal.GetAllWithInclude(c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId());
            List<CustomerGetDto> customerDtos = _mapper.Map<List<CustomerGetDto>>(customeres);
            return new SuccessDataResult<List<CustomerGetDto>>(customerDtos, Messages.GetAllSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CustomerGetAllActive")]
        public IDataResult<List<CustomerGetDto>> GetAllActive()
        {
            List<Customer> customeres = _customerDal.GetAllWithInclude(
                c => c.LicenceId == _authenticatedUserInfoService.GetLicenceId() && c.IsActive == true);
            List<CustomerGetDto> customerDtos = _mapper.Map<List<CustomerGetDto>>(customeres);
            return new SuccessDataResult<List<CustomerGetDto>>(customerDtos, Messages.GetAllSuccessfuly);
        }
        //Needed to authority as a lawyer or licence owner.
        [SecuredOperation("LicenceOwner,CustomerGetAll")]
        public IDataResult<CustomerGetDto> GetById(int id)
        {
            var customer = _customerDal.GetByIdWithInclude(cs => cs.CustomerId == id);
            CustomerGetDto customerDto = _mapper.Map<CustomerGetDto>(customer);
            if (customer == null)
                return new ErrorDataResult<CustomerGetDto>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<CustomerGetDto>(customerDto, Messages.GetByIdSuccessfuly);
        }
        //Update the customer informartions
        [SecuredOperation("LicenceOwner,CustomerUpdate")]
        [ValidationAspect(typeof(CustomerUpdateDtoValidator))]
        public IResult Update(CustomerUpdateDto customerUpdateDto)
        {
            Customer customer = _mapper.Map<Customer>(customerUpdateDto);
            customer.LicenceId = _authenticatedUserInfoService.GetLicenceId();
            _customerDal.Update(customer);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }

        //Get count of Customer who belongs to selected licence id 
        [SecuredOperation("LicenceOwner,admin")]
        public IDataResult<int> GetCountByLicenceId(int licenceId)
        {
            var countObj = _customerDal.GetCount(cs => cs.LicenceId == licenceId);
            return new SuccessDataResult<int>(countObj, Messages.GetCountSuccessfuly);
        }
    }
}
