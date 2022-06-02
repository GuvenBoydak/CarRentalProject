using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IOC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        //Wep Api yada Autofacde oluşturdugumuz injection ları oluşturabilmemizi saglıyor.
        //istedigimiz interface'in service deki karşılıgını bu tool sayesinde alabiliyoruz.

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
