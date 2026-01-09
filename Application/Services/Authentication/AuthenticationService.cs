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

        public async Task<AuthenticationResponse> Register(string firstName, string lastName, string Email, string Password)
        {
            // Validate user doesn't exist
            if (_userRepository.GetUserByEmail(Email) is not null)
            { 
                throw new Exception("User with given email already exists.");
            }

            // Create user in database(Generate unique ID) & Persist to database
            var CreateResult = await _userRepository.Add(firstName, lastName, Email, Password);
            if (!CreateResult.Succeeded)
            {
                throw new Exception("Failed to create user.");
            }

            //Retrieve the newly created user
            var RegisteredUser = _userRepository.GetUserByEmail(Email);

            // Assign user role
            var RoleResult = await _userRepository.AssignUserRole(RegisteredUser);
            if (!RoleResult.Succeeded)
            {
                throw new Exception("Failed to assign user role.");
            }

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(RegisteredUser);

            return new AuthenticationResponse(
                RegisteredUser,
                token
            );
        }
        public AuthenticationResponse Login(string Email, string Password)
        {
            var User = new User();
            // Validate user exists
            if (_userRepository.GetUserByEmail(Email) is not User user)
            {
                throw new Exception("User with given email does not exist.");
            }

            // Validate user credentials
            try {
                User = _userRepository.GetUserByEmail(Email);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid credentials provided.");
            }

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(User);
            return new AuthenticationResponse(
                User,
                token
            );
        }
    }
}