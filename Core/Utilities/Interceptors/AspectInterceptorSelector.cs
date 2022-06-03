using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //GetCustomAttributes ile Class'in Attributleri okunur ve bir listeye atanır.
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //GetMethod ile Metod'un Attributelerini okunur.
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            //methodAttributes'in Metodları okunan Attributeleri classAttribute listesine atanır.
            classAttributes.AddRange(methodAttributes);

            //Tüm methodlara PerformanceAspect uygulamış olduk.
            classAttributes.Add(new PerformanceAspect(3));

            //classAttributes çalişma sırasını Priority(öncelik sırası) e göre belirle ve bir diziye ata.
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }






}
