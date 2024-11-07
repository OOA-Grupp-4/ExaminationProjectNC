using System;
using Business.Interfaces;

namespace Business.Services;

public class CreditCardPayment : IPaymentMethod
{
    public bool ProcessPayment()
    {
        Console.WriteLine("Kreditkort-betalning behandlas.");
        return true;
    }
}

public class PayPalPayment : IPaymentMethod
{
    public bool ProcessPayment()
    {
        Console.WriteLine("PayPal-betalning behandlas.");
        return true;
    }
}

public class SwishPayment : IPaymentMethod
{
    public bool ProcessPayment()
    {
        Console.WriteLine("Swish-betalning behandlas.");
        return true;
    }
}