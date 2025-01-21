using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService) => _gameService = gameService;

    [HttpPost]
    public IActionResult CreateGame([FromBody] Game game)
    {
        try
        {
            var createdGame = _gameService.CreateGame(game);
            return Ok(createdGame);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAllGames()
    {
        var GameList = _gameService.GetAllGames();
        return Ok(GameList);
    }


    [HttpGet("id/{id}")]
    public IActionResult GetGameById(int id)
    {
        try
        {
            var foundGame = _gameService.GetGameById(id);
            return Ok(foundGame);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPatch]
    public IActionResult UpdateGame([FromBody] Game Game)
    {
        try
        {
            var updatedGame = _gameService.UpdateGame(Game);
            return Ok(updatedGame);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }
}
