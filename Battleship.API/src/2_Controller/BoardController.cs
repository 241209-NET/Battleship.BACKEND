using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controller;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class BoardController : ControllerBase {

    private readonly IBoardService _boardService;

    public BoardController(IBoardService boardService) => _boardService = boardService;

    [HttpGet]
    public async Task<IActionResult> GetBoardById(int id){
        try
        {
            var res = await _boardService.GetBoardById(id);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpGet]
    [Route("{gameId}")]
    public async Task<IActionResult> GetBoardsByGameId(int gameId){
        try
        {
            var res = await _boardService.GetBoardsByGameId(gameId);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewBoard(Board b){
        try
        {
            var res = await _boardService.CreateNewBoard(b);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }


}