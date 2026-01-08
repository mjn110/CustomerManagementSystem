using Application.DTO.Authentication;

namespace Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Register(string firstName, string lastName, string Email, string Password);
        AuthenticationResponse Login(string Email, string Password);
    }
}
