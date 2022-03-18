using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IDataResult<List<Country>> GetAll();
        IDataResult<Country> GetById(int id);
        IResult Add(Country country);
        IResult Update(Country country);
        IResult Delete(int id);

    }
}
