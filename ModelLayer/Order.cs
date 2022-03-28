namespace ModelLayer;

public class Order
{
    public decimal OrderTotal { get; set; }
    public int OrderNumber { get; set; }
    public List<Product> Products { get; set; }
}