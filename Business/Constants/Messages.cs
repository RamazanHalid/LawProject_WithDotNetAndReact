using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string GetAllSuccessfuly = "Listed All Successfuly!";
        public static string GetByIdSuccessfuly = "Get Special Entity Successfuly!";
        public static string AddedSuccessfuly = "Added Successfuly!";
        public static string UpdatedSuccessfuly = "Updated Successfuly!";
        public static string DeletedSuccessfuly = "Deleted Successfuly!";
        public static string TheItemDoesNotExists = "Item does not exists!";
        public static string TheItemExists = "Item exists";
        public static string ActivityChangedSuccessfuly = "Activity changed successfuly!";
        public static string GetAllByLicenceIdSuccessfuly = "Listed All By Licence Successfuly!";
    }
}
