using System.Threading.Tasks;
using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controller;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ShipController : ControllerBase
{
    private readonly IShipService _shipService;

    public ShipController(IShipService shipService) => _shipService = shipService;

    [HttpPost]
    public async Task<IActionResult> CreateShip([FromBody] Ship ship)
    {
        try
        {
            var createdShip = await _shipService.CreateShip(ship);
            return Ok(createdShip);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllShips()
    {
        var shipList = await _shipService.GetAllShip();
        return Ok(shipList);
    }


    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetShipById(int id)
    {
        try
        {
            var foundShip = await _shipService.GetShipById(id);
            return Ok(foundShip);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateShip([FromBody] Ship ship)
    {
        try
        {
            var updatedShip = await _shipService.UpdateShip(ship);
            return Ok(updatedShip);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }


}