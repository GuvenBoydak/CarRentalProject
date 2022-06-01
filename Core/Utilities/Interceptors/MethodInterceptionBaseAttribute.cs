using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{

    //Bu Attributu (AttributeTargets) ile classlara, methodlara eleyebiliriz.(AllowMultiple) ile  Birden fazla attribute ekleyebiliriz, Inherited ile inherited(Kalıtım) edilen yerde çalişir.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Öncelik Hangi Atribute önce çalişicak 

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
