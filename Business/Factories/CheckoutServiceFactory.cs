using Business.Interfaces;
using Business.Models;
using Business.Services;

namespace Business.Factories;

public class CheckoutServiceFactory
{
    private readonly IDiscountService _discountService;
    //public CheckoutService CreateCheckoutServiceWithDiscounts(List<Discount> discounts)
    //{
    //    var discountService = new DiscountService();

    //    foreach (var discount in discounts)
    //        discountService.AddDiscountCode(discount.Code, discount.Amount);


    //    return new CheckoutService(discountService);
    //}

    public CheckoutServiceFactory(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public CheckoutService CreateCheckoutService()
    {
        return new CheckoutService(_discountService);
    }
}
