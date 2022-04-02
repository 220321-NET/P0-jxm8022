namespace UILayer;

public class HomeMenu : IMenu
{
    private readonly IBusiness _bl;

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

    public void Order()
    {

    }

    public void OrderHistory()
    {

    }
}