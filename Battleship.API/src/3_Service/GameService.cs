using Battleship.API.Repository;
using Battleship.API.Model;

namespace Battleship.API.Service;

public class GameService : IGameService 
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository){
        _gameRepository = gameRepository; 
    }

    public Game CreateGame(Game game)
    {
        var savedGame = _gameRepository.CreateGame(game);
        return savedGame;
    }

    public IEnumerable<Game> GetAllGames()
    {
        return _gameRepository.GetAllGames();
    }

    public Game GetGameById(int id)
    {
        var foundGame = _gameRepository.GetGameById(id);
        if(foundGame is null)
            throw new Exception("This game ID does not exist!");
        return foundGame;
    }

    public Game UpdateGame(Game game)
    {
        var gametoUpdate = GetGameById(game.Id);
        gametoUpdate.Status = game.Status;
        gametoUpdate.PlayerTurn = game.PlayerTurn;
        gametoUpdate.StartTime = game.StartTime;
        gametoUpdate.EndTime = game.EndTime;
        _gameRepository.UpdateGame(gametoUpdate);
        return gametoUpdate;
    }
}