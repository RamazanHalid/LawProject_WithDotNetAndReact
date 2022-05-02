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
            }
        }
        //public List<ChatSupport> GetAllWithInclude2()
        //{
        //    using (var context = new HukukContext())
        //    {
        //        var result = context.Set<ChatSupport>()
        //            .Select(cs => new ChatSuppoertUserListAsAdmin
        //            {
        //                UserId = cs.UserId,
        //                LicenceId = cs.LicenceId,
        //                ChatSupportId = cs.ChatSupportId,   
        //                Date = cs.Date,
        //                DoesItRead = cs.DoesItRead,
        //                IsAnswer = cs.IsAnswer,
        //                LicenceName = cs.
        //            })
        //            .GroupBy(x => x.LicenceId);


        //       return result.ToList()
        //    }
        //}
    }
}
