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
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Ürün Sayısı fazladır.";
        public static string ProductNameAlreadyExists = "Aynı isimde ürün mevcuttur";
        public static string CategoryLimitExceded = "Categori Limiti Yükselmiştir.";
        public static string AuthorizationDenied = "Hatalı yetkilendirme";
    }
}