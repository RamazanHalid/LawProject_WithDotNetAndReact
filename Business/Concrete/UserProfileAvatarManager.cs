using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserProfileAvatarManager : IUserProfileAvatarService
    {
        private readonly IUserProfileAvatarDal _userProfileAvatarDal;

        public UserProfileAvatarManager(IUserProfileAvatarDal userProfileAvatarDal)
        {
            _userProfileAvatarDal = userProfileAvatarDal;
        }

        public IDataResult<List<UserProfileAvatar>> GetAll()
        {
            return new SuccessDataResult<List<UserProfileAvatar>>(_userProfileAvatarDal.GetAll());
        }
    }
}
