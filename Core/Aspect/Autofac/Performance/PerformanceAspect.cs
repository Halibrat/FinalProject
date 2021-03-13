using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspect.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;//Timer.Metod ne kadar çalışcak.Bunu CoreModule da eklemeyi unutmayın.

        public PerformanceAspect(int interval)//Geçen sürenin örneğin businessda [PerformanceAspect(10)] yazdığımızda parantez içinde ki 10 interval oluyor yanı aralık.10 sn yi geçerse beni uyar demek istiyoruz burda.
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)//Metodun önonde kronometre başlar.
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)//interval olarak verdiğimiz süre aşılırsa 
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");//log olarak nerde ve kaç sn de performance verdiğini alıyoruz.Bunu burda console olrak verdik ama mail olarakda verilebilir.
            }
            _stopwatch.Reset();
        }
    }
}
