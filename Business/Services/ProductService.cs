using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products;
    private readonly Dictionary<string, List<Review>> _reviews = new Dictionary<string, List<Review>>();


    public ProductService()
    {
        _products = [];
    }

    public bool AddProduct(Product product)
    {
        if (product == null || string.IsNullOrWhiteSpace(product.ProductName))
            return false;

        _products.Add(product);
        return true;
    }

    public List<Product> SearchProducts(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return new List<Product>();

        keyword = keyword.ToLower();
        return _products
            .Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public bool AddReview(string productName, Review review)
    {
        if (!_products.Any(p => p.ProductName.Equals(productName, System.StringComparison.OrdinalIgnoreCase))
            || review == null
            || review.Rating < 1
            || review.Rating > 5)

            return false;


        if (!_reviews.ContainsKey(productName))
            _reviews[productName] = [];

        _reviews[productName].Add(review);
        return true;
    }

    public List<Review> GetReviews(string productName)
    {
        return _reviews.ContainsKey(productName) ? _reviews[productName] : [];
    }
}


