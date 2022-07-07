using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.DTOs.CourtOfficeDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICourtOfficeService
    {
        IDataResult<List<CourtOfficeGetDto>> GetAll();
        IDataResult<List<CourtOfficeGetDto>> GetAllActive();
        IDataResult<CourtOfficeGetDto> GetById(int id);
        IResult Add(CourtOfficeAddDto courtOfficeAddDto);
        IResult Update(CourtOfficeUpdateDto courtOfficeUpdateDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);
        [SecuredOperation("LicenceOwner,CourtOfficeGetAll,CustomerGetAll,TaskGetAll,EventtGetAll,EventtGetAll,CaseeGetAll")]
        IDataResult<List<CourtOfficeGetForDropDownDto>> GetAllCourtOfficesForDropDown();
    }
}
