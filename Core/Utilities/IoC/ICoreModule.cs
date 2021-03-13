using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
   public interface ICoreModule //Tümm projelerde kullanacağımız injectionlar için yazıyoruz bunu.Bunıiess katmanında Autofac ile yazdığımız module yapımız veri tabanı ile alakalı olan module yapımız.
    {
        void Load(IServiceCollection serviceCollection);//Genel bağımlılıklarımızı yükleyecek olan metodumuz.   
    }
}
