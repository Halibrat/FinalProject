using Castle.DynamicProxy;
using Core.CrossCuttingCorcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspect.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)//60 dakika boyunca veri cache de duracak sonra uçacak.
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//CacheAspect yazdıpımız metodun NameSpace+ class adı ve metodun adını veriyor.
            var arguments = invocation.Arguments.ToList();//Metodun parametresi varsa listeye çeviriyoruz.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//Metodname de oluşturduğumuz yapının metodunda parametre varsa () içinde onları ekler yoksa () içini boş bırkaır.
            if (_cacheManager.IsAdd(key))//Oluşan cache key i daha önce cachede varsa if içinde metod çalışmadan geri döner.
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();//Yoksa metodu çalıştır.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//cache e ekle.
        }
    }
}
