using Business.Models;

namespace Business.Interfaces;

public interface IProductService
{
    public bool AddProduct(Product product);
    public List<Product> SearchProducts(string keyword);
    public bool AddReview(string productName, Review review);
    public List<Review> GetReviews(string productName);

}