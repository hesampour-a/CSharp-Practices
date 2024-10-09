using Library.Application.Lends.ReturnLends.Contracts;
using Library.Services.Lends.Contracts;
using Library.Services.Lends.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LendsController(
    LendsService lendsService,
    ReturnLendHandler returnLendHandler) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var lendDto = await lendsService.GetByIdAsync(id);
        return Ok(lendDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? bookId,
        [FromQuery] int? userId)
    {
        var lendDtos = await lendsService.GetAllAsync(bookId, userId);
        return Ok(lendDtos);
    }

    [HttpGet("Actives")]
    public async Task<IActionResult> GetAllActives([FromQuery] int? bookId,
        [FromQuery] int? userId)
    {
        var lendDtos = await lendsService.GetAllActivesAsync(bookId, userId);
        return Ok(lendDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateLendDto lendDto)
    {
        var newLendId = await lendsService.CreateAsync(lendDto);
        return CreatedAtAction(nameof(GetById), new { id = newLendId },
            null);
    }

    [HttpPatch("{id}/ReturnBook")]
    public async Task<IActionResult> ReturnLend([FromRoute] int id,
        [FromBody] ReturnLendDto lendDto)
    {
        await returnLendHandler.ReturnLendAsync(id, lendDto);
        return Ok();
    }
}