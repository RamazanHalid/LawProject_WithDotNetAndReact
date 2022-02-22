using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Text;

namespace Business.Abstract
{

    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string cellPhone);
        IDataResult<AccessToken> CreateAccessToken(User user, int licenceId);

        IDataResult<User> ApprovingSelectedUser(ApprovingUserDto approvingUserDto);
        IResult ForgetPassword(string cellPhone);
        IResult UpdateUserPassword(UpdateUserPasswordDto updateUserPasswordDto);
    }
}
