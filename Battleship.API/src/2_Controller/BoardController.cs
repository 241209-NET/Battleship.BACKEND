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
    [Route("id/{id}")]
    public IActionResult GetBoardById(int id){
        try
        {
            var res = _boardService.GetBoardById(id);
            return OK(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpGet]
    [Route("id/{gameId}")]
    public IActionResult GetBoardsByGameId(int id){
        try
        {
            var res = _boardService.GetBoardsByGameId(id);
            return OK(res);
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
            return OK(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }


}