namespace ModelLayer;

public class Customer
{
    public Customer()
    {
        _firstName = "";
    }

    public Customer(string firstName)
    {
        _firstName = firstName;
    }
    private string _firstName;
    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            _firstName = value;
        }
    }
}