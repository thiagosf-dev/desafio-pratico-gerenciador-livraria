namespace GestaoLivraria.Communication.Resquests;

public class RequestUpdateBookJson
{
    public string Gender { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Stock { get; set; }
}
