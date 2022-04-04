namespace UILayer;

public class HomeMenu : IMenu
{
    private readonly IBusiness _bl;
    private Customer _customer = new Customer();
    private StoreFront _store = new StoreFront();

    public HomeMenu(IBusiness bl)
    {
        _bl = bl;
    }

    public void Start()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Enter a command: (O)rder -- Order (H)istory -- (Q)uit");
            string input = InputValidation.ValidString();

            char command = input.Trim().ToUpper()[0];

            switch (command)
            {
                case ('O'):
                    Order();
                    break;

                case ('H'):
                    OrderHistory();
                    break;

                case ('Q'):
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Incorrect command!");
                    break;
            }
        }
    }

    public void Start(Customer customer)
    {
        _customer = customer;
        Start();
    }

    public void Start(Customer customer, StoreFront store)
    {
        _customer = customer;
        _store = store;
        Start();
    }

    public void Order()
    {
        MenuFactory.GetMenu("store").Start(_customer);
    }

    public void OrderHistory()
    {

    }
}