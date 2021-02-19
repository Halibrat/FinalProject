using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FinalProject.Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FinalProject.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//servis sa�lay�c� fabrikas� olarak AutofacServiceProviderFactory'� kullan dedik.��nk� "AutofacBusinessModule" class�nda ki yapt���m�z inctance ald�rma komutlar�n�n burada �al��mas� i�in.
              //Yukar�daki k�sm� "do�ru" yazan arkada�lar hata al�yorlarsa WebAPI ye nugetten Autofac.Extensions.DependencyInjection y�klediklerine emin olsunlar.Yoksa AutofacServiceProviderFactory() alt� k�rm�z� �izgi ile �izer hata verir.
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule()); //IOC container�m�z�n �al��mas� i�inde bi<im containerimiz Autofacbusinessmodule demi� olduk.Bu i�lemden sonra FluentValidation'a ge�tik(ders i�eri�ine g�re).
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
