using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface ICityService
    {
        IDataResult<List<City>> GetAll(int countryId);
        IResult Add(City city);
    }
}
