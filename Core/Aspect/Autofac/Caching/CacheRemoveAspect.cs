using Castle.DynamicProxy;
using Core.CrossCuttingCorcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspect.Autofac.Caching
{
    //CacheRemoveAspect  Datamız bozulduğu zaman çalışır.Data bozulmasından kasıt yeni data eklenmesi güncellenmesi sillinmesi demek yani.
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);//Pattern'a göre silme işlemi.
        }
    }
}
