using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface IContactInformationService
    {
        IDataResult<List<ContactInformation>> GetAll();
        IDataResult<ContactInformation> GetById(int id);
        IResult Add(ContactInformation entity);
        IResult Delete(int id);
    }
}
