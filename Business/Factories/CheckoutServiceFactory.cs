using Business.Interfaces;
using Business.Services;

namespace Business.Factories;

public class CheckoutServiceFactory(IDiscountService discountService)
{
    private readonly IDiscountService _discountService = discountService;

    public CheckoutService CreateCheckoutService()
    {
        return new CheckoutService(_discountService);
    }
}
