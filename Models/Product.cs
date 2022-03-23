// namespace Telescopes;

public class Product
{
    public Product()
    {
        _productName = "";
    }

    public Product(string productName) : this()
    {
        _productName = productName;
    }
    private string _productName;
    public string ProductName
    {
        get
        {
            return _productName;
        }
        set
        {
            _productName = value;
        }
    }
    public decimal ProductPrice { get; set; }
    public int ProductStock { get; set; }
}