using AutoMapper;
using Business.Abstract;
using Business.Constants;
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
        public IResult Add(ContactInformation entity)
        {
            _courtOfficeTypeDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<ContactInformation>> GetAll()
        {
            List<ContactInformation> courtOfficeTypes = _courtOfficeTypeDal.GetAll();
            return new SuccessDataResult<List<ContactInformation>>(courtOfficeTypes, Messages.GetAllSuccessfuly);
        }
        public IDataResult<ContactInformation> GetById(int id)
        {
            var contactInformation = _courtOfficeTypeDal.Get(c => c.Id == id);
            if (contactInformation == null)
                return new ErrorDataResult<ContactInformation>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<ContactInformation>(contactInformation, Messages.GetByIdSuccessfuly);
        }
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
