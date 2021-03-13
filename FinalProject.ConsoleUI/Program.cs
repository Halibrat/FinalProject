
using FinalProject.Business.Concrete;
using FinalProject.DataAccess.Concrete.EntityFramework;
using FinalProject.DataAccess.Concrete.InMemory;
using System;

namespace FinalProject.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
           // CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();
            if (result.Success==true)//GetProductDetails i yukarıda var result değişkenininiçine attık çünkü if yapımızda uzun uzun productManager.GetProductDetails() yazmak istemediğimiz için.Bununla beraber result.Success==true dememizin sebebi sisteme erişimin açık olup olmadığını kontrol etmek için.Açıksa foreach inm içine giriyor listemizi veriyor.Değilse Messages da yazdığımız ProductManagerde GetProductDetails'e atadığımız mesajı döndürüyor. 
            {
                foreach (var product in productManager.GetProductDetails().Data)//GetProductDetail'ın artık Datası.Mesajı ve Successi olduğu için sonuna Datamızı getirmek istediğimiz içib Data dedik.
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
                
        }
    }
}
