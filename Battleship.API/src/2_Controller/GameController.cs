using System.Security.Claims;
using System.Threading.Tasks;
using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace Battleship.API.Controller;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IHttpContextAccessor _http; 

    public GameController(IGameService gameService, IHttpContextAccessor http)
    {
        _gameService = gameService;
        _http = http; 
    }

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
        try{
            ClaimsPrincipal user = _http.HttpContext.User;
            string userID = user.Claims.First(x => x.Type == "UserID").Value; 
            var GameList = await _gameService.GetAllGames(userID);
            return Ok(GameList);
        }catch{
             return Unauthorized(); 
        }

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
