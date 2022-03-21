using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }
        public IResult Add(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll(), Messages.GetAllSuccessfuly);
        }
        public IDataResult<Country> GetById(int id)
        {
            var country = _countryDal.Get(c => c.CountryId == id);
            if (country == null)
                return new ErrorDataResult<Country>(Messages.TheItemDoesNotExists);
            return new SuccessDataResult<Country>(country, Messages.GetByIdSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var getCountry = GetById(id);
            if (!getCountry.Success)
                return new ErrorResult(getCountry.Message);
            _countryDal.Delete(getCountry.Data);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
