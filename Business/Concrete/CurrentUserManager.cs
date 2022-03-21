using Business.Abstract;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace Business.Concrete
{
    public class CurrentUserManager : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserManager()
        {
            _httpContextAccessor = _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
         }
  
        public int GetLicenceId()
        {
            if (IsAuth())
            {
                int licenceId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GroupSid).Value);
                return licenceId;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
        public int GetUserId()
        {
            if (IsAuth())
            {
                int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userId;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
        public bool IsAuth()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
