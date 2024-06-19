using GestaoLivraria.Entities;

namespace GestaoLivraria.Communication.Responses;

public class ResponseRegisteredBookJson
{
    public Book Book { get; set; } = new Book();
}
