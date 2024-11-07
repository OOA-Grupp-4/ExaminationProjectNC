using Business.Factories;
using Business.Interfaces;

namespace Business.Services;

public class PaymentService(PaymentMethodFactory paymentMethodFactory) : IPaymentService
{
    private readonly PaymentMethodFactory _paymentMethodFactory = paymentMethodFactory;

    public bool ProcessPayment(string paymentMethod)
    {
        var method = PaymentMethodFactory.CreatePaymentMethod(paymentMethod);
        if (method != null)
            return method.ProcessPayment();
        else
            return false;
    }
}
