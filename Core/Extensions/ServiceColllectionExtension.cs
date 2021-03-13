using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
   public static class ServiceColllectionExtension
    {
        public static IServiceCollection AddDependecyResolvers(this IServiceCollection serviceCollection,ICoreModule[] modules)//İstediğimiz kadar Module eklemek için yazıyoruz.Bir nevi polimorfizm yapıyoruz.tis IServiceCollection yazmamızın sebebi IServiceCollection u genişletmek istediğimiz için.
        {
            foreach (var module in modules)//Modullerdeki her bir module dön ekle.(alttaki Load işlemi)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
