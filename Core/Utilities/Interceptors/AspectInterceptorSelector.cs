using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    //Bu class classın,metodun Attiributelerine bakmak ve onları bi listeye eklemek için var.
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();//classın Attiributelerini okur ve listele.
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true); //metodun Attirubetelerini oku ve listele.
            classAttributes.AddRange(methodAttributes);

            //"classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));"Şu an Logumuz olmadığı için buna gerek yok ama aktif olduğunda otomatik olarak sistemdeki bütün metotları Loga dahil eder.Tabi Log alt yapısını yazdıkdan sonra aktif hale getiriyoruz.

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //Öncelik değerine göre sırala.
        }
    }
}
