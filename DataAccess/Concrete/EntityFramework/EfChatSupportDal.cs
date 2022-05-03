using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ChatSupportDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfChatSupportDal : EfEntityRepositoryBase<ChatSupport, HukukContext>, IChatSupportDal
    {
        public List<ChatSupport> GetAllWithInclude(Expression<Func<ChatSupport, bool>> filter = null)
        {
            using (var context = new HukukContext())
            {
                return filter == null
                    ? context.Set<ChatSupport>()
                    .Include(cs => cs.Licence)
                    .Include(cs => cs.User)
                    .ToList()
                    : context.Set<ChatSupport>().Where(filter)
                    .Include(cs => cs.Licence)
                    .Include(cs => cs.User).ToList();
            }
        }

        public ChatSupport GetByIdWithInclude(Expression<Func<ChatSupport, bool>> filter)
        {
            using (var context = new HukukContext())
            {
                return context.Set<ChatSupport>()
                    .Include(cs => cs.Licence)
                    .Include(cs => cs.User).SingleOrDefault(filter);
            }
        }
        public void UpdateRange(List<ChatSupport> chatSupports)
        {
            using (var context = new HukukContext())
            {
                context.Set<ChatSupport>().UpdateRange(chatSupports);
                context.SaveChanges();
            }
        }
        public List<ListAllUsersToSideBar> ListAllUsersToSideBars()
        {
            using (var context = new HukukContext())
            {
                var result = from chatSupport in context.ChatSupports
                             join licence in context.Licences on chatSupport.LicenceId equals licence.LicenceId
                             join user in context.Users on chatSupport.UserId equals user.Id
                             orderby chatSupport.Date
                             select new ListAllUsersToSideBar
                             {
                                 Date = chatSupport.Date,
                                 LicenceId = chatSupport.LicenceId,
                                 LicenceProfileName = licence.ProfilName,
                                 UserFullName = user.FirstName + " " + user.LastName,
                                 UserId = user.Id,
                                 UserProfileImage = user.ProfileImage,
                                 MessageCount = context.ChatSupports.Count(w => w.UserId == user.Id && w.LicenceId == chatSupport.LicenceId),
                             };
                return result.ToList();
            }
        }
    }
}
