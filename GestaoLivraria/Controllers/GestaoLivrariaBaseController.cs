using GestaoLivraria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivraria.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class GestaoLivrariaBaseController : ControllerBase
{
    public static List<Book> Books { get; private set; } = new List<Book>();

    [HttpGet("status")]
    public IActionResult Heathy()
    {
        return Ok("It´s working!");
    }
}
