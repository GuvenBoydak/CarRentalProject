using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    
    public class SecurityKeyHelper
    {
        //Kullandıgımız securityKey'i Asp Net jwt servislerinin anliyacagı hale getirmemeiz gerekiyor bu yüzden string ifadeyi byte array formatına çeviriyoruz buradaki method sayesinde.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //SymmetricSecurityKey ile Security  Key'in simetriğini alıyoruz.
            //Encoding.UTF8.GetBytes(securityKey) ile string ifadeyi byte array'e dönüştürür.
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
