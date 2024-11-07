namespace Business.Models;

public class Discount(string code, decimal amount)
{
    public string Code { get; set; } = code;
    public decimal Amount { get; set; } = amount;
}
