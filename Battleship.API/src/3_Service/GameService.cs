using Battleship.API.Repository;
using Battleship.API.Model;

namespace Battleship.API.Service;

public class GameService : IGameService 
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository){
        _gameRepository = gameRepository; 
    }

    public async Task<Game> CreateGame(Game game)
    {
        var savedGame = await _gameRepository.CreateGame(game);
        return savedGame;
    }

    public async Task<IEnumerable<Game>> GetAllGames()
    {
        var games = await _gameRepository.GetAllGames();
        return games;
    }

    public async Task<Game> GetGameById(int id)
    {
        var foundGame = await _gameRepository.GetGameById(id) ?? throw new Exception("This game ID does not exist!");
        return foundGame;
    }

    public async Task<Game> UpdateGame(Game game)
    {
        var gametoUpdate = await GetGameById(game.Id);
        gametoUpdate.Status = game.Status;
        gametoUpdate.PlayerTurn = game.PlayerTurn;
        gametoUpdate.StartTime = game.StartTime;
        gametoUpdate.EndTime = game.EndTime;
        _gameRepository.UpdateGame(gametoUpdate);
        return gametoUpdate;
    }
}