namespace UILayer;

public class StoreMenu : IMenu
{
    private readonly IBusiness _bl;
    private Customer _customer = new Customer();
    private StoreFront _store = new StoreFront();

    public StoreMenu(IBusiness bl)
    {
        _bl = bl;
    }

    public void Start()
    {
        if (_customer.Employee)
        {
            ManagerStoreMenu();
        }
        else
        {
            CustomerStoreMenu();
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

    public void CustomerStoreMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Enter a command: (A)dd Product -- (C)art -- (Q)uit");
            string input = InputValidation.ValidString();

            char command = input.Trim().ToUpper()[0];

            switch (command)
            {
                case ('A'):
                    AddProducttoCart();
                    break;

                case ('C'):
                    Cart();
                    exit = !exit;
                    break;

                case ('Q'):
                    exit = !exit;
                    _customer.Cart.Clear();
                    break;

                default:
                    Console.WriteLine("Incorrect command!");
                    break;
            }
        }
    }

    public void AddProducttoCart()
    {
        Product product = HelperFunctions.SelectProduct(_bl);
        if (product != null)
        {
            Console.WriteLine("Amount to add:");
            product.ProductQuantity = InputValidation.ValidInteger();
            if (product.ProductQuantity > 0)
            {
                _customer.Cart.Add(product);
            }
        }
    }

    public void Cart()
    {
        decimal cartTotal = new decimal();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=====================================================================");
            Console.WriteLine("=====================================================================");
            foreach (Product product in _customer.Cart)
            {
                cartTotal += product.ProductPrice * product.ProductQuantity;
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine($"Cart total: {cartTotal}");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Enter a command: (A)dd Products -- (P)urchase Cart -- (C)lear Cart");
            switch (InputValidation.ValidString().Trim().ToUpper()[0])
            {
                case ('A'):
                    AddProducttoCart();
                    break;

                case ('P'):
                    PurchaseCart();
                    break;

                case ('C'):
                    _customer.Cart.Clear();
                    exit = !exit;
                    break;

                default:
                    Console.WriteLine("Incorrect command!");
                    break;
            }
        }
    }

    public void PurchaseCart()
    {

    }

    public void ManagerStoreMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Enter a command: (A)dd Product -- (C)reate Product -- (Q)uit");
            string input = InputValidation.ValidString();

            char command = input.Trim().ToUpper()[0];

            switch (command)
            {
                case ('A'):
                    AddProduct();
                    break;

                case ('C'):
                    CreateProduct();
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

    public void AddProduct()
    {
        Product product = HelperFunctions.SelectProduct(_bl);
        if (product != null)
        {
            Console.WriteLine("Amount to add:");
            product.ProductQuantity = InputValidation.ValidInteger();
            _bl.AddProduct(product, _store);
        }
    }

    public void CreateProduct()
    {
        Console.WriteLine("Creating a product!");

        Product product = new Product();

        Console.WriteLine("Enter the name:");
        product.ProductName = InputValidation.ValidString().ToLower();

        Console.WriteLine("Enter the price:");
        product.ProductPrice = InputValidation.ValidDecimal();

        _bl.AddProduct(product);
    }
}