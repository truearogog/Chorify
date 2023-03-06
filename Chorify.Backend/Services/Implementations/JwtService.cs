using Chorify.Backend.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Chorify.Backend.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private string _secureKey = "keykeykeykeykeykeykeykey";

        public string Generate(Guid id)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
            var jwt = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secureKey);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}
