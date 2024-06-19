using GestaoLivraria.Communication.Responses;
using GestaoLivraria.Communication.Resquests;
using GestaoLivraria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivraria.Controllers;

public class BookController : GestaoLivrariaBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredBookJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestRegisterBookJson book)
    {
        ResponseRegisteredBookJson newBook = new ResponseRegisteredBookJson();
        newBook.Book.Author = book.Author;
        newBook.Book.Gender = book.Gender;
        newBook.Book.Price = book.Price;
        newBook.Book.Stock = book.Stock;
        newBook.Book.Title = book.Title;
        newBook.Book.Id = "asd6q1d1331wqe1";
        GestaoLivrariaBaseController.Books.Add(newBook.Book);
        return Created(string.Empty, newBook.Book);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(GestaoLivrariaBaseController.Books);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] string id, [FromBody] RequestUpdateBookJson request)
    {
        if (request == null || request.Price <= 0 || request.Gender.Equals("")) return BadRequest("Dados da requisição inválidos!");

        var bookData = GestaoLivrariaBaseController.Books.FirstOrDefault(x => x.Id == id);

        if (bookData != null)
        {
            bookData.Gender = request.Gender;
            bookData.Price = request.Price;
            bookData.Stock = request.Stock;
            return Ok(bookData);
        }

        return NotFound("Não existe livro cadastrado com este ID!");
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] string id)
    {
        var bookToDelete = GestaoLivrariaBaseController.Books.FirstOrDefault(book => book.Id == id);

        if (bookToDelete == null) return NotFound("Não existe livro cadastrado com este ID!");

        GestaoLivrariaBaseController.Books.Remove(bookToDelete);

        return Ok("Livro excluído com sucesso!");
    }
}
