using CodeFirst.DTO;
using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbservice _dbService;
    public PrescriptionController(IDbservice dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("/characters/{idCharacter}")]
    public async Task<IActionResult> GetCharactersData(int idCharacter)
    {
        if (!await _dbService.DoesCharacterExists(idCharacter))
        {
            return NotFound("nie istnieje");
        }

        var CharactersItems = _dbService.GetCharacterItems(idCharacter);

        return Ok(CharactersItems);


    }

    [HttpPost("/characters/{idCharacter}")]
    public async Task<IActionResult> AddItemsToCharacter(int idCharacter, int itemId)

    {
        if (!await _dbService.DoesCharacterExists(idCharacter))
        {
            return NotFound("nie istnieje");
        }

        if (!await _dbService.DoesItemExist(itemId))
        {
            return NotFound("no Items");
        }

        _dbService.addToBackpack(idCharacter,itemId,1);
        
        return Created();

    }

}