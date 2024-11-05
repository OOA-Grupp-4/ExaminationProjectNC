using System;
using Business.Interfaces;

namespace Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentMethodFactory _paymentMethodFactory;

        public PaymentService(PaymentMethodFactory paymentMethodFactory)
        {
            _paymentMethodFactory = paymentMethodFactory;
        }

        public bool ProcessPayment(string paymentMethod)
        {
            var method = _paymentMethodFactory.CreatePaymentMethod(paymentMethod);
            if (method != null)
            {
                return method.ProcessPayment();
            }
            else
            {
                Console.WriteLine("Ogiltig betalningsmetod.");
                return false;
            }
        }
    }
}
