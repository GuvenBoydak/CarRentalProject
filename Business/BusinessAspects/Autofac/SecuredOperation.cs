using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        //Jwt göndererek yapılan her bir istekde bir httpContextAccessor oluşturuluyor.
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            //SecuredOperation attribute parametre olarak verilen rolleri split ile ayırıyoruz ve bir string diziye atıyoruz.
            _roles = roles.Split(',');

            //Bu sınınf bir aspects oldugu için injecte edemiyoruz bu yüzden autofac ile oluşturdugumuz servis mimarisine ulaşıp GetService ile ekle diyoruz. 
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        //Bu attribute nerede çalişacagını belirliyoruz.
        protected override void OnBefore(IInvocation invocation)
        {
            //Kullanıcının rollerını bulup rolesClaims'e atıyor.
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //Methodun split ile ayrdıgımız rollerıni gez
            foreach (var role in _roles)
            {    
                //Kullanıcının rolu içerisinde ilgili rol varsa return et.
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            //Kullanıcının rolu içerisinde ilgili rol yoksa hata fırlatır..
            throw new Exception(Messages.AuthorizationDenied); 
        }
    }
}
