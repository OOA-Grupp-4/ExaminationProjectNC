using Business.Interfaces;

namespace Business.Services;

public class DiscountService : IDiscountService
{
    private readonly string _discountCode = "STOFFE10";
    private readonly decimal _discountAmount = 0.10m;

    public bool IsValid(string discountCode)
    {
        return discountCode == _discountCode;
    }

    public decimal GetDiscountAmount(string discountCode)
    {
        return IsValid(discountCode) ? _discountAmount : 0m;
    }

}
