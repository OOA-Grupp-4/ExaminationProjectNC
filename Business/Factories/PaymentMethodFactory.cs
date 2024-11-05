using Business.Interfaces;

namespace Business.Services;

public class PaymentMethodFactory
{
    public IPaymentMethod CreatePaymentMethod(string paymentMethod)
    {
        switch (paymentMethod)
        {
            case "Kreditkort":
                return new CreditCardPayment();
            case "PayPal":
                return new PayPalPayment();
            case "Swish":
                return new SwishPayment();
            default:
                return null!;
        }
    }
}
