using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
namespace Business.Concrete
{
    public class PersonTypeManager : IPersonTypeService
    {
        private readonly IPersonTypeDal _processTypeDal;
         public PersonTypeManager(IPersonTypeDal processTypeDal )
        {
            _processTypeDal = processTypeDal;
           
        }
         public IDataResult<List<PersonType>> GetAll()
        {
            List<PersonType> processTypes = _processTypeDal.GetAll();
            return new SuccessDataResult<List<PersonType>>(processTypes, Messages.GetAllByLicenceIdSuccessfuly);
        }
        public IDataResult<PersonType> GetById(int id)
        {
            PersonType processType = _processTypeDal.Get(pt => pt.PersonTypeId == id);
            return new SuccessDataResult<PersonType>(processType, Messages.GetByIdSuccessfuly);
        }
     
 
    }
}
