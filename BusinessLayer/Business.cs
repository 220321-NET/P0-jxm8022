namespace BusinessLayer;

public class Business : IBusiness
{
    private readonly IRepository _repo;

    public Business(IRepository repo)
    {
        _repo = repo;
    }

    public void AddCustomer()
    {
        _repo.AddCustomer();
    }

    public void GetCustomer(string username)
    {
        _repo.GetCustomer(username);
    }
}