using Core.CrossCuttingCorcerns.Caching;
using Core.CrossCuttingCorcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependecyResolvers
{
    public class CoreModule : ICoreModule
    {
        //.Net ile alakalı olan bağımlılıklarımızı aertık buraya yazıyoruz.
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //MemoryCacheManager deki IMemoryCache _memoryCache injection in çalışabilmesi için yazdık.Redise geçince buna gerek kalmıyor.AddMemoryCache hazır bir injection(nerden geldi diye merak edenler F12ye bakıp geldiği yapının içine bakabilirler.)
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager,MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
