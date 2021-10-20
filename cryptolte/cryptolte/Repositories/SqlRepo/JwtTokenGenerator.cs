using cryptolte.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace cryptolte.Repositories.SqlRepo
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _config;

        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string generateToken(IdentityUser user)
        {
            //add claim
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            //add key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));

            //add credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7), //token will expire in 7 days
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string generateToken(IdentityUser user, IList<string> roles)
        {
            throw new NotImplementedException();
        }

        public string generateToken(IdentityUser user, IList<string> roles, IList<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
