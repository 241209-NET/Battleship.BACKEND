using Battleship.API.Model; 

namespace Battleship.API.DTO; 

public class UserRegisterDTO
{
    public required string AccountName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class UserLoginDTO
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}