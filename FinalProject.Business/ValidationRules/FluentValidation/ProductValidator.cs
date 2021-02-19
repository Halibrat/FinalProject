using FinalProject.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.ValidationRules.FluentValidation
{
   public class ProductValidator:AbstractValidator<Product>
    {
        //Business katmanına fluentvalidation yükledik. 
        public ProductValidator()
        {
            //Burada productda ki nesnelerimizin boş geçilip geçilemeyeceği,uzunluğu,kısalığı,büyük olması gereken değer vb kuralları varsa belirtiyoruz.
            //Bu kuralların iş kuralından ziyade nesneleri ilgilendiren kurallar olmasına özen gösteriyoruz.
            //Yani buradaki kurallar doğrulama kuralı olmalıdır.
            //Buradan sonra Core katmanına Croos cutting Corcerns e geçiyoruz.
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA);
            
        }

        private bool StartWithA(string arg)
        {
            
            return arg.StartsWith("A");
        }
    }
}
