namespace UILayer;

public class ManagerMenu : IMenu
{
    private readonly IBusiness _bl;

    public ManagerMenu(IBusiness bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Enter a command: (A)dd Store -- Add (I)nventory -- Add (E)mployee -- (R)emove Employee -- (Q)uit");
            string input = InputValidation.ValidString();

            char command = input.Trim().ToUpper()[0];

            switch (command)
            {
                case ('A'):
                    AddStore();
                    break;

                case ('I'):
                    AddInventory();
                    break;

                case ('E'):
                    AddEmployee();
                    break;

                case ('R'):
                    RemoveEmployee();
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

    public StoreFront SelectStore()
    {
        Console.WriteLine("Select a store!");

        List<StoreFront> storeFronts = _bl.GetStoreFronts();

        if (storeFronts.Count == 0)
        {
            Console.WriteLine("There are no stores!");
        }

    SelectStore:
        for (int i = 0; i < storeFronts.Count; i++)
        {
            Console.WriteLine($"[{i}] {storeFronts[i].City}, {storeFronts[i].State}");
        }

        int index;

        if (Int32.TryParse(Console.ReadLine(), out index) && (index >= 0 && index < storeFronts.Count))
        {
            return storeFronts[index];
        }
        else
        {
            Console.WriteLine("Enter a valid index!");
            goto SelectStore;
        }
    }

    public void AddStore()
    {
        Console.WriteLine("Adding new store!");
        Console.WriteLine("Enter the city:");
        string city = InputValidation.ValidString().ToLower();
        Console.WriteLine("Enter the state(XX):");
        string state = InputValidation.ValidString().ToUpper();

        if (_bl.GetStore(city) == null)
        {
            StoreFront store = new StoreFront
            {
                City = city,
                State = state
            };
            _bl.AddStore(store);
        }
        else
        {
            Console.WriteLine("The city already exists!");
        }
    }

    public void AddInventory()
    {

    }

    public void AddEmployee()
    {

    }

    public void RemoveEmployee()
    {

    }
}