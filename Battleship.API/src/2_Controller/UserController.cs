using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API.Controller;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Identity;
using Battleship.API.DTO;
using System.ComponentModel;
using System.Net.Sockets;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _http; 

    public UserController(IUserService userService, IConfiguration configuration, IHttpContextAccessor http)
    {
        _userService = userService;
        _configuration = configuration;
        _http = http; 
    }

    [HttpPost("/register")]
    public async Task<IActionResult> SignUp(UserManager<User> userManager, UserRegisterDTO userRegister)
    {
        User addUser = new User(){UserName = userRegister.Email, Email = userRegister.Email, AccountName = userRegister.AccountName }; 
        var result = await userManager.CreateAsync(addUser, userRegister.Password);
        if (result.Succeeded)
            return Ok(result); 
        else
            return BadRequest(result);
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login(UserManager<User> userManager, UserLoginDTO userLoginDTO){
  
        var userLogin = await userManager.FindByEmailAsync(userLoginDTO.Email); 

        //If the user exists
        if(userLogin is not null)
        {
            //And if the password matches
            if(await userManager.CheckPasswordAsync(userLogin, userLoginDTO.Password))
            {
                //return the JWT
                var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:JWTSecret"]!)); 
                
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", userLogin.Id.ToString()),
                        new Claim("UserAccount", userLogin.AccountName.ToString())
                    }), 
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(
                        signInKey,
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };
                var tokenHandler = new JwtSecurityTokenHandler(); 
                var securityToken = tokenHandler.CreateToken(tokenDescriptor); 
                var token = tokenHandler.WriteToken(securityToken); 
                return Ok(new {token}); 
            }else{
                return BadRequest(new {message = "Username or password is incorrect"}); 

            }
        } else{
                return BadRequest(new {message = "Username or password is incorrect"}); 
            }
        
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

    [HttpGet("/Score")]
    public async Task<IActionResult> GetCurrentUserScore(){
        try
        {
            ClaimsPrincipal user = _http.HttpContext.User;
            string userID = user.Claims.First(x => x.Type == "UserID").Value; 

            var res = await _userService.GetUserById(userID);
            UserScoreDTO score = new UserScoreDTO(){Wins = res.NumWins, Losses = res.NumLosses}; 
            return Ok(score);
        } 
        catch (Exception e)
        {
             return Conflict(e.Message);
        }
    }

    // [HttpGet("{username}")]
    // public IActionResult GetAccountInfo(string username)
    // {
    //     try
    //     {
    //         var userInfo = _userService.GetUserByUsername(username);
    //         return Ok(userInfo);
    //     }
    //     catch (Exception ex)
    //     {
    //         return Conflict(ex.Message);
    //     }
    // }









}