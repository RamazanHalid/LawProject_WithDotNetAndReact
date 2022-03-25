using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.RoleTypeDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RoleTypeManager : IRoleTypeService
    {
        private IRoleTypeDal _roleTypeDal;
        private readonly IMapper _mapper;
        public RoleTypeManager(IRoleTypeDal roleTypeDal, IMapper mapper)
        {
            _roleTypeDal = roleTypeDal;
            _mapper = mapper;
        }
        public IResult Add(RoleTypeAddDto roleTypeAddDto)
        {
            RoleType roleType = _mapper.Map<RoleType>(roleTypeAddDto);
            _roleTypeDal.Add(roleType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<RoleTypeGetDto>> GetAllByCourtOfficeTypeId(int courtOfficeTypeId)
        {
            List<RoleType> roleTypes = _roleTypeDal.GetAllWithInclude(i => i.CourtOfficeTypeId == courtOfficeTypeId);
            List<RoleTypeGetDto> roleTypeGetDtos = _mapper.Map<List<RoleTypeGetDto>>(roleTypes);
            return new SuccessDataResult<List<RoleTypeGetDto>>(roleTypeGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<RoleTypeGetDto> GetById(int id)
        {
            var roleType = _roleTypeDal.GetWithInclude(c => c.RoleTypeId == id);
            if (roleType == null)
                return new ErrorDataResult<RoleTypeGetDto>(Messages.TheItemDoesNotExists);
            RoleTypeGetDto roleTypeGetDto = _mapper.Map<RoleTypeGetDto>(roleType);
            return new SuccessDataResult<RoleTypeGetDto>(Messages.GetByIdSuccessfuly);
        }
        public IResult Delete(int id)
        {
            var roleType = _roleTypeDal.Get(c => c.RoleTypeId == id);
            if (roleType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _roleTypeDal.Delete(roleType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IResult Update(RoleTypeUpdateDto roleTypeUpdateDto)
        {
            RoleType roleType = _mapper.Map<RoleType>(roleTypeUpdateDto);
            _roleTypeDal.Update(roleType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult DoesItExist(int id)
        {
            var result = _roleTypeDal.Get(c => c.RoleTypeId == id);
            if (result == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            return new SuccessResult(Messages.TheItemExists);
        }
    }
}
