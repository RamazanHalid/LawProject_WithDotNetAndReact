using Core.Utilities.Results;
using Entities.DTOs.CaseStatusDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICaseStatusService
    {
        IDataResult<List<CaseStatusGetDto>> GetAll();
        IDataResult<List<CaseStatusGetDto>> GetAllActive();
        IDataResult<CaseStatusGetDto> GetById(int id);
        IResult Add(CaseStatusAddDto caseStatusAddDto);
        IResult Update(CaseStatusUpdateDto caseStatusUpdateDto);
        IResult Delete(int id);
        IResult ChangeActivity(int id);

    }
}
