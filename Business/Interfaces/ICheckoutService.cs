using Business.Models;

namespace Business.Interfaces;

public interface ICheckoutService
{
    void AddProduct(Product product);
    void ApplyDiscount(string discountCode); 
    decimal GetTotal();                     
    string GetMessage();                    

}