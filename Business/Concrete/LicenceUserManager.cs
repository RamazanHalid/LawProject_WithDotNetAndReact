using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.LicenceUser;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class LicenceUserManager : ILicenceUserService
    {
        private readonly ILicenceUserDal _licenceUserDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public LicenceUserManager(ILicenceUserDal licenceUserDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _licenceUserDal = licenceUserDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        //Adding new user to current licence as an user
        //Authority needed
        [SecuredOperation("LicenceUserAdd")]
        public IResult Add(LicenceUserAddDto licenceUserAddDto)
        {
            LicenceUser licenceUser = _mapper.Map<LicenceUser>(licenceUserAddDto);
            licenceUser.LicenceId = _currentUserService.GetLicenceId();
            licenceUser.StartDate = DateTime.Now;
            _licenceUserDal.Add(licenceUser);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        //Get all users belogs to current licence
        //Authory needed
        [SecuredOperation("LicenceUserGetAll")]
        public IDataResult<List<LicenceUserGetDto>> GetAll()
        {
            List<LicenceUser> licenceUsers = _licenceUserDal
                .GetAllInclude(l => l.LicenceId == _currentUserService.GetLicenceId());
            List<LicenceUserGetDto> licenceUserGetDtos = _mapper.Map<List<LicenceUserGetDto>>(licenceUsers);
            return new SuccessDataResult<List<LicenceUserGetDto>>(licenceUserGetDtos, Messages.GetAllSuccessfuly);
        }
        //Get user belogs to current licence
        //Authory needed
        [SecuredOperation("LicenceUserGet")]
        public IDataResult<LicenceUserGetDto> GetById(int id)
        {
            LicenceUser licenceUser = _licenceUserDal.GetInclude(lu => lu.LicenceUserId == id);
            LicenceUserGetDto licenceUserGetDto = _mapper.Map<LicenceUserGetDto>(licenceUser);
            return new SuccessDataResult<LicenceUserGetDto>(licenceUserGetDto, Messages.GetByIdSuccessfuly);
        }
        //Update user belogs to current licence
        //Authory needed
        [SecuredOperation("LicenceUserUpdate")]
        public IResult Update(LicenceUserUpdateDto licenceUserUpdateDto)
        {
            LicenceUser licenceUser = _licenceUserDal.Get(lu => lu.LicenceUserId == licenceUserUpdateDto.LicenceUserId);
            if (licenceUser == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            licenceUser.IsActive = licenceUserUpdateDto.IsActive;
            licenceUser.EndDate = licenceUserUpdateDto.EndDate;
            _licenceUserDal.Update(licenceUser);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IDataResult<List<LicenceUserGetDto>> GetAllByUserId(int userId)
        {
            var licenceUsers = _licenceUserDal.GetAllInclude(lu => lu.UserId == userId);
            List<LicenceUserGetDto> licenceUserGetDto = _mapper.Map<List<LicenceUserGetDto>>(licenceUsers);
            return new SuccessDataResult<List<LicenceUserGetDto>>(licenceUserGetDto, Messages.GetAllSuccessfuly);
        }
        public IDataResult<List<LicenceUserGetDto>> GetByLicenceId(int licenceId)
        {
            var licenceUsers = _licenceUserDal.GetAllInclude(lu => lu.UserId == _currentUserService.GetLicenceId());
            List<LicenceUserGetDto> licenceUserGetDto = _mapper.Map<List<LicenceUserGetDto>>(_licenceUserDal);
            return new SuccessDataResult<List<LicenceUserGetDto>>(licenceUserGetDto, Messages.GetAllSuccessfuly);
        }
    }
}
