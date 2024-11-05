using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;

public class PaymentService_Tests
{
    private readonly IPaymentService _paymentService;

    public PaymentService_Tests()
    {
        var paymentMethodFactory = new PaymentMethodFactory();
        _paymentService = new PaymentService(paymentMethodFactory);
    }

    #region Payment Tests
    [Fact]
    public void ProcessPayment_ShouldReturnTrue_WhenUsingCreditCard()
    {
        // Arrange
        string paymentMethod = "Kreditkort";

        // Act
        bool result = _paymentService.ProcessPayment(paymentMethod);

        // Assert
        Assert.True(result, "Kreditkortsbetalning lyckades");
    }

    [Fact]
    public void ProcessPayment_ShouldReturnTrue_WhenUsingPayPal()
    {
        // Arrange
        string paymentMethod = "PayPal";

        // Act
        bool result = _paymentService.ProcessPayment(paymentMethod);

        // Assert
        Assert.True(result, "PayPal-betalning lyckades");
    }

    [Fact]
    public void ProcessPayment_ShouldReturnTrue_WhenUsingSwish()
    {
        // Arrange
        string paymentMethod = "Swish";

        // Act
        bool result = _paymentService.ProcessPayment(paymentMethod);

        // Assert
        Assert.True(result, "Swish-betalning lyckades");
    }

    [Fact]
    public void ProcessPayment_ShouldReturnFalse_WhenUsingBitcoin()
    {
        // Arrange
        string paymentMethod = "Bitcoin";

        // Act
        bool result = _paymentService.ProcessPayment(paymentMethod);

        // Assert
        Assert.False(result, "Ogiltig betalningsmetod!");
    }
    #endregion

    #region Discount Tests
    [Fact]
    public void ApplyDiscount_ValidCode_ShouldApplyDiscount()
    {
        // Arrange
        var discountService = new DiscountService();
        discountService.AddDiscountCode("STOFFE10", 0.10m);

        var checkoutServiceFactory = new CheckoutServiceFactory(discountService);
        var checkoutService = checkoutServiceFactory.CreateCheckoutService();

        var product = new Product { Price = 100m };
        checkoutService.AddProduct(product);

        // Act
        checkoutService.ApplyDiscount("STOFFE10");

        // Assert
        var expectedTotal = 90m; 
        Assert.Equal(expectedTotal, checkoutService.GetTotal());
        Assert.Equal("Rabatt tillagd!", checkoutService.GetMessage());
    }
    #endregion
}
