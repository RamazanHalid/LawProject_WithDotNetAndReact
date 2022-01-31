using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime ="Sistem bakımda";
        public static string ProductsListed ="Ürünler listelendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok.";


        public static string GetAllSuccessfuly = "Listed All Successfuly!";
        public static string GetByIdSuccessfuly = "Get Special Entity Successfuly!";
        public static string AddedSuccessfuly = "Added Successfuly!";
        public static string UpdatedSuccessfuly = "Updated Successfuly!";
        public static string DeletedSuccessfuly = "Deleted Successfuly!";

        public static string TheItemDoesNotExists = "Item does not exists!";

        public static string TheItemExists = "Item exists";
    }
}
