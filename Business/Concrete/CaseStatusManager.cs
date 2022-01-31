using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CaseStatusManager : ICaseStatusService
    {
        private ICaseStatusDal _caseStatusDal;

        public CaseStatusManager(ICaseStatusDal caseStatusDal)
        {
            _caseStatusDal = caseStatusDal;
        }

        public IResult Add(CaseStatus caseStatus)
        {
            _caseStatusDal.Add(caseStatus);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var caseStatus = _caseStatusDal.Get(cs => cs.CaseStatusId == id);
            if (caseStatus == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _caseStatusDal.Delete(caseStatus);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<CaseStatus>> GetAll()
        {
            return new SuccessDataResult<List<CaseStatus>>(_caseStatusDal.GetAllWithCourtOfficeType(), Messages.GetAllSuccessfuly);
        }
        public IDataResult<CaseStatus> GetById(int id)
        {
            var caseStatus = _caseStatusDal.GetByIdWithCourtOfficeType(cs => cs.CaseStatusId == id);
            if (caseStatus == null)
                return new ErrorDataResult<CaseStatus>(null, Messages.TheItemDoesNotExists);
            return new SuccessDataResult<CaseStatus>(caseStatus, Messages.GetByIdSuccessfuly);
        }
        public IResult Update(CaseStatus caseStatus)
        {
            _caseStatusDal.Update(caseStatus);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
