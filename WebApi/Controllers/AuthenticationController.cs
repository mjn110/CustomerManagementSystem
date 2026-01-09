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
            var response = _authenticationService.Register(request.firstName, request.lastName, request.Email, request.Password);

            if (response is null)
            { 
                return (IActionResult)Results.BadRequest();
            }

            //IdentityResult addToRoleResult = await _userManager.AddToRoleAsync(user, Roles.User);

            return Ok(response.Result.Token);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto request)
        {
            var response = _authenticationService.Login(
                request.Email,
                request.Password);

            return Ok(response);
        }
    }
}