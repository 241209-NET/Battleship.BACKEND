using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API.Controller;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Battleship.API.Model;
using Battleship.API.Service;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    // Register a new user
    [HttpPost("/register")]
    public async Task<IActionResult> CreateNewUser(User newUser)
    {
        var trainer = await _userService.CreateUser(newUser);      

        return Ok(trainer);
    }

    // POST: api/User/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User userCredentials)
    {
        if (string.IsNullOrWhiteSpace(userCredentials.Username))
            return BadRequest("Username cannot be empty.");

        // 1) Look up user by username //Update the GetUserByUsername in Controller with GetUserWithToken
        var user = await _userService.GetUserByUsername(userCredentials.Username)!;
        if (user == null)
            return NotFound("User not found.");

        // 2) verify password
        if (user.Password != userCredentials.Password)
        {
            return Unauthorized("Invalid credentials.");
        }

        if (user != null)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Username", user.Username!.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
            );
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { Token = tokenValue, User = user });
        }
        return NoContent();
    }

    [HttpGet]

    public async Task<IActionResult> GetAllUsers(){
        try
        {
            var res = await _userService.GetAllUsers();
            return Ok(res);
        } 
        catch (Exception e)
        {
             return Conflict(e.Message);
        }
    }





}