namespace DataLayer;
public interface IRepository
{
    void AddCustomer(Customer customer);
    Customer GetCustomer(string username);
}
