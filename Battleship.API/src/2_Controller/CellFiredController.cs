using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controller;

[Route("api/[controller]")]
[ApiController]

public class CellFiredContoller : ControllerBase{
    private readonly ICellFiredService _cellFiredService;

    public CellFiredContoller(ICellFiredService cellFiredService) => _cellFiredService = cellFiredService;


    [HttpGet]
    [Route("id/{id}")]
    public IActionResult GetCellById(int id){
        
        try 
        {
            var res = _cellFiredService.GetCellById(id);
            return OK(res);
        }
        catch (Exception e)
        {
            return Confilct(e);
        }
    }

    [HttpPost]
    public IActionResult NewCellFired(CellFired cell){
        
        try
        {
            var res = _cellFiredService.NewCellFired(cell);
            return OK(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpGet]
    public IActionResult GetAllFiredCells(){
        try
        {
            var res = _cellFiredService.GetAllFiredCells();
            return OK(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpGet]
    [Route("id/{boardId}")]
    public IActionResult GetAllFiredCellsByBoardId(int boardId){
        try
        {
            var res = _cellFiredService.GetAllFiredCellsByBoardId(boardId);
            return OK(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpPatch]
    public IActionResult UpdateCell(CellFired cell){
        try
        {
            var res = _cellFiredService.UpdateCell(cell);
            return OK(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

}