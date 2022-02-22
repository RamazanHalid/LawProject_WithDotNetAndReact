using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.CustomExceptions;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Security.Claims;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly ISmsService _smsService;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ISmsService smsService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _smsService = smsService;
        }
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                CellPhone = userForRegisterDto.CellPhone,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                TitleTr = userForRegisterDto.TitleTr,
                TitleEn = userForRegisterDto.TitleEn,
                IsActive = true,
                IsApproved = false,
                SmsCode = new Random().Next(0, 1000000).ToString("D6"),
                ProfileImage = ""
            };
            _userService.Add(user);
            string smsMessage = $"Account approvement code: {user.SmsCode}.";
            _smsService.SendIndividualMessage(smsMessage, user.CellPhone);
            return new SuccessDataResult<User>(Messages.CellPhoneCode);
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByCellPhone(userForLoginDto.CellPhone);
            if (userToCheck == null)
                return new ErrorDataResult<User>(Messages.UserDoesNotExistMessage);
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<User>(Messages.WrongPassword);
            if (!userToCheck.IsApproved)
            {
                string smsMessage = $"Account approvement code: {userToCheck.SmsCode}.";
                _smsService.SendIndividualMessage(smsMessage, userToCheck.CellPhone);
                throw new UnApprovedAccountException();
            }
            if (!userToCheck.IsActive)
                return new ErrorDataResult<User>(Messages.UnactivceAccount);
            return new SuccessDataResult<User>(userToCheck, Messages.LoginSuccessSelectLicence);
        }
        public IResult UserExists(string cellPhone)
        {
            if (_userService.GetByCellPhone(cellPhone) != null)
                return new SuccessResult(Messages.TheItemExists);
            return new ErrorResult(Messages.TheItemDoesNotExists);
        }
        public IDataResult<AccessToken> CreateAccessToken(User user, int licenceId)
        {
            var claims = _userService.GetClaims(user, licenceId);
            var accessToken = _tokenHelper.CreateToken(user, claims, licenceId);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }
        public IDataResult<User> ApprovingSelectedUser(ApprovingUserDto approvingUserDto)
        {
            var isUserExists = UserExists(approvingUserDto.CellPhone);
            if (!isUserExists.Success)
                return new ErrorDataResult<User>(isUserExists.Message);
            var user = _userService.GetByCellPhone(approvingUserDto.CellPhone);
            if (user.SmsCode != approvingUserDto.SmsCode)
                return new ErrorDataResult<User>(Messages.WrongSmsCode);

            user.IsApproved = true;
            _userService.Update(user);
            return new SuccessDataResult<User>(Messages.AccountApproved);
        }
        public IResult UpdateUserPassword(UpdateUserPasswordDto updateUserPasswordDto)
        {
            var isUserExists = UserExists(updateUserPasswordDto.CellPhone);
            if (!isUserExists.Success)
                return new ErrorResult(isUserExists.Message);
            var user = _userService.GetByCellPhone(updateUserPasswordDto.CellPhone);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(updateUserPasswordDto.NewPassword, out passwordHash, out passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _userService.Update(user);
            return new SuccessResult(Messages.PasswordChangedSuccessfuly);
        }
        public IResult ForgetPassword(string cellPhone)
        {
            var isUserExists = UserExists(cellPhone);
            if (!isUserExists.Success)
                return new ErrorResult(isUserExists.Message);
            var user = _userService.GetByCellPhone(cellPhone);
            string smsCode = new Random().Next(0, 1000000).ToString("D6");
            string smsMessage = $"Account approvement code: {smsCode}.";
            user.SmsCode = smsCode;
            _userService.Update(user);
            _smsService.SendIndividualMessage(smsMessage, cellPhone);
            return new SuccessResult(Messages.SmsSended);
        }
    }
}
