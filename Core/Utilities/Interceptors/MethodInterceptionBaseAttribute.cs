using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //Core Katmanına Autofac(Business ile aynı versiyon olsun), Autofac.Extensions.DependencyInjection(Core ile aynı versiyon olsun)  ve Autofac Autofac.exrtras.dynamicproxy(AOP için,Business ile aynı versiyon olsun) kuruyorz.
    //Burada Attiributelerini classlara veya methodlara birden fazla ekleyebilir ve inherit edilen bir noktada da kullanabilirsin dedik(Tabi bunları aşağıdaki [AttiributeUsage]'de verdik.AllowMultiple=false olsa birden fazla yerde kullanamazsın haline gelir mesela).Burası bize Managerda ki metotlarımız çalışmadan önce üstünde Attribude var mı ? diye kontrolü ve varsa oraya yönlenmesinde yardımcı oluyor.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }//Attributlerde hangisinin önce çalışmasını istersek bunu kullancağız.Yani Attributelere çalışma sırası verirsek.

        public virtual void Intercept(IInvocation invocation)
        {
           
        }
    }
}
