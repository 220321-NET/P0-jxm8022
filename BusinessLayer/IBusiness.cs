namespace BusinessLayer;

public interface IBusiness
{
    void AddCustomer(Customer customer);
    Customer GetCustomer(string username);
    List<Customer> GetAllCustomers(bool employee);
    void UpdateCustomer(Customer customer);
    void AddStore(StoreFront store);
    StoreFront GetStore(string city);
    List<StoreFront> GetStoreFronts();
}