using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISmsService
    {
        IResult SendIndividualMessage(string message, params string[] cellPhones);
        IResult SendMessageWithList(string message, List<string> clientsNumberList);
        IResult SendSmsToMembers(string message, List<int> ids);
        IResult SendSmsToCustomers(string message, List<int> ids);
    }
}
