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

        public static string AuthorizationDenied = "Unauthorized.";
        public static string GetAllSuccessfuly = "Listed All Successfuly!";
        public static string GetByIdSuccessfuly = "Get Special Entity Successfuly!";
        public static string AddedSuccessfuly = "Added Successfuly!";
        public static string UpdatedSuccessfuly = "Updated Successfuly!";
        public static string DeletedSuccessfuly = "Deleted Successfuly!";
        public static string TheItemDoesNotExists = "Item does not exists!";
        public static string TheItemExists = "Item exists";
        public static string ActivityChangedSuccessfuly = "Activity changed successfuly!";
        public static string GetAllByLicenceIdSuccessfuly = "Listed All By Licence Successfuly!";
        public static string RegistrationSuccessfuy = "Registration successfuly!";
        public static string CellPhoneCode = "Confirm your account with the code sent to your mobile phone!!";
        public static string UserDoesNotExistMessage = "User does not exist!";
        public static string WrongPassword = "Wrong password!";
        public static string UnactivceAccount = "Unactive account!";
        public static string LoginSuccessSelectLicence = "Login is successful! Please select your LICENCE";
        public static string TokenCreated = "Token created!";
        public static string WrongSmsCode = "Sms code is wrong!";
        public static string AccountApproved = "Account approved!";
        public static string SmsSended = "Sms sended!";

        public static string CellPhoneValidation = "Cell phone number must start with 5 and 10 digits totaly!";
        public static string PasswordValidation = "Passwrod length must be at least 6!";
        public static string SmsCouldNotSend = "Sms could not send!";
        public static string PasswordChangedSuccessfuly = "Password changed successfuly!";
        public static string UnauthenticatedUser = "You must be logged in to do this.";
        public static string OnlyLicenceOwnerCanChange = "Only licence owner can update the licence";

        public static string GetCountFailed = "Get counf of entity failed";
        public static string GetCountSuccessfuly = "Get counf of entity successfuly";
    }
}
