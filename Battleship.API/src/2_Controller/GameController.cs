using System.Threading.Tasks;
using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controller;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService) => _gameService = gameService;

    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] Game game)
    {
        try
        {
            var createdGame = await _gameService.CreateGame(game);
            return Ok(createdGame);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGames()
    {
        var GameList = await _gameService.GetAllGames();
        return Ok(GameList);
    }


    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetGameById(int id)
    {
        try
        {
            var foundGame = await _gameService.GetGameById(id);
            return Ok(foundGame);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateGame([FromBody] Game Game)
    {
        try
        {
            var updatedGame = await _gameService.UpdateGame(Game);
            return Ok(updatedGame);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }
}
