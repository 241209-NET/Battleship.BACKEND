namespace Battleship.API.Model;

public class Board
{
    public int Id { get; set; }
    public int GameId { get; set; } // Foreign Key to Game
    public string UserId { get; set; } // Foreign Key to User
    public bool IsComputerBoard { get; set; }
}
