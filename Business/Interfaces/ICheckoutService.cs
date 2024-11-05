using Business.Models;

namespace Business.Interfaces;

public interface ICheckoutService
{
    public void AddProduct(Product product);
    public void ApplyDiscount(string discountCode); 
    public decimal GetTotal();                     
    public string GetMessage();                    

}