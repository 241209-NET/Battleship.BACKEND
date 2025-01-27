using Battleship.API.Model;
using Battleship.API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Battleship.API.Repository;

public class BoardRepository : IBoardRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public BoardRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;

    public async Task<Board> GetBoardById(int id){
        return await _battleshipContext.Boards.FindAsync(id);
    }

    public async Task<List<Board>> GetBoardsByGameId(int id){
        return await _battleshipContext.Boards.Where(b => b.GameId == id ).ToListAsync();
    }

    public async Task<Board> CreateNewBoard(Board b){
        await _battleshipContext.Boards.AddAsync(b);
        await _battleshipContext.SaveChangesAsync();
        return b; 
    }

    
}