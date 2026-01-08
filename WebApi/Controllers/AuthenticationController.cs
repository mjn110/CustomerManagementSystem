using Application.DTO.Authentication;
using Application.Services.Authentication;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<User> _userManager;
        public AuthenticationController(IAuthenticationService authenticationService, UserManager<User> userManager)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.firstName,
                LastName = request.lastName
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, request.Password);

            if (!identityResult.Succeeded)
            { 
                return (IActionResult)Results.BadRequest(identityResult.Errors);
            }

            IdentityResult addToRoleResult = await _userManager.AddToRoleAsync(user, Roles.User);

            if (!identityResult.Succeeded)
            {
                return (IActionResult)Results.BadRequest(identityResult.Errors);
            }

            return (IActionResult)Results.Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto request)
        {
            var response = _authenticationService.Login(
                request.Email,
                request.Password);

            //var response = new AuthenticationResponse(
            //    authResult.User,
            //    authResult.Token
            //);

            return Ok(response);
        }
    }
}