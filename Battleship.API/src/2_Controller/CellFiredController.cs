using System.Threading.Tasks;
using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controller;

[Route("api/CellFired")]
[ApiController]

public class CellFiredContoller : ControllerBase{
    private readonly ICellFiredService _cellFiredService;

    public CellFiredContoller(ICellFiredService cellFiredService) => _cellFiredService = cellFiredService;


    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCellById(int id){
        
        try 
        {
            var res = await _cellFiredService.GetCellById(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> NewCellFired(CellFired cell){
        
        try
        {
            var res = await _cellFiredService.NewCellFired(cell);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFiredCells(){
        try
        {
            var res = await _cellFiredService.GetAllFiredCells();
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpGet]
    [Route("Board/{boardId}")]
    public async Task<IActionResult> GetAllFiredCellsByBoardId(int boardId){
        try
        {
            var res = await _cellFiredService.GetAllFiredCellsByBoardId(boardId);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCell(CellFired cell){
        try
        {
            var res = await _cellFiredService.UpdateCell(cell);
            return Ok(res);
        } 
        catch (Exception e)
        {
            return Conflict(e);
        }
    }

}