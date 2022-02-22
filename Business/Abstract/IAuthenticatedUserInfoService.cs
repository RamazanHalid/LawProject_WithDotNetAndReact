using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthenticatedUserInfoService
    {
        int GetUserId();
        int GetLicenceId();
        bool IsAuth();
    }
}
