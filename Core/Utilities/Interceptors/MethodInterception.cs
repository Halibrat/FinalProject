using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //Metodlarımızda bulunan Attributelerin metod içinde mi metoddan önce mi yoksa metoddan sonra mı çalışması gerektiğini burda tayin ediypruz.
        //Burası bir nevi bizim metotlarımızın çatısı oluyor.Metot direkt çalışmadan önce buradan geçecek.
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation); //Metoddan önce.En sık kullanınlardan.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); //Hata aldığında.En sık kullanılanlardan.
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); //Metod başarılı olduğunda. 
                }
            }
            OnAfter(invocation); //Metod bittiğinde.
        }
    }
}
