using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CaseIngonereUserDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICaseIgnoreUserService
    {
        IResult AddWithRange(List<CaseIgnoreUserAddDto> caseIgnoreUserAddDtos);
        IResult DeleteAndAdd(List<CaseIgnoreUserAddDto> caseIgnoreUserAddDtos);
        IResult DeleteByCaseeId(int caseId, int licenceId);
        IResult DeleteWithRange(List<int> caseIgnoreUserIds);
        IDataResult<List<CaseIgnoreGetDto>> GetAllByCaseeId(int caseeId);
        IDataResult<List<CaseIgnoreUser>> GetAllByUserId(int userId);
        IDataResult<List<int>> GetAllCaseIdsByUserId(int userId);
    }
}
