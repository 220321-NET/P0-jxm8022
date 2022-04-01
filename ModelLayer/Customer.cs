namespace ModelLayer;

public static class Customer
{
    public static string _username = "";
    public static string UserName
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }
    public static bool Employee { get; set; } = false;
    public static int EmployeeID { get; set; }
    public static List<Order> Orders { get; set; } = new List<Order>();
}