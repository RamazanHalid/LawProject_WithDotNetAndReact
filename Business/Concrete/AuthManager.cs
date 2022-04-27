using AutoMapper;
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
using Entities.DTOs.UserDtos;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly ISmsService _smsService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly ILicenceService _licenceService;
        private readonly ILicenceUserService _licenceUserService;
        private readonly IEmailService _emailService;
        public AuthManager(IUserService userService,
            ITokenHelper tokenHelper,
            ISmsService smsService,
            ICurrentUserService currentUserService,
            IMapper mapper,
            ILicenceService licenceService,
            ILicenceUserService licenceUserService, IEmailService emailService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _smsService = smsService;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _licenceService = licenceService;
            _licenceUserService = licenceUserService;
            _emailService = emailService;
        }
        [ValidationAspect(typeof(UserForRegisterValidator))]
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
                Title = userForRegisterDto.Title,
                CityId = userForRegisterDto.CityId,
                IsActive = true,
                IsCellPhoneApproved = false,
                Email = userForRegisterDto.Email,
                IsAdmin = false,
                Date = DateTime.Now,
                IsEmailApproved = false,
                SmsCode = new Random().Next(0, 1000000).ToString("D6"),
                ProfileImage = "/Uploads/UserProfileIamges/NoImage.jpg",
                ApproveGuid = Guid.NewGuid(),
            };
            _userService.Add(user);
            string smsMessage = $"Account approvement code: {user.SmsCode}.";
            _smsService.SendIndividualMessage(smsMessage, user.CellPhone);
            return new SuccessDataResult<User>(Messages.CellPhoneCode);
        }
        [ValidationAspect(typeof(LoginValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByCellPhone(userForLoginDto.CellPhone);
            if (userToCheck == null)
                return new ErrorDataResult<User>(Messages.UserDoesNotExistMessage);
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<User>(Messages.WrongPassword);
            if (!userToCheck.IsCellPhoneApproved)
            {
                string smsMessage = $"Account approvement code: {userToCheck.SmsCode}.";
                _smsService.SendIndividualMessage(smsMessage, userToCheck.CellPhone);
                throw new UnApprovedAccountException();
            }
            if (!userToCheck.IsEmailApproved)
            {
                //string emailMessage = $"Account approvement" +
                //    $" code: <a target='_blank' href='https://webapi.emlakofisimden.com/api/Auth/ApproveEmail?userId={userToCheck.Id}&approveGuid={userToCheck.ApproveGuid}'> " +
                //    $"Click here for approve your account </a>";

                string emailMessage = $"Account approvement" +
                    $" code: <a target='_blank' href='https://webapi.emlakofisimden.com/api/Auth/ApproveEmail?userId={userToCheck.Id}&approveGuid={userToCheck.ApproveGuid}'> " +
                    $"Click here for approve your account </a>";


                _emailService.Send(new Entities.EmailContent
                {
                    Message = emailMessage,
                    Subject = "Approve Email",
                    To = userToCheck.Email
                });
                return new ErrorDataResult<User>("Your have Approve your email! Check your emails!");
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
        public IDataResult<LoginSuccessDto> CreateAccessToken(User user, int licenceId)
        {
            var claims = _userService.GetClaims(user, licenceId);
            var accessToken = _tokenHelper.CreateToken(user, claims, licenceId);
            List<string> operationClaims = new List<string>();
            foreach (var operationClaim in claims)
                operationClaims.Add(operationClaim.Name);
            LoginSuccessDto loginSuccessDto = new LoginSuccessDto()
            {
                AccessToken = accessToken,
                OperationClaims = operationClaims
            };
            return new SuccessDataResult<LoginSuccessDto>(loginSuccessDto, Messages.TokenCreated);
        }
        public IDataResult<User> ApprovingSelectedUser(ApprovingUserDto approvingUserDto)
        {
            var isUserExists = UserExists(approvingUserDto.CellPhone);
            if (!isUserExists.Success)
                return new ErrorDataResult<User>(isUserExists.Message);
            var user = _userService.GetByCellPhone(approvingUserDto.CellPhone);
            if (user.SmsCode != approvingUserDto.SmsCode)
                return new ErrorDataResult<User>(Messages.WrongSmsCode);

            user.IsCellPhoneApproved = true;
            _userService.Update(user);
            return new SuccessDataResult<User>(Messages.AccountApproved);
        }
        public IDataResult<User> ApprovingSelectedUserEmail(int userId, Guid approveGuid)
        {
            var isUserExists = _userService.GetByUserId(userId);
            if (isUserExists == null)
                return new ErrorDataResult<User>("User not found");
            var user = isUserExists;
            if (user.ApproveGuid != approveGuid)
                return new ErrorDataResult<User>(Messages.WrongSmsCode);

            user.IsEmailApproved = true;
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
        public IDataResult<int> UserAfterLogin(int userId)
        {
            return new SuccessDataResult<int>(userId);
        }
        public IResult UpdateUser(UpdateUserDto updateUserDto)
        {
            User user = _userService.GetByUserId(_currentUserService.GetUserId());
            user.CityId = updateUserDto.CityId;
            user.Title = updateUserDto.Title;
            user.LastName = updateUserDto.LastName;
            user.CountryId = updateUserDto.CountryId;
            user.FirstName = updateUserDto.FirstName;
            if (!string.IsNullOrEmpty(user.ProfileImage))
                user.ProfileImage = updateUserDto.ProfileImage;
            _userService.Update(user);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IDataResult<GetUserInfoDto> GetUserInfo()
        {
            GetUserInfoDto userInfo = _userService.GetUserInfoByUserId(_currentUserService.GetUserId());
            return new SuccessDataResult<GetUserInfoDto>(userInfo);
        }

        public IResult CheckLicenceExistance(int userId, int licenceId)
        {
            var result = _licenceUserService.CheckLicenceBelongToUser(userId, licenceId).Success || _licenceService.CheckLicenceBelongToUser(userId, licenceId).Success;
            if (result)
                return new SuccessResult("This user can use this licence");
            return new ErrorResult("This user can not use this licence");
        }
    }
}
