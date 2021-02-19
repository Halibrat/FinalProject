using Castle.DynamicProxy;
using Core.CrossCuttingCorcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception 
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //Attiributeune type olarak validatortype ver diyoruz burda.(Managerlarda Metotların üzerinde yazdığımız yapı yani)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //Attiribute de type ile geçmek zorudayız.Gönderilen validator type bir IValidator değilse hata verdirtiyoruz.Attirbute bu kısıtı vermek zorundayız.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//OnBefore'u MethodInterception' dan hatırlıyoruz.Metotdan önce Attirbutenin çalışması için.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Burası bir reflektor.Relection çalışma anında newleme işini yaptığımız yapı.Yani çalışma anında İnctance olusturur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //T Validatorun çalışma tipini buluyor.Yani BaseType'ında ki generic argümanı bul.(Örm:CarValidator'un basetype'ını bul (AbstractValidator<Car> yani) onunda generic tipini bul <Car> yani.)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//İlgili metodun parametrelerini buluyor.Yani CarValidator yazdığın metotun içindeki car parametreleri bul örnekle açıklamak gerekirse işlevi bu. 
            foreach (var entity in entities)//tek tek hepsini gezip Validate ediyor.
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
