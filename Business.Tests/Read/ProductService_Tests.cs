using Business.Models;
using Business.Services;

namespace Business.Tests.Read;

public class ProductServiceTests 
{
    #region Search Test
    [Fact]
    public void SearchProducts_ShouldReturnTrue_WhenKeywordIsCorrect()
    {
        // Arrange
        var productService = new ProductService();

        var product1 = new Product { ProductName = "Mobiltelefon" };
        var product2 = new Product { ProductName = "Smartphone" };

        productService.AddProduct(product1);
        productService.AddProduct(product2);

        // Act
        var searchKeyword = "mobil";
        var result = productService.SearchProducts(searchKeyword);

        // Assert
        Assert.Contains(product1, result); 
        Assert.DoesNotContain(product2, result); 
    }
    #endregion

    #region Review Test
    [Fact]
    public void AddReview_ShouldReturnTrue_WhenReviewIsAdded()
    {
        // Arrange
        var productService = new ProductService();
        var product = new Product { ProductName = "Mobiltelefon" };
        productService.AddProduct(product);

        var review = new Review
        {
            ProductName = "Mobiltelefon",
            Rating = 5,
            Comment = "Excellent phone!"
        };

        // Act
        var result = productService.AddReview("Mobiltelefon", review);
        var reviews = productService.GetReviews("Mobiltelefon");

        // Assert
        Assert.True(result); 
        Assert.Contains(review, reviews); 
    }
    #endregion
}