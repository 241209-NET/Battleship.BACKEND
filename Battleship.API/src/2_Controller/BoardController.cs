using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class BoardController : ControllerBase {

    private readonly IBoardService _boardService;

    public BoardController(IBoardService boardService) => _boardService = boardService;

    [HttpGet]
    public IActionResult GetBoardById(int id){
        try
        {
            var res = _boardService.GetBoardById(id);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpGet]
    [Route("{gameId}")]
    public IActionResult GetBoardsByGameId(int gameId){
        try
        {
            var res = _boardService.GetBoardsByGameId(gameId);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpPost]
    public IActionResult CreateNewBoard(Board b){
        try
        {
            var res = _boardService.CreateNewBoard(b);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }


}