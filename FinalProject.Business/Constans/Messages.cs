using FinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Constans
{
    public static class Messages
    {
        //Messageları newlememek için statik yaptık.Classı static olduğu için içindeki yapılarda statik olmak zorunda !!! Fieldlarımız public olduğu için Pascal Case yazdık.
        //Peki burayı nedEN Core'da yazmadık ? Çünkü Core katmanına yazdığımız her yapı her proje için uygundur.Burada ki Messagelarmız ise gördüğünüz üzere bi e ticaret sistemi için ürün kısmına itafen yazıkmıs olabilr.Her zaman e ticaret pojesi yapmadığımız için burayı business da yazdık.
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        internal static string MaintemanceTime="Ürün Listelemeye Kapalı";
        internal static string ProductsListed="Ürünler Listelendi";
    }   
}
