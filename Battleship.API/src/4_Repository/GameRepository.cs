using Battleship.API.Model;
using Battleship.API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Battleship.API.Repository;

public class GameRepository : IGameRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public GameRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;

    public async Task<Game> CreateGame(Game game)
    {
        await _battleshipContext.Games.AddAsync(game);
        await _battleshipContext.SaveChangesAsync();
        return game;
    }

    public async Task<IEnumerable<Game>> GetAllGames()
    {
        return await _battleshipContext.Games.ToListAsync();
    }

    public async Task<Game> GetGameById(int id)
    {
        var game = await _battleshipContext.Games.FindAsync(id);
        return game;
    }

    public async Task<Game> UpdateGame(Game game)
    {
        _battleshipContext.Games.Update(game);
        await _battleshipContext.SaveChangesAsync();
        return game;
    }
}