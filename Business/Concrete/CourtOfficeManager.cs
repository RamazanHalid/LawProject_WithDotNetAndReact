using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CourtOfficeManager : ICourtOfficeService
    {
        private readonly ICourtOfficeDal _courtOfficeDal;

        public CourtOfficeManager(ICourtOfficeDal courtOfficeDal)
        {
            _courtOfficeDal = courtOfficeDal;
        }

        public IResult Add(CourtOffice courtOffice)
        {
            _courtOfficeDal.Add(courtOffice);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CourtOffice>> GetAll(int courtOfficeTypeId, int isActive)
        {
            List<CourtOffice> courtOffices;
            if (isActive == 0)
            {
                courtOffices = _courtOfficeDal.GetAll(
                    c => c.IsActive == false
                    && courtOfficeTypeId > 0 ? c.CourtOfficeTypeId == courtOfficeTypeId : true);
            }
            else if (isActive == 1)
            {
                courtOffices = _courtOfficeDal.GetAll(
                    c => c.IsActive == true
                    && courtOfficeTypeId > 0 ? c.CourtOfficeTypeId == courtOfficeTypeId : true);
            }
            else
            {
                courtOffices = _courtOfficeDal.GetAll(
                  c => courtOfficeTypeId > 0 ? c.CourtOfficeTypeId == courtOfficeTypeId : true);
            }
            return new SuccessDataResult<List<CourtOffice>>(courtOffices, Messages.GetAllSuccessfuly);
        }
        public IDataResult<CourtOffice> GetById(int id)
        {
            return new SuccessDataResult<CourtOffice>(_courtOfficeDal.Get(c => c.CourtOfficeId == id));
        }

        public IResult Update(CourtOffice courtOffice)
        {
            _courtOfficeDal.Update(courtOffice);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
