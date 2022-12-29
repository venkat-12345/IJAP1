using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService.Controllers
{
    public class AuthController : ApiController
    {
        private string GenarateToken(string userName, string role, string key)
        {
            var issuer = "http://vkota.com";  //normally this will be your site URL    

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("name", userName));
            permClaims.Add(new Claim("role", role));

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            string jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt_token;
        }

        [HttpGet]
        public IHttpActionResult GetToken(string userName, string role, string key)
        {
            var token = GenarateToken(userName, role, key);
            return Ok(token);
        }
    }
}