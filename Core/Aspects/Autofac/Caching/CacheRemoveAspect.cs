using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    //Data silinirse,güncellenirse,eklenirse çalişir.
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            //CoreModule'a yazdıgımız injection sayesinde bellekte instance oluşuyor.
            //ServiceTool.ServiceProvider.GetService<ICacheManager>(); sayesınde bellekte olan instance i alıp _cacheManager'e atıyoruz.
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        //method başarılı olduktan sonra cachdeki veiyi siliyor.
        protected override void OnSuccess(IInvocation invocation)
        {
            //Çalişma anında cache ki verileri bulup siliyoruz RemoveByPattern(_pattern) sayesinde.
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
