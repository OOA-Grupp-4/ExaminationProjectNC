namespace Business.Interfaces;

public interface IPaymentService
{
    public bool ProcessPayment(string paymentMethod);
}
