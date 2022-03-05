using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CourtOfficeType;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CourtOfficeTypeManager : ICourtOfficeTypeService
    {
        private ICourtOfficeTypeDal _courtOfficeTypeDal;
        private readonly IMapper _mapper;
        public CourtOfficeTypeManager(ICourtOfficeTypeDal courtOfficeTypeDal, IMapper mapper)
        {
            _courtOfficeTypeDal = courtOfficeTypeDal;
            _mapper = mapper;
        }
        public IResult Add(CourtOfficeTypeAddDto courtOfficeTypeAddDto)
        {
            CourtOfficeType courtOfficeType = _mapper.Map<CourtOfficeType>(courtOfficeTypeAddDto);
            _courtOfficeTypeDal.Add(courtOfficeType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<CourtOfficeTypeGetDto>> GetAll()
        {
            List<CourtOfficeType> courtOfficeTypes = _courtOfficeTypeDal.GetAll();
            List<CourtOfficeTypeGetDto> courtOfficeTypeGetDtos = _mapper.Map<List<CourtOfficeTypeGetDto>>(courtOfficeTypes);
            return new SuccessDataResult<List<CourtOfficeTypeGetDto>>(courtOfficeTypeGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<CourtOfficeTypeGetDto> GetById(int id)
        {
            var courtOfficeType = _courtOfficeTypeDal.Get(c => c.CourtOfficeTypeId == id);
            if (courtOfficeType == null)
                return new ErrorDataResult<CourtOfficeTypeGetDto>(Messages.TheItemDoesNotExists);
            CourtOfficeTypeGetDto courtOfficeTypeGetDto = _mapper.Map<CourtOfficeTypeGetDto>(courtOfficeType);
            return new SuccessDataResult<CourtOfficeTypeGetDto>(Messages.GetByIdSuccessfuly);
        }
        public IResult Delete(int id)
        {
            var courtOfficeType = _courtOfficeTypeDal.Get(c => c.CourtOfficeTypeId == id);
            if (courtOfficeType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _courtOfficeTypeDal.Delete(courtOfficeType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IResult Update(CourtOfficeTypeUpdateDto courtOfficeTypeUpdateDto)
        {
            CourtOfficeType courtOfficeType = _mapper.Map<CourtOfficeType>(courtOfficeTypeUpdateDto);
            _courtOfficeTypeDal.Update(courtOfficeType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult DoesItExist(int id)
        {
            var result = _courtOfficeTypeDal.Get(c => c.CourtOfficeTypeId == id);
            if (result == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            return new SuccessResult(Messages.TheItemExists);
        }
    }
}
