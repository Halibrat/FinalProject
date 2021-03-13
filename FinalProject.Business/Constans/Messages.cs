using FinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FinalProject.Business.Constans
{
    public static class Messages
    {
        //Messageları newlememek için statik yaptık.Classı static olduğu için içindeki yapılarda statik olmak zorunda !!! Fieldlarımız public olduğu için Pascal Case yazdık.
        //Peki burayı nedEN Core'da yazmadık ? Çünkü Core katmanına yazdığımız her yapı her proje için uygundur.Burada ki Messagelarmız ise gördüğünüz üzere bi e ticaret sistemi için ürün kısmına itafen yazıkmıs olabilr.Her zaman e ticaret pojesi yapmadığımız için burayı business da yazdık.
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintemanceTime="Ürün Listelemeye Kapalı";
        public static string ProductsListed="Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Kategoride ki ürün limidi aşıldı";
        public static string ProductNameAlreadyExists = "Bu isimde bir ürün sistemde mevcutturçLütfen başka bir ürün adı giriniz";
        public static string CategoryLimitExceded = "Kategori Limiti Aşıldı";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

    }   
}
