
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
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
           
        }
    }
}
