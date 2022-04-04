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
                case ('Q'):
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Incorrect command!");
                    break;
            }
        }
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
        Product product = SelectProduct();
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

    public Product SelectProduct()
    {
        List<Product> products = _bl.GetAllProducts();

        if (products == null || products.Count == 0)
        {
            Console.WriteLine("There are no products!");
            return null!;
        }

        Console.WriteLine("Select a product!");

    SelectProduct:
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"[{i}] {products[i].ProductName}");
        }

        int index;

        if (Int32.TryParse(Console.ReadLine(), out index) && (index >= 0 && index < products.Count))
        {
            return products[index];
        }
        else
        {
            Console.WriteLine("Enter a valid index!");
            goto SelectProduct;
        }
    }
}