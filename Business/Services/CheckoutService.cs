using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class CheckoutService : ICheckoutService
{
    private readonly IDiscountService _discountService;
    private readonly List<Product> _products = [];
    private decimal _total;
    private string? _message;

    public CheckoutService(IDiscountService discountService)
    {
           _discountService = discountService;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
        _total += product.Price;
    }

    public void ApplyDiscount(string discountCode)
    {
        if (_discountService.IsValid(discountCode))
        {
            var discountAmount = _discountService.GetDiscountAmount(discountCode);
            _total -= _total * discountAmount;
            _message = "Rabatt tillagd!";
        }
        else
            _message = "Ogiltig rabattkod.";

    }

    public string GetMessage()
    {
        return _message!;
    }

    public decimal GetTotal()
    {
        return _total;
    }
}
