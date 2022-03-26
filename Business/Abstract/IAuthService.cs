using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using Entities.DTOs.UserDtos;

namespace Business.Abstract
{

    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string cellPhone);
        IDataResult<LoginSuccessDto> CreateAccessToken(User user, int licenceId);
        IDataResult<User> ApprovingSelectedUser(ApprovingUserDto approvingUserDto);
        IResult ForgetPassword(string cellPhone);
        IResult UpdateUserPassword(UpdateUserPasswordDto updateUserPasswordDto);
        IDataResult<int> UserAfterLogin(int userId);
        IResult UpdateUser(UpdateUserDto updateUserDto);
        IDataResult<GetUserInfoDto> GetUserInfo();
        IResult CheckLicenceExistance(int userId, int licenceId);
    }
}
