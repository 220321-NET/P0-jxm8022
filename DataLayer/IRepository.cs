namespace DataLayer;
public interface IRepository
{
    void AddCustomer(Customer customer);
    Customer GetCustomer(string username);
    void AddStore(StoreFront storeFront);
    StoreFront GetStore(string city);
    List<StoreFront> GetStoreFronts();
}
