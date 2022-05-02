using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ChatSupportDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ChatSupportManager : IChatSupportService
    {
        private readonly IChatSupportDal _chatSupportDal;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ChatSupportManager(IChatSupportDal chatSupportDal, IMapper mapper, ICurrentUserService currentUserService)
        {
            _chatSupportDal = chatSupportDal;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public IResult AddAsAdmin(ChatSupportListAsAdmin chatSupportListAsAdmin)
        {
            ChatSupport chatSupport = _mapper.Map<ChatSupport>(chatSupportListAsAdmin);
            chatSupport.DoesItRead = false;
            chatSupport.Date = DateTime.Now;
            chatSupport.IsAnswer = true;

            _chatSupportDal.Add(chatSupport);

            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult AddAsUser(ChatSupportAddAsUser chatSupportAddAsUser)
        {
            ChatSupport chatSupport = _mapper.Map<ChatSupport>(chatSupportAddAsUser);
            chatSupport.LicenceId = _currentUserService.GetLicenceId();
            chatSupport.UserId = _currentUserService.GetUserId();
            chatSupport.DoesItRead = false;
            chatSupport.Date = DateTime.Now;
            chatSupport.IsAnswer = false;


            _chatSupportDal.Add(chatSupport);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IDataResult<List<ChatSupportListAsUser>> GetAllMessageAsUser()
        {
            List<ChatSupportListAsUser> chatSupportListAsUsers = _mapper.Map<List<ChatSupportListAsUser>>(_chatSupportDal.GetAll(
                cs => cs.UserId == _currentUserService.GetUserId() && cs.LicenceId == _currentUserService.GetLicenceId()));
            return new SuccessDataResult<List<ChatSupportListAsUser>>(chatSupportListAsUsers, Messages.GetAllSuccessfuly);
        }

        public IDataResult<List<ChatSupportListAsAdmin>> GetAllSelectedUserMessageAsAdmin(int userId, int licenceId)
        {
            List<ChatSupportListAsAdmin> chatSupportListAsAdmin = _mapper.Map<List<ChatSupportListAsAdmin>>(_chatSupportDal.GetAllWithInclude(
     cs => cs.UserId == userId && cs.LicenceId == licenceId));
            return new SuccessDataResult<List<ChatSupportListAsAdmin>>(chatSupportListAsAdmin, Messages.GetAllSuccessfuly);
        }
        public IResult MakeItReadAsAdmin(int userId, int licenceId)
        {
            List<ChatSupport> chatSupport = _chatSupportDal.GetAll(cs => cs.LicenceId == licenceId && cs.UserId == userId);
            chatSupport.ForEach(c => c.DoesItRead = true);

            _chatSupportDal.UpdateRange(chatSupport);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IResult MakeItReadAsuser()
        {
            List<ChatSupport> chatSupport = _chatSupportDal.GetAll(cs => cs.UserId == _currentUserService.GetUserId() && cs.LicenceId == _currentUserService.GetLicenceId());
            chatSupport.ForEach(c => c.DoesItRead = true);
            _chatSupportDal.UpdateRange(chatSupport);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
       //public List<ChatSuppoertUserListAsAdmin> ChatSuppoertUserListAsAdmins()
       // {

       // }

    }
}
