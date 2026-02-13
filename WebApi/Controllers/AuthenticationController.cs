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
            try
            {
                var response = await _authenticationService.Register(request.firstName, request.lastName, request.Email, request.Password);

                if (response is null)
                {
                    return BadRequest();
                }

                return Ok(response.Token);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during registration.", details = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto request)
        {
            try
            {
                var response = _authenticationService.Login(
                request.Email,
                request.Password);

                if (response is null)
                {
                    return BadRequest();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during authentication.", details = ex.Message });
            }
        }
    }
}