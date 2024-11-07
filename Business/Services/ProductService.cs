using Business.Models;

namespace Business.Services;

public class ProductService()
{
    private readonly List<Product> _products;

    public ProductService()
    {
        _products = []; 
    }
}
//HÄR SKA VI GÖRA TESTET FÖR Som en användare vill jag kunna söka produkter med nyckelord så att jag snabbt kan hitta det jag letar efter.!!!!!!!!