namespace BusinessLayer;

public interface IBusiness
{
    void AddCustomer(Customer customer);
    Customer GetCustomer(string username);
    void AddStore(StoreFront store);
    StoreFront GetStore(string city);
    List<StoreFront> GetStoreFronts();
}