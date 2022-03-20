using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPersonTypeService
    {
        IDataResult<List<PersonType>> GetAll();
        IDataResult<PersonType> GetById(int id);
    }
}
