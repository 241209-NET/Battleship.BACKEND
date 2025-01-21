using Battleship.API.Model;
using Battleship.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ShipController : ControllerBase
{
    private readonly IShipService _shipService;

    public ShipController(IShipService shipService) => _shipService = shipService;

    [HttpPost]
    public IActionResult CreateShip([FromBody] Ship ship)
    {
        try
        {
            var createdShip = _shipService.CreateShip(ship);
            return Ok(createdShip);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAllShips()
    {
        var shipList = _shipService.GetAllShip();
        return Ok(shipList);
    }


    [HttpGet("id/{id}")]
    public IActionResult GetShipById(int id)
    {
        try
        {
            var foundShip = _shipService.GetShipById(id);
            return Ok(foundShip);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPatch]
    public IActionResult UpdateShip([FromBody] Ship ship)
    {
        try
        {
            var updatedShip = _shipService.UpdateShip(ship);
            return Ok(updatedShip);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }


}