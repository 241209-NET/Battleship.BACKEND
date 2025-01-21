
using Battleship.API.Repository;
using Battleship.API.Model;
namespace Battleship.API.Service;


public class BoardService : IBoardService 
{
    private readonly IBoardRepository _boardRepository;

    public BoardService(IBoardRepository boardRepository){
        _boardRepository = boardRepository; 
    }

}