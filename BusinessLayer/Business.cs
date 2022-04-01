namespace BusinessLayer;

public class Business : IBusiness
{
    private readonly IRepository _repo;

    public Business(IRepository repo)
    {
        _repo = repo;
    }

    public void AddCustomer(Customer customer)
    {
        _repo.AddCustomer(customer);
    }

    public Customer GetCustomer(string username)
    {
        return _repo.GetCustomer(username);
    }
}