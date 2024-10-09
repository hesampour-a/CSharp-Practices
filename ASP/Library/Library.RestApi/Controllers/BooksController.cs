using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(BookService bookService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var book = await bookService.GetByIdAsync(id);
        return Ok(book);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] CreateBookDto bookDto)
    {
        var id = await bookService.CreateAsync(bookDto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}