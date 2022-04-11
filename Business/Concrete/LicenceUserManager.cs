using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.LicenceUserDtos;
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
        //[SecuredOperation("LicenceUserGet")]
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
        public IDataResult<List<LicenceUserGetDto>> GetAllAcceptByUserId(int userId)
        {
            var licenceUsers = _licenceUserDal.GetAllInclude(lu => lu.UserId == userId && lu.IsUserAccept == true);
            List<LicenceUserGetDto> licenceUserGetDto = _mapper.Map<List<LicenceUserGetDto>>(licenceUsers);
            return new SuccessDataResult<List<LicenceUserGetDto>>(licenceUserGetDto, Messages.GetAllSuccessfuly);
        }
        public IDataResult<List<LicenceUserGetDto>> GetAllByUserId()
        {
            var licenceUsers = _licenceUserDal.GetAllInclude(lu => lu.UserId == _currentUserService.GetUserId());
            List<LicenceUserGetDto> licenceUserGetDto = _mapper.Map<List<LicenceUserGetDto>>(licenceUsers);
            return new SuccessDataResult<List<LicenceUserGetDto>>(licenceUserGetDto, Messages.GetAllSuccessfuly);
        }
        public IDataResult<List<LicenceUserGetDto>> GetByLicenceId(int licenceId)
        {
            var licenceUsers = _licenceUserDal.GetAllInclude(lu => lu.UserId == _currentUserService.GetLicenceId());
            List<LicenceUserGetDto> licenceUserGetDto = _mapper.Map<List<LicenceUserGetDto>>(_licenceUserDal);
            return new SuccessDataResult<List<LicenceUserGetDto>>(licenceUserGetDto, Messages.GetAllSuccessfuly);
        }

        public IDataResult<List<int>> GetAllUserIdsRecordedUser()
        {
            return new SuccessDataResult<List<int>>(_licenceUserDal.GetAllUserIdByLicenceId(_currentUserService.GetLicenceId()), Messages.GetAllSuccessfuly);
        }
        public IResult ChangeAcceptence(int id)
        {
            var licenceUser = _licenceUserDal.Get(ct => ct.LicenceUserId == id);
            licenceUser.IsUserAccept = !licenceUser.IsUserAccept;
            _licenceUserDal.Update(licenceUser);
            return new SuccessResult(Messages.ActivityChangedSuccessfuly);
        }
        public IResult CheckLicenceBelongToUser(int userId, int licenceId)
        {
            bool doesItExist = _licenceUserDal.DoesItExist(l => l.UserId == userId && l.LicenceId == licenceId);
            if (doesItExist)
                return new SuccessResult(Messages.TheItemExists);
            return new ErrorResult(Messages.TheItemDoesNotExists);
        }
        public IDataResult<int> GetCountByLicenceId(int licenceId)
        {
            var countObj = _licenceUserDal.GetCount(cs => cs.LicenceId == licenceId);
            return new SuccessDataResult<int>(countObj, Messages.GetCountSuccessfuly);
        }
    }
}
