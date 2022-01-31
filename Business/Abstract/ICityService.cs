using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{

    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IResult Add(City city);
    }
}
