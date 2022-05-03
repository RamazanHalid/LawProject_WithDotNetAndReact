using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.UserDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLicenceUserDal : EfEntityRepositoryBase<LicenceUser, HukukContext>, ILicenceUserDal
    {
        public List<LicenceUser> GetAllInclude(Expression<Func<LicenceUser, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<LicenceUser>().Include(lu => lu.Licence).Include(lu => lu.User2).ToList()
                    : context.Set<LicenceUser>().Where(filter).Include(lu => lu.Licence).Include(lu => lu.User2).ToList();
            }
        }
        public LicenceUser GetInclude(Expression<Func<LicenceUser, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<LicenceUser>().Include(lu => lu.Licence).Include(lu => lu.User2).FirstOrDefault(filter);
            }
        }
        public List<int> GetAllUserIdByLicenceId(int licenceId)
        {
            using (var context = new HukukContext())
            {
                return context.Set<LicenceUser>().Where(l => l.LicenceId == licenceId).Select(w => w.UserId).ToList();
            }
        }
        public List<User> GetAllUsersRecordedToTheLicence(Expression<Func<LicenceUser, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return context.Set<LicenceUser>().Where(filter).Select(w => w.User2).ToList();
            }
        }
        public List<GetUserInfoForLicenceUserAsAdminDto> GetAllUserRecordToLicence(int pageNumber, int pageSize, int licenceId)
        {
            using (var contex = new HukukContext())
            {
                var result = from licenceUser in contex.LicenceUsers
                             join user in contex.Users on licenceUser.UserId equals user.Id
                             select new GetUserInfoForLicenceUserAsAdminDto
                             {
                                 CellPhone = user.CellPhone,
                                 AddedDateToLicence = licenceUser.StartDate,
                                 Email = user.Email,
                                 EndDateLeavtFromLicence = licenceUser.EndDate,
                                 FirstName = user.FirstName,
                                 IsActiveOnLicence = licenceUser.IsActive,
                                 LastName = user.LastName,
                                 ProfileImage = user.ProfileImage,
                                 RecordedLicenceId = licenceUser.LicenceId
                             };
                if (licenceId > 0)
                    result.Where(w => w.RecordedLicenceId == licenceId);
                result.OrderBy(w => w.AddedDateToLicence);
                return result.ToList();
            }
        }
    }
}
