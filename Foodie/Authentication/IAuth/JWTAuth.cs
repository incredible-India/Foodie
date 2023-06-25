using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace Foodie.Authentication.IAuth
{
    public class JWTAuth:IAuth
    {
        private readonly IConfiguration _config;

        public JWTAuth(IConfiguration cofig)
        {
            _config = cofig;
            
        }

        public string GenerateToken(Foodie.Models.Users users)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var Credential = new SigningCredentials(SecurityKey,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],null
               , expires: DateTime.Now.AddMinutes(2), signingCredentials:Credential);

          
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
