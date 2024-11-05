namespace Business.Models;

public class Discount
{
    public string Code { get; set; }
    public decimal Amount { get; set; }

    public Discount(string code, decimal amount)
    {
        Code = code;
        Amount = amount;
    }
}
