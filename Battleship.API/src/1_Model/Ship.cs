namespace Battleship.API.Model
{
    public class Ship
    {
        public int Id { get; set; }
        public int BoardId { get; set; } // Foreign Key to Board
        public string Type { get; set; }
        public int Length { get; set; }
        public bool IsHorizontal { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
    }
}