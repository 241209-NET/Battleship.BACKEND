using Microsoft.AspNetCore.Identity;

namespace Battleship.API.Model;

public class User : IdentityUser
{
    public string? AccountName { get; set; }
    public int NumWins { get; set; }
    public int NumLosses { get; set; }
}
