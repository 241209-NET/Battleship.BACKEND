
using Battleship.API.Repository;
using Battleship.API.Model;
using Battleship.API.Exceptions;
namespace Battleship.API.Service;


public class BoardService : IBoardService 
{
    private readonly IBoardRepository _boardRepository;

    private readonly IGameRepository _gameRepository;

    public BoardService(IBoardRepository boardRepository, IGameRepository gameRepository){
        _boardRepository = boardRepository; 
        _gameRepository = gameRepository;
    }

    public Board GetBoardById(int id){
        return _boardRepository.GetBoardById(id) ?? throw new DoesNotExistException("Board Does Not Exist!");
    }

    public List<Board> GetBoardsByGameId(int id){
        if (_gameRepository.GetGameByID(id) == null) throw new DoesNotExistException("Game Does Not Exist!");
        return _boardRepository.GetBoardsByGameId(id);
    }

    public Board CreateNewBoard(Board b){
        return _boardRepository.CreateNewBoard(b);
    }
}