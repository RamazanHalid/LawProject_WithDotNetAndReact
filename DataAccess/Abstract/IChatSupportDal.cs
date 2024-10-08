﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.ChatSupportDtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IChatSupportDal : IEntityRepository<ChatSupport>
    {
        List<ChatSupport> GetAllWithInclude(Expression<Func<ChatSupport, bool>> filter = null);
        ChatSupport GetByIdWithInclude(Expression<Func<ChatSupport, bool>> filter);
        List<ListAllUsersToSideBar> ListAllUsersToSideBars();
        void UpdateRange(List<ChatSupport> chatSupports);
    }
}
