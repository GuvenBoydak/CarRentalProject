using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        //Default duration veriyoruz.
        public CacheAspect(int duration = 60)
        {
            _duration = duration;

            //CoreModule'a yazdıgımız injection sayesinde bellekte instance oluşuyor.
            //ServiceTool.ServiceProvider.GetService<ICacheManager>(); sayesınde bellekte olan instance i alıp _cacheManager'e atıyoruz.
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //{invocation.Method.ReflectedType.FullName} ile methodun namespace ile class isminin alıyoruz.
            //{invocation.Method.Name} ile methodun ismini alıyoruz ve methodName atıyoruz.
            string methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

            //invocation.Arguments.ToList(); ile methodun parametrelerini listeye çeviriyoruz.
            List<object> arguments = invocation.Arguments.ToList();

            //methodun parametresi var ise onları alıyor yok ise null olarak methodName e formatlayarak parantez içinde degerleri veriyoruz.
            string key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            //bellekte cache uyan key varmı 
            if (_cacheManager.IsAdd(key))
            {
                // invocation.ReturnValue methodun return degerini çaliştirmiyor verileri _cacheManager.Get(key) sayesinde cachden getiriyor.
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //yoksa
            //invocation.Proceed(); methodu devam ettir demek.
            invocation.Proceed();
            //Cache ekliyoruz.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
