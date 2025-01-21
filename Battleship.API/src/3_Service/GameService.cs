using Battleship.API.Repository;
using Battleship.API.Model;

namespace Battleship.API.Service;

public class GameService : IGameService 
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository){
        _gameRepository = gameRepository; 
    }

}