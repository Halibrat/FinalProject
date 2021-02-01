using FinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
   public interface IProductService
    {
        List<Product> GetAll();
    }
}
