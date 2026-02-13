using Application.DTO.Authentication;
using Domain.Entities;

namespace Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Register(string firstName, string lastName, string Email, string Password);
        AuthenticationResponse Login(string Email, string Password);
        User GetUser(string Email);
    }
}
