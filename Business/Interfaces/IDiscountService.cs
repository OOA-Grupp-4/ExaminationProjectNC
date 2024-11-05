namespace Business.Interfaces
{
    public interface IDiscountService
    {
        bool IsValid(string discountCode);                
        decimal GetDiscountAmount(string discountCode);   
    }
}