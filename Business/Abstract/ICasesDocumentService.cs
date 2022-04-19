using Core.Utilities.Results;
using Entities.DTOs.CasesDocumentDtos;
using System.Collections.Generic;
namespace Business.Abstract
{
    public interface ICasesDocumentService
    {
        IDataResult<List<CasesDocumentGetDto>> GetAll();
        IDataResult<CasesDocumentGetDto> GetById(int id);
        IResult Add(CasesDocumentAddDto casesDocumentAddDto);
        IResult Update(CasesDocumentUpdateDto casesDocumentUpdateDto);
        IResult Delete(int id);
        IDataResult<int> GetCountByLicenceId(int licenceId);
        IDataResult<List<CasesDocumentGetDto>> GetAllByLicenceId(int licenceId);
    }
}
