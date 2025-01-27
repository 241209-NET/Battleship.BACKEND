
using Battleship.API.Repository;
using Battleship.API.Model;
using Battleship.API.Exceptions;
using System.Threading.Tasks;
namespace Battleship.API.Service;


public class BoardService : IBoardService 
{
    private readonly IBoardRepository _boardRepository;

    private readonly IGameRepository _gameRepository;

    public BoardService(IBoardRepository boardRepository, IGameRepository gameRepository){
        _boardRepository = boardRepository; 
        _gameRepository = gameRepository;
    }

    public async Task<Board> GetBoardById(int id){
        return await _boardRepository.GetBoardById(id) ?? throw new DoesNotExistException("Board Does Not Exist!");
    }

    public async Task<List<Board>> GetBoardsByGameId(int id){
        if (await _gameRepository.GetGameById(id) == null) throw new DoesNotExistException("Game Does Not Exist!");
        return await _boardRepository.GetBoardsByGameId(id);
    }

    public async Task<Board> CreateNewBoard(Board b){
        return await _boardRepository.CreateNewBoard(b);
    }
}