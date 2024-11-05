using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class DiscountService : IDiscountService
{
    private readonly List<Discount> _discounts = new()
    {
        new Discount("STOFFE10", 0.10m),
        new Discount("TIGER20", 0.20m)
    };

    public bool IsValid(string discountCode)
    {
        return _discounts.Any(x => x.Code == discountCode);
    }

    public decimal GetDiscountAmount(string discountCode)
    {
        var discount = _discounts.FirstOrDefault(x => x.Code == discountCode);
        return discount != null ? discount.Amount : 0m;
    }

    public void AddDiscountCode(string code, decimal amount)
    {
        if (!_discounts.Any(x => x.Code == code))
        {
            _discounts.Add(new Discount(code, amount));
        }
    }
}
