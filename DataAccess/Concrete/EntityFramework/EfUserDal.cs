using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HukukContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user, int licenceId)
        {
            using (var context = new HukukContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id && userOperationClaim.LicenceId == licenceId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
        public List<User> ListAllUserExceptSomeIds(List<int> exceptIsers)
        {
            using (var context = new HukukContext())
            {
                var result = context.Set<User>().Where(x => !exceptIsers.Contains(x.Id));
                return result.ToList();
            }
        }

        public User AddWithReturn(User user)
        {

            using (var context = new HukukContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user;    
            }

        }

        public GetUserInfoDto GetWithInclude(int id)
        {
            using (var context = new HukukContext())
            {
                var result = from user in context.Users
                             join city in context.Cities
                             on user.CityId equals city.CityId
                             join country in context.Countries
                             on city.CountryId equals country.CountryId
                             join profileAvatar in context.UserProfileAvatars on user.UserProfileAvatarId equals profileAvatar.UserProfileAvatarId

                             where user.Id == id
                             select new GetUserInfoDto
                             {
                                 City = city,
                                 Country = country,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 ProfileImage = profileAvatar.ProfileAvatarPath,
                                 Title = user.Title,
                                 CellPhone = user.CellPhone,
                                 Date = user.Date,
                                 Email = user.Email
                             };
                //on country.CountryId equals city.CountryId  
                return result.FirstOrDefault();

            }

        }
        public List<GetUserInfoAsAdminDto> GetAllAsAdmin(int pageNumber, int pageSize, UserFilterAsAdmin userFilterAsAdmin)
        {
            using (var context = new HukukContext())
            {
                var result = from user in context.Users
                             join city in context.Cities
                             on user.CityId equals city.CityId
                             join country in context.Countries
                             on city.CountryId equals country.CountryId
                             join profileAvatar in context.UserProfileAvatars on user.UserProfileAvatarId equals profileAvatar.UserProfileAvatarId

                             select new GetUserInfoAsAdminDto
                             {
                                 Id = user.Id,
                                 City = city.CityName,
                                 Country = country.CountryName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 ProfileImage = profileAvatar.ProfileAvatarPath,
                                 CellPhone = user.CellPhone,
                                 Date = user.Date,
                                 Email = user.Email,
                                 IsActive = user.IsActive
                             };
                if (userFilterAsAdmin.IsActive == 0 || userFilterAsAdmin.IsActive == 1)
                    result.Where(c => c.IsActive == Convert.ToBoolean(userFilterAsAdmin.IsActive));
                if (userFilterAsAdmin.CellPhone.Length > 0)
                    result.Where(c => c.CellPhone.StartsWith(userFilterAsAdmin.CellPhone));
                if (userFilterAsAdmin.Email.Length > 0)
                    result.Where(c => c.Email.StartsWith(userFilterAsAdmin.Email));
                if (userFilterAsAdmin.FirstName.Length > 0)
                    result.Where(c => c.FirstName.StartsWith(userFilterAsAdmin.FirstName));
                if (userFilterAsAdmin.LastName.Length > 0)
                    result.Where(c => c.LastName.StartsWith(userFilterAsAdmin.LastName));
                result.Skip(pageSize * pageNumber).Take(pageSize);
                result.OrderBy(c => c.Date);
                return result.ToList();

            }
        }
        public GetUserDetailsAsAdmin GetUserDetailsAsAdmin(int id)
        {
            using (var context = new HukukContext())
            {
                var result = from user in context.Users
                             join city in context.Cities
                             on user.CityId equals city.CityId
                             join country in context.Countries
                             on city.CountryId equals country.CountryId
                             join profileAvatar in context.UserProfileAvatars on user.UserProfileAvatarId equals profileAvatar.UserProfileAvatarId

                             where user.Id == id
                             select new GetUserDetailsAsAdmin
                             {
                                 City = city,
                                 Country = country,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 ProfileImage = profileAvatar.ProfileAvatarPath,
                                 CellPhone = user.CellPhone,
                                 Date = user.Date,
                                 Email = user.Email,
                                 IsActive = user.IsActive,
                                 Id = user.Id,
                                 IsCellPhoneApproved = user.IsCellPhoneApproved,
                                 IsEmailApproved = user.IsEmailApproved,
                                 Title = user.Title
                             };


                return result.FirstOrDefault();

            }
        }
    }
}
