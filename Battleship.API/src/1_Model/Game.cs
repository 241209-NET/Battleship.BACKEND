using System;

namespace Battleship.API.Model;

public class Game
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public bool Status { get; set; }
    public bool PlayerTurn { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}
