using Core.Entities.Concrete;
using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static List<string> AuthorizationDenied = new List<string> { "Unauthorized." };
        public static List<string> GetAllSuccessfuly = new List<string> { "Listed All Successfuly!" };
        public static List<string> GetByIdSuccessfuly = new List<string> { "Get Special Entity Successfuly!" };
        public static List<string> AddedSuccessfuly = new List<string> { "Added Successfuly!" };
        public static List<string> UpdatedSuccessfuly = new List<string> { "Updated Successfuly!" };
        public static List<string> DeletedSuccessfuly = new List<string> { "Deleted Successfuly!" };
        public static List<string> TheItemDoesNotExists = new List<string> { "Item does not exists!" };
        public static List<string> TheItemExists = new List<string> { "Item exists" };
        public static List<string> ActivityChangedSuccessfuly = new List<string> { "Activity changed successfuly!" };
        public static List<string> GetAllByLicenceIdSuccessfuly = new List<string> { "Listed All By Licence Successfuly!" };
        public static List<string> RegistrationSuccessfuy = new List<string> { "Registration successfuly!" };
        public static List<string> CellPhoneCode = new List<string> { "Confirm your account with the code sent to your mobile phone!!" };
        public static List<string> UserDoesNotExistMessage = new List<string> { "User does not exist!" };
        public static List<string> WrongPassword = new List<string> { "Wrong password!" };
        public static List<string> UnactivceAccount = new List<string> { "Unactive account!" };
        public static List<string> LoginSuccessSelectLicence = new List<string> { "Login is successful! Please select your LICENCE" };
        public static List<string> TokenCreated = new List<string> { "Token created!" };
        public static List<string> WrongSmsCode = new List<string> { "Sms code is wrong!" };
        public static List<string> AccountApproved = new List<string> { "Account approved!" };
        public static List<string> SmsSended = new List<string> { "Sms sended!" };

        public static string ToString(this List<string> message)
        {

            return JsonConvert.SerializeObject(message);
        }
        public static List<string> CellPhoneValidation = new List<string> { "Cell phone number must start with 5 and 10 digits totaly!", "rrrr" };
        public static List<string> PasswordValidation = new List<string> { "Passwrod length must be at least 6!", "werfd" };

        public static List<string> SmsCouldNotSend = new List<string> { "Sms could not send!" };

        public static List<string> PasswordChangedSuccessfuly = new List<string> { "Password changed successfuly!" };

        public static List<string> UnauthenticatedUser = new List<string> { "You must be logged in to do this." };
    }
}
