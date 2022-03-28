namespace ModelLayer;

public class StoreFront
{
    public StoreFront(Customer customer)
    {
        _customer = customer;
    }
    private Customer _customer;
    public Customer User
    {
        get => _customer;
        set
        {
            _customer = value;
        }
    }
    public void Home()
    {
        Console.Clear();
        Greeting();
    }

    public void DisplayProducts()
    {
        //call business layer
    }

    public void Greeting()
    {
        Console.WriteLine($"Greetings {User.UserName}!");
    }
}