using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CourtOfficeTypeManager : ICourtOfficeTypeService
    {
        private ICourtOfficeTypeDal _courtOfficeTypeDal;

        public CourtOfficeTypeManager(ICourtOfficeTypeDal courtOfficeTypeDal)
        {
            _courtOfficeTypeDal = courtOfficeTypeDal;
        }

        public IResult Add(CourtOfficeType courtOfficeType)
        {
            _courtOfficeTypeDal.Add(courtOfficeType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var courtOfficeType = _courtOfficeTypeDal.Get(c => c.CourtOfficeTypeId == id);
            if (courtOfficeType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _courtOfficeTypeDal.Delete(courtOfficeType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<CourtOfficeType>> GetAll()
        {
            return new SuccessDataResult<List<CourtOfficeType>>(_courtOfficeTypeDal.GetAll(), Messages.GetAllSuccessfuly);
        }

        public IDataResult<CourtOfficeType> GetById(int id)
        {
            var courtOfficeType = _courtOfficeTypeDal.Get(c => c.CourtOfficeTypeId == id);
            if (courtOfficeType == null)
                return new ErrorDataResult<CourtOfficeType>(null, Messages.TheItemDoesNotExists);
            return new SuccessDataResult<CourtOfficeType>(Messages.GetByIdSuccessfuly);
        }

        public IResult Update(CourtOfficeType courtOfficeType)
        {
            _courtOfficeTypeDal.Update(courtOfficeType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult IsCourtOfficeTypeExists(int id)
        {
            var result = _courtOfficeTypeDal.Get(c => c.CourtOfficeTypeId == id);
            if (result == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            return new SuccessResult(Messages.TheItemExists);
        }
    }
}
