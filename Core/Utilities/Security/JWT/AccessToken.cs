using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }//kulanıcıya vericegimiz token degeri

        public DateTime Expiration { get; set; } //Verilen token süresini tutuyoruz
    }
}
