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

    public void AddStore(StoreFront storeFront)
    {
        _repo.AddStore(storeFront);
    }

    public StoreFront GetStore(string city)
    {
        return _repo.GetStore(city);
    }

    public List<StoreFront> GetStoreFronts()
    {
        return _repo.GetStoreFronts();
    }
}