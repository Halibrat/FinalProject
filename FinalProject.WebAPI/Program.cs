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
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//servis saðlayýcý fabrikasý olarak AutofacServiceProviderFactory'ý kullan dedik.Çünkü "AutofacBusinessModule" classýnda ki yaptýðýmýz inctance aldýrma komutlarýnýn burada çalýþmasý için.
              //Yukarýdaki kýsmý "doðru" yazan arkadaþlar hata alýyorlarsa WebAPI ye nugetten Autofac.Extensions.DependencyInjection yüklediklerine emin olsunlar.Yoksa AutofacServiceProviderFactory() altý kýrmýzý çizgi ile çizer hata verir.
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule()); //IOC containerýmýzýn çalýþmasý içinde bi<im containerimiz Autofacbusinessmodule demiþ olduk.Bu iþlemden sonra FluentValidation'a geçtik(ders içeriðine göre).
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
