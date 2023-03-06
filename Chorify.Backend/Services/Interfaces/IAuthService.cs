using Chorify.Domain.Dtos;
using Chorify.Domain.Models;

namespace Chorify.Backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task Register(HttpRequest request, UserRegisterDto dto);
        Task Login(HttpRequest request, HttpResponse response, UserLoginDto dto);
        Task Logout(HttpRequest request, HttpResponse response);
        Task<User?> GetUser(HttpRequest request);
    }
}
