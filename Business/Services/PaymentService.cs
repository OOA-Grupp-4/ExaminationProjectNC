using Business.Interfaces;

namespace Business.Services
{
    public class PaymentService : IPaymentService
    {
        public bool ProcessPayment(string paymentMethod)
        {
            if (paymentMethod == "Kreditkort" || paymentMethod == "PayPal" || paymentMethod == "Swish")
            {
                Console.WriteLine($"{paymentMethod}-betalning behandlas.");
                return true;
            }
            else
            {
                Console.WriteLine("Ogiltig betalningsmetod.");
                return false;
            }
        }
    }
}
