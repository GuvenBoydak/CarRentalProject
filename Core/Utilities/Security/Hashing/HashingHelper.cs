using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //PasswordHash oluşturur.
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //passwordSalt'a hmac.key veriyoruz.Daha sonra passwordHash'i bunun sayesinde dogrulama kontrolu yapıyoruz.
                passwordSalt = hmac.Key;
                //Encoding.UTF8.GetBytes ile string ifadeyi byte arraye ceviriyor.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        //PasswordHash i Dogrulama kontrolu yapıyoruz. Veri tabanınaki passwordHash degeri ile dogrulama yapıp işlem yapıyoruz.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //Yukarıda oluşturdugumuz passwordSalt'İ parametre olarak veiyoruz.
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //HMACSHA512(passwordSalt) sayesinde girilen password'u hashliyoruz.
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computeHash.Length; i++)
                {
                    //computeHash'i tek tek dönüyruz ve passwordHash ile aynımı kontrolu yapıyoruz.
                    if (computeHash[i] != passwordHash[i])
                        return false;

                }
            }
            return true;
        }
    }
}
