using Core.Utilities.Resluts;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
   public interface IProductService
    {
        //Void olan yerlerde IResult döndürüyoruz artık!
        IDataResult<List<Product>> GetAll();//IDataResult'ın buraya olan katkısı sadece ürünleri değil ürün listesiyle beraber işlem sonucu ve mesajıda döndürüyoruz.
        IDataResult<List<Product>> GetAllByCategory(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();    
        IResult Add(Product product);//IResult' buraya olan katkısı ekleme işlemi ile beraber işlem sonucu ve mesajda döndürmesidir.
        IDataResult<Product> GetById(int productId);
    }
}
