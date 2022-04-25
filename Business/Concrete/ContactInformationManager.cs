using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ContactInformationManager : IContactInformationService
    {
        private IContactInformationDal _courtOfficeTypeDal;
        private readonly IMapper _mapper;
        public ContactInformationManager(IContactInformationDal courtOfficeTypeDal, IMapper mapper)
        {
            _courtOfficeTypeDal = courtOfficeTypeDal;
            _mapper = mapper;
        }
        
        //Create new Contact info from Contact Us part
        [ValidationAspect(typeof(ContactInfoAddDtoValidator))]
        public IResult Add(ContactInformation entity)
        {
            _courtOfficeTypeDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        //List all Contact Informartion as admin
        [SecuredOperation("admin")]
        public IDataResult<List<ContactInformation>> GetAll()
        {
            List<ContactInformation> courtOfficeTypes = _courtOfficeTypeDal.GetAll();
            return new SuccessDataResult<List<ContactInformation>>(courtOfficeTypes, Messages.GetAllSuccessfuly);
        }
        //Get special  Contact Informartion as admin
        [SecuredOperation("admin")]
        public IDataResult<ContactInformation> GetById(int id)
        {
            var contactInformation = _courtOfficeTypeDal.Get(c => c.Id == id);
            if (contactInformation == null)
                return new ErrorDataResult<ContactInformation>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<ContactInformation>(contactInformation, Messages.GetByIdSuccessfuly);
        }
        // Delete Contact Info as admin
        [SecuredOperation("admin")]
        public IResult Delete(int id)
        {
            var courtOfficeType = _courtOfficeTypeDal.Get(c => c.Id == id);
            if (courtOfficeType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _courtOfficeTypeDal.Delete(courtOfficeType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
    }
}
