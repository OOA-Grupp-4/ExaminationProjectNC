using Business.Interfaces;
using Business.Models;
using Business.Services;

namespace Business.Factories;

public class CheckoutServiceFactory
{
    private readonly IDiscountService _discountService;

    public CheckoutServiceFactory(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public CheckoutService CreateCheckoutService()
    {
        return new CheckoutService(_discountService);
    }
}
