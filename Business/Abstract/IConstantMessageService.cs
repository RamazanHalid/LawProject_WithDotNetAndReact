using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IConstantMessageService
    {
        string AuthorizationDenied { get; }
        string GetAllSuccessfuly { get; }
        string GetByIdSuccessfuly { get; }
        string AddedSuccessfuly { get; }
        string UpdatedSuccessfuly { get; }
        string DeletedSuccessfuly { get; }
        string TheItemDoesNotExists { get; }
        string TheItemExists { get; }
        string ActivityChangedSuccessfuly { get; }
        string GetAllByLicenceIdSuccessfuly { get; }

    }
}
