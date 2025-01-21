namespace Battleship.API.Model;

public class CellFired
{
    public int Id {get;set;}
    public int X { get; set; }
    public int Y { get; set; }
    public int BoardId { get; set; }
    public string Status { get; set; }
}
