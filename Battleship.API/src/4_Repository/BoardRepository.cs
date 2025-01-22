using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class BoardRepository : IBoardRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public BoardRepository (BattleshipContext battleshipContext)
        => _battleshipContext = battleshipContext;

    public Board GetBoardById(int id){
        return _battleshipContext.Boards.Find(id);
    }

    public List<Board> GetBoardsByGameId(int id){
        return _battleshipContext.Boards.Where(b => b.GameId == id ).ToList();
    }

    public Board CreateNewBoard(Board b){
        _battleshipContext.Boards.Add(b);
        _battleshipContext.SaveChanges();
        return b; 
    }

    
}