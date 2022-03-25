using Core.Utilities.Results;
using Entities.DTOs.RoleTypeDtos;
using System.Collections.Generic;

namespace Business.Abstract
{

    public interface IRoleTypeService
    {
        IDataResult<List<RoleTypeGetDto>> GetAllByCourtOfficeTypeId(int courtOfficeTypeId);
        IDataResult<RoleTypeGetDto> GetById(int id);
        IResult Add(RoleTypeAddDto RoleTypeAddDto);
        IResult Update(RoleTypeUpdateDto RoleTypeUpdateDto);
        IResult Delete(int id);
    }
}
