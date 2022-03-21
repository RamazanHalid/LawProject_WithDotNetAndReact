using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.UserDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        private readonly ILicenceUserService _licenceUserService;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, ILicenceUserService licenceUserService, IMapper mapper)
        {
            _userDal = userDal;
            _licenceUserService = licenceUserService;
            _mapper = mapper;
        }

        public List<OperationClaim> GetClaims(User user, int licenceId)
        {
            return _userDal.GetClaims(user, licenceId);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByCellPhone(string cellPhone)
        {
            return _userDal.Get(u => u.CellPhone == cellPhone);
        }
        public GetUserInfoDto GetUserInfoByUserId(int userId)
        {
            return _userDal.GetWithInclude(userId);
        }
        public User GetByUserId(int userId)
        {
            return _userDal.Get(u => u.Id == userId);
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
        public IDataResult<List<UserForAddAnOtherLicenceInfo>> GetAllUsersForAddingOtherLicence()
        {
            var idsResult = _licenceUserService.GetAllUserIdsRecordedUser();
            if (!idsResult.Success)
            {
                return new ErrorDataResult<List<UserForAddAnOtherLicenceInfo>>(idsResult.Message);
            }
            List<User> users = _userDal.ListAllUserExceptSomeIds(idsResult.Data);
            if (users == null)
                return new ErrorDataResult<List<UserForAddAnOtherLicenceInfo>>(Messages.TheItemDoesNotExists);
            List<UserForAddAnOtherLicenceInfo> UserForAddAnOtherLicenceInfo = _mapper.Map<List<UserForAddAnOtherLicenceInfo>>(users);
            return new SuccessDataResult<List<UserForAddAnOtherLicenceInfo>>(UserForAddAnOtherLicenceInfo, Messages.GetAllSuccessfuly);
        }
    }
}
