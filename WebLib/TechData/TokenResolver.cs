using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using WebLib.TechData.Error;

namespace WebLib.TechData
{
    #pragma warning disable IDE1006 // Стили именования
    //пока полежит тут, до реализации
    public partial class GetUserTokenData
    {
        public string login { get; set; }

        public string pass { get; set; }
    }
    #pragma warning restore IDE1006 // Стили именования


    /// <summary>
    /// работа с токеном
    /// </summary>
    public class TokenResolve
    {
        /// <summary>
        /// получение токена
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static TokenData GetToken(GetUserTokenData data)
        {
            if (data == null || data.login == "" || data.pass == "")
                throw new WebLibException(ErrorList.WrongLogin_100);
            data.login = data.login.ToLower();

            // TODO -> check user log
          
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType,data.login),
                    new Claim("name",""),//u.UserName
                    new Claim("id","")   //u.UserId
                };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return GetToken(claimsIdentity, "", 0);//u.UserName, u.UserId);
        }

        /// <summary>
        /// создание токена
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        static TokenData GetToken(ClaimsIdentity identity, string userName, int userId)
        {
            var sigCred = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromDays(15)),
                    signingCredentials: sigCred);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenData
            {
                accessToken = encodedJwt,
                userName = userName,
                id = userId
            };
        }


        public class AuthOptions
        {
            public const string ISSUER = "AuthServer";
            public const string AUDIENCE = "http://192.168.0.199:50000/";
            const string key = "veryverysekretsecretkey!123";
            public const int LIFETIME = 1;
            public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
