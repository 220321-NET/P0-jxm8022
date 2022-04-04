namespace UILayer;

public class ManagerMenu : IMenu
{
    private readonly IBusiness _bl;
    private Customer _customer = new Customer();
    private StoreFront _store = new StoreFront();

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
        Console.WriteLine("Adding inventory to store!");
        _store = HelperFunctions.SelectStore(_bl);
        if (_store != null)
        {
            MenuFactory.GetMenu("store").Start(_customer, _store);
        }
    }

    public Customer SelectEmployee(bool employee)
    {
        Console.WriteLine("Select a person!");

        List<Customer> customers = _bl.GetAllCustomers(employee);

        if (customers == null || customers.Count == 0)
        {
            Console.WriteLine("There are no customers!");
            return null!;
        }

    SelectEmployee:
        for (int i = 0; i < customers.Count; i++)
        {
            Console.WriteLine($"[{i}] {customers[i].UserName}");
        }

        int index;

        if (Int32.TryParse(Console.ReadLine(), out index) && (index >= 0 && index < customers.Count))
        {
            return customers[index];
        }
        else
        {
            Console.WriteLine("Enter a valid index!");
            goto SelectEmployee;
        }
    }

    public void AddEmployee()
    {
        bool employee = false;
        Console.WriteLine("Adding an employee!");
        Customer customer = SelectEmployee(employee);
        if (customer != null)
        {
            _bl.UpdateCustomer(customer);
        }
    }

    public void RemoveEmployee()
    {
        bool employee = true;
        Console.WriteLine("Removing an employee!");
        Customer customer = SelectEmployee(employee);
        if (customer != null)
        {
            if (customer.UserName == _customer.UserName)
            {
                Console.WriteLine("Cannot remove yourself!");
            }
            else
            {
                _bl.UpdateCustomer(customer);
            }
        }
    }
}