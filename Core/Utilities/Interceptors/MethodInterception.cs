using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //Burası tüm metodların Çatısı metodlar önce bu kurallardan geçer daha sonra çalişir.
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        //Interseptor a parametre olarak verilen invocation(method) çaliştirmak istedigimiz method. 
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation); //invocation(method) başında çaliştir.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//invocation(method) Hata aldıgında Çalişir.
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//invocation(method) Başarılı oldugunda Çalişir.
                }
            }
            OnAfter(invocation);//invocation(method)'dan sonra Çalişir.
        }
    }
}
