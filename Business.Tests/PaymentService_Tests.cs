using Business.Interfaces;
using Business.Services;

public class PaymentService_Tests
{
    private readonly IPaymentService _paymentService;

    public PaymentService_Tests()
    {
        _paymentService = new PaymentService();
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

}
