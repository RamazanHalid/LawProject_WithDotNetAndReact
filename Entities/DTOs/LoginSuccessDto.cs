using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class LoginSuccessDto : IDto
    {
        public AccessToken AccessToken { get; set; }
        public List<string> OperationClaims { get; set; }
    }
}
