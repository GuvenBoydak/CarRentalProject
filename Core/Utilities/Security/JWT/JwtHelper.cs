
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        //appsettings.json içerisindeki verdigimiz TokenOptions degerlerine karşilik gelen sınıf a injection yapıyoruz.
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            //Configuration appsettings.json gibi alanlardaki json dosyalarını okumamızı saglıyor.
            Configuration = configuration;
            //Configuration.GetSection("TokenOptions") ile appsettings.json içerisindeki TokenOptions degerlerini Get<TokenOptions> sınıfındaki degerlere atıyoruz(Mapliyoruz).
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //Token bitiş süresini veriyoruz DateTime.Now.AddMinutes ile oluştugu andan itibaren _tokenOptions.AccessTokenExpiration dan gelen süreyi veriyoruz.
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            //_tokenOptions.SecurityKey ile  TokenOptions icerisindeki securityKey'i veriyoruz ve byte array olarak bir SecurityKey oluşturuluyor.
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            //bir üstte oluştrulan securtiyKey veriyoruz ve bize bir creadentials oluşturuyor.
            SigningCredentials signingCredentials = SigningCredentialHelper.CreateSigningCredentials(securityKey);

            //Token olusturmak için gerekli olan parametreleri veriyoruz ve bize bir Token oluşturuyor.
            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //jwt den gelen degerlerle bir jwt token oluşturuyoruz.
            string token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                //oluşan jwt i token a atıyoruz.
                Token = token,
                //token bitiş süresini Expriration a atıyoruz.
                Expiration = _accessTokenExpiration
            };

        }
        //JWT oluşturdugumuz method parametre olarak verdigimiz TokenOptins,user,signingCredentials ve liste olarak operationClaims vererek bir JWT oluşturuyoruz.
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        //Parametre olarak Kullanıcı ve OperationClaim degerine karşılık bize bir claim listesi oluşturuyor.
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            List<Claim> claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
