using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.DTOs.CustomerDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface ICustomerService
    {
        IDataResult<List<CustomerGetDto>> GetAll();
        IDataResult<List<CustomerGetDto>> GetAllActive();
        IDataResult<CustomerGetDto> GetById(int id);
        IResult Add(CustomerAddDto customerAddDto);
        IResult Update(CustomerUpdateDto customerUpdateDro);
        IResult ChangeActivity(int id);
        IDataResult<int> GetCountByLicenceId(int licenceId);
        [SecuredOperation("LicenceOwner,CustomerGetAllActive,CustomerGetAll,TaskGetAll,EventtGetAll,EventtGetAll,CaseeGetAll")]
        IDataResult<List<CustomerGetForDropDownDto>> GetAllClientsForDropDown();
    }
}
