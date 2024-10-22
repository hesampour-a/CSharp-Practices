using Library.Services.Users.Contracts;
using Library.Services.Users.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(UserService userService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var userDto = await userService.GetById(id);
        return Ok(userDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dtos = await userService.GetAll();
        return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto userDto)
    {
        var newUserId = await userService.CreateAsync(userDto);
        return CreatedAtAction(nameof(GetById), new { id = newUserId }, null);
    }
}