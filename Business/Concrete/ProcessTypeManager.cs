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
    public class ProcessTypeManager : IProcessTypeService
    {
        private IProcessTypeDal _processTypeDal;

        public ProcessTypeManager(IProcessTypeDal processTypeDal)
        {
            _processTypeDal = processTypeDal;
        }
        public IResult Add(ProcessType processType)
        {
            _processTypeDal.Add(processType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IResult ChangeActivity(int id)
        {
            var processType = GetById(id);
            if (!processType.Success)
                return new ErrorResult(processType.Message);
            processType.Data.IsActive = !processType.Data.IsActive;
            var result = Update(processType.Data);
            if (!result.Success)
                return result;
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }
        public IResult Delete(int id)
        {
            var processType = _processTypeDal.Get(pt => pt.ProcessTypeId == id);
            _processTypeDal.Delete(processType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
        public IDataResult<List<ProcessType>> GetAllByLicenceIdAndActivity(int licenceId, int isActive)
        {
            if (isActive == 0)
                return new SuccessDataResult<List<ProcessType>>(_processTypeDal.GetAll(p => p.LicenceId == licenceId && p.IsActive == false), Messages.GetAllSuccessfuly);
            if (isActive == 0)
                return new SuccessDataResult<List<ProcessType>>(_processTypeDal.GetAll(p => p.LicenceId == licenceId && p.IsActive == true), Messages.GetAllSuccessfuly);
            return new SuccessDataResult<List<ProcessType>>(_processTypeDal.GetAll(p => p.LicenceId == licenceId), Messages.GetAllSuccessfuly);
        }
        public IDataResult<ProcessType> GetById(int id)
        {
            return new SuccessDataResult<ProcessType>(_processTypeDal.Get(pt => pt.ProcessTypeId == id), Messages.GetByIdSuccessfuly);
        }
        public IResult Update(ProcessType processType)
        {
            _processTypeDal.Update(processType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
