namespace Battleship.API.Model;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int NumWins { get; set; }
    public int NumLosses { get; set; }
}
