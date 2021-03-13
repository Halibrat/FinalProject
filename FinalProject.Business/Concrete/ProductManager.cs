using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CCS;
using Core.CrossCuttingCorcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Resluts;
using Core.Utilities.Results;
using FinalProject.Business.Abstract;
using FinalProject.Business.BusinessAspects.Autofac;
using FinalProject.Business.Constans;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.DataAccess.Abstract;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Business.Concrete
{
   
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
      
      
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
       
            
        }
        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            // ValidationTool.Validate(new ProductValidator(), product); Aspect yapımız sayesinde artık bunu değil yukaridaki Attirubute yi kullanıyoruz.
           IResult result= BusinessRules.Run(ChechIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceted());
            if (result !=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);  
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll() 
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintemanceTime);
            }

            return new SuccessDataResult<List<Product>>( _productDal.GetAll(),Messages.ProductsListed);  
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
          return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));   
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
           return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
           return new SuccessDataResult<List<Product>>(  _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max)); 
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour==17)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintemanceTime);
            }
          return new SuccessDataResult<List<ProductDetailDto>>(  _productDal.GetProductDetails());
        }

        private IResult ChechIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId ==categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName ==productName).Any();
            if (result==true)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceted()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice<10)
            {
                throw new Exception("");
            }
            Add(product);
            return null;
        }
    }
}
