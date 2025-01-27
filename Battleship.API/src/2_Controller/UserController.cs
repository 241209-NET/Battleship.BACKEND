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

        if(userLogin is not null)
        {
            if(await userManager.CheckPasswordAsync(userLogin, userLoginDTO.Password)){
                //return the JWT
                var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:JWTSecret"]!)); 
                
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        //new Claim("UserID", userLogin.Id.ToString()) //Do we need the id? 
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

<<<<<<< Updated upstream
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
=======
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




>>>>>>> Stashed changes





}