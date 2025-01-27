using Microsoft.EntityFrameworkCore;
using Battleship.API.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Battleship.API.Data;

public class BattleshipContext : IdentityDbContext<User>
{
    public BattleshipContext(){}
    public BattleshipContext(DbContextOptions<BattleshipContext> options)
        : base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        
    }

    //public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Ship> Ships { get; set; }
    public DbSet<CellFired> CellFired { get; set; }
    public DbSet<Board> Boards { get; set; }

}