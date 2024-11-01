namespace Business.Interfaces
{
    public interface IPaymentService
    {
        bool ProcessPayment(string paymentMethod);
    }
}
