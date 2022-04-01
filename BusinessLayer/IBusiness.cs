namespace BusinessLayer;

public interface IBusiness
{
    void AddCustomer(Customer customer);
    Customer GetCustomer(string username);
}