using System.IdentityModel.Tokens.Jwt;

namespace Chorify.Backend.Services.Interfaces
{
    public interface IJwtService
    {
        string Generate(Guid id);
        JwtSecurityToken Verify(string jwt);
    }
}
