namespace Business.Interfaces
{
    public interface IDiscountService
    {
        public bool IsValid(string discountCode);                
        public decimal GetDiscountAmount(string discountCode);   
    }
}