namespace ModelLayer;

public class StoreFront
{
    public int StoreID { get; set; }

    public string City { get; set; } = "";

    public string State { get; set; } = "";

    List<Product> Inventory { get; set; } = new List<Product>();
}