using Core.Utilities.Results;
using Entities.DTOs.ChatSupportDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IChatSupportService
    {
        IDataResult<List<ChatSupportListAsAdmin>> GetAllSelectedUserMessageAsAdmin(int userId, int licenceId);
        IDataResult<List<ChatSupportListAsUser>> GetAllMessageAsUser();
        IResult AddAsAdmin(ChatSupportAddAsAdmin chatSupportListAsAdmin);
        IResult AddAsUser(ChatSupportAddAsUser chatSupportAddAsUser);
        IResult MakeItReadAsuser();
        IResult MakeItReadAsAdmin(int userId, int licenceId);
        IDataResult<List<ListAllUsersToSideBar>> ListAllUsersToSideBar();
     }
}
