using Chorify.Domain.Dtos;
using Chorify.Domain.Models;

namespace Chorify.Backend.Services.Interfaces
{
    public interface IAuthService
    {
        void Register(HttpRequest request, RegisterDto dto);
        void Login(HttpRequest request, HttpResponse response, LoginDto dto);
        void Logout(HttpRequest request, HttpResponse response);
        User? GetUser(HttpRequest request);
    }
}
