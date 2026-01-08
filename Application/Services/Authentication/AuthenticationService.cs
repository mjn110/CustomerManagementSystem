using Application.Common.Interface.Authentication;
using Application.Common.Interface.Persistence;
using Application.DTO.Authentication;
using Domain.Entities;
using System.Xml.Linq;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResponse Register(string firstName, string lastName, string Email, string Password)
        {
            // Validate user doesn't exist
            if (_userRepository.GetUserByEmail(Email) is not null)
            { 
                throw new Exception("User with given email already exists.");
            }

            // Create user in database(Generate unique ID) & Persist to database
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = Email,
            };

            _userRepository.Add(user);

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResponse(
                user,
                token
            );
        }
        public AuthenticationResponse Login(string Email, string Password)
        {
            // Validate user exists
            if(_userRepository.GetUserByEmail(Email) is not User user)
            {
                throw new Exception("User with given email does not exist.");
            }

            // Validate user credentials
            //if(user.Password != Password)
            //{
            //    throw new Exception("Invalid password.");
            //}

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResponse(
                user,
                token
            );
        }
    }
}