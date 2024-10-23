using Task2Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Task2Api.DTOs;

namespace Task2Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthorizationController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var user = await _userService.GetUserByUsernameAsync(loginRequest.Username);

        if (user == null || user.PasswordHash != loginRequest.Password) 
        {
            return Unauthorized("Invalid username or password.");
        }

        var token = _tokenService.GenerateToken(user);

        return Ok(new
        {
            Token = token
        });
    }
}
