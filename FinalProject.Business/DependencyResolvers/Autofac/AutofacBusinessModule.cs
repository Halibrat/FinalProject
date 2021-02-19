using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using FinalProject.Business.Abstract;
using FinalProject.Business.Concrete;
using FinalProject.DataAccess.Abstract;
using FinalProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.DependencyResolvers.Autofac
{
    //Business a Autofac ve Autofac.exrtras.dynamicproxy(AOP için) yükledik.Yükledikten sonra dependency resolver klasörünü ve içine de autofac kalsörü olusturduk.
    //Dependecy Resolvers bağımlılık azaltmak için kullanıyoruz.Bunun için Autofac teknolojisini kullanyoruz.
   public class AutofacBusinessModule:Module //Module'u using reflector ile değil using Autoface ile çözüyoruz!!!Bu sayede sen artık Autofac modulusun demiiş olduk.
    {

        protected override void Load(ContainerBuilder builder) //Load yapıyoruz çünkü uygulama hayata geçtiğinde aşağıdaki kodları çalıştıracak.
        {

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            //Yukarıda yaptığımız işlem biri senden IProductService isterse ona ProductManager inctance i ver.IProductDal isterse EfProduct inctance i ver.SıngleIntance() ise tekbir inctance olustur herkes onu kullansın demek.
            //Burdan WEbAPI içinde ki program.cs gidiyoruz.

            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //Burayı en son Aspects oluşturudktan sonra yazdık.Çalışan uygulama içerisinde;

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()//İmplemente edilmiş interfaceleri bul.
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector() //Onlar için AspectInterceptorSelector() çağır.Kısacası Autofac bizim için bütün sınıflarımız için önce Aspectlerimiz çalıştıyor(Örneğin:  [ValidationAspect(typeof(ProductValidator))] varsa buradaki validate kontrollerine bakılıyor.)
                }).SingleInstance();
        }
    }
}
