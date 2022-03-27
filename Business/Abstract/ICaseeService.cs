using Core.Utilities.Results;
using Entities.DTOs.CaseeDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICaseeService
    {
        IDataResult<List<CaseeGetDto>> GetAll();
        IDataResult<List<CaseeGetDto>> GetAllByCustomerId(int customerId);
        IDataResult<CaseeGetDto> GetById(int id);
        IResult Add(CaseeAddDto caseeDto);
        IResult Update(CaseeUpdateDto caseeDto);
        IResult Delete(int id);
        IResult ChangeStatus(int id, int caseStatusId);
    }
}
