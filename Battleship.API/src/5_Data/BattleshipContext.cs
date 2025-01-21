using Microsoft.EntityFrameworkCore;
using Battleship.API.Model;

namespace Battleship.API.Data;

public class BattleshipContext : DbContext
{
    public BattleshipContext(){}
    public BattleshipContext(DbContextOptions<BattleshipContext> options)
        : base(options){}

    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Ship> Ships { get; set; }
    public DbSet<CellFired> CellFired { get; set; }
    public DbSet<Board> Boards { get; set; }

}