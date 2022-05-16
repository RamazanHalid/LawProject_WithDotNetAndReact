using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CaseUpdateHistoryDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICasesUpdateHistoryService
    {
        IDataResult<List<CaseUpdateHistoryGetDto>> GetAll(int skipVal, int takeVal, int caseId);
        IDataResult<CaseUpdateHistoryGetDto> GetById(int id);
        IResult Add(CasesUpdateHistory casesUpdateHistory);
        IDataResult<int> GetCountByLicenceId(int caseeId);
    }
}
