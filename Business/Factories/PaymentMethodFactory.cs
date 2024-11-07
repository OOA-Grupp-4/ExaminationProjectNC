using Business.Interfaces;
using Business.Services;

namespace Business.Factories;

public class PaymentMethodFactory
{
    public static IPaymentMethod CreatePaymentMethod(string paymentMethod)
    {
        return paymentMethod switch
        {
            "Kreditkort" => new CreditCardPayment(),
            "PayPal" => new PayPalPayment(),
            "Swish" => new SwishPayment(),
            _ => null!,
        };
    }
}
