using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalksAPIs.Repositories
{
    public class TokenRepositoty : ITokenrepository
    {
        private readonly IConfiguration _config;

        public TokenRepositoty(IConfiguration Config)
        {
            _config = Config;
        }

        public string CreateJWTToken(IdentityUser User, List<string> roles)
        {
            var claim = new List<Claim>();

            claim.Add(new Claim(ClaimTypes.Email, User.Email));
            foreach (var role in roles)
            {
                claim.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claim,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
