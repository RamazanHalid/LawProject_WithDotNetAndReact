using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs.UserDtos;
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
                var result = context.Set<User>().Where(x=> !exceptIsers.Contains(x.Id)); 
                return result.ToList();
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
                             where user.Id == id
                             select new GetUserInfoDto
                             {
                                 City = city,
                                 Country = country,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 ProfileImage = user.ProfileImage,
                                 Title = user.Title,
                                 CellPhone = user.CellPhone,
                                 Date = user.Date,
                                 Email = user.Email
                             };
                             //on country.CountryId equals city.CountryId  
                return result.FirstOrDefault();
                    
            }
        }
    }
}
