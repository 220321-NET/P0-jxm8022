// See https://aka.ms/new-console-template for more information
namespace UILayer;

public class MainMenu : IMenu
{
    private readonly IBusiness _bl;
    public MainMenu(IBusiness bl)
    {
        _bl = bl;
    }
    /// <summary>
    /// Method to hold the title of the store(Telescope Store). Used to spice things up.
    /// </summary>
    public void StoreTitle()
    {
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine(" **********           **                                                              ********    **                            ");
        Console.WriteLine("/////**///           /**                                       ******                **//////    /**                            ");
        Console.WriteLine("    /**      *****   /**   *****    ******   *****    ******  /**///**   *****      /**         ******  ******   ******   ***** ");
        Console.WriteLine("    /**     **///**  /**  **///**  **////   **///**  **////** /**  /**  **///**     /********* ///**/  **////** //**//*  **///**");
        Console.WriteLine("    /**    /*******  /** /******* //*****  /**  //  /**   /** /******  /*******     ////////**   /**  /**   /**  /** /  /*******");
        Console.WriteLine("    /**    /**////   /** /**////   /////** /**   ** /**   /** /**///   /**////             /**   /**  /**   /**  /**    /**//// ");
        Console.WriteLine("    /**    //******  *** //******  ******  //*****  //******  /**      //******      ********    //** //******  /***    //******");
        Console.WriteLine("    //      //////  ///   //////  //////    /////    //////   //        //////      ////////      //   //////   ///      ////// ");
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("================================================================================================================================");
        Console.WriteLine("\nWelcome to Telescope Store!\n");
    }

    /// <summary>
    /// Method to start the store application. This is the entrance to the telescope store.
    /// </summary>
    public void Start()
    {
        bool exit = false;

        while (!exit)
        {
            StoreTitle();

            Console.WriteLine("Enter a command: (S)ign up -- (L)og in -- (E)mployee -- (Q)uit");
            string input = ValidString();

            char command = input.Trim().ToUpper()[0];

            switch (command)
            {
                case ('S'):
                    SignUp();
                    break;

                case ('L'):
                    Login();
                    break;

                case ('E'):
                    EmployeeLogin();
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

    /// <summary>
    /// Method to handle sign up when there is a new user
    /// </summary>
    public void SignUp()
    {
        string username;

        Console.WriteLine("Sign Up!");
        Console.WriteLine("Username: ");
        username = ValidString();
    SignUp:
        Console.WriteLine("Confirm username:");
        if (username == ValidString())
        {
            _bl.GetCustomer(username);
            if (Customer.UserName == "")
            {
                Customer.UserName = username;
                _bl.AddCustomer();
                MenuFactory.GetMenu("HomeMenu").Start();
            }
            else
            {
                Console.WriteLine("User already exists!");
            }
        }
        else
        {
            Console.WriteLine("Username does not match!");
            goto SignUp;
        }
    }

    /// <summary>
    /// Method to handle log in when existing user returns
    /// </summary>
    public void Login()
    {
        string username;

        Console.WriteLine("Log In!");
    NotAUser:
        Console.WriteLine("Username: ");
        username = ValidString();
    Login:
        Console.WriteLine("Confirm username:");
        if (username == ValidString())
        {
            _bl.GetCustomer(username);
            if (Customer.UserName == "")
            {
                Console.WriteLine("Customer does not exists!");
                goto NotAUser;
            }
            Console.WriteLine($"Welcome {Customer.UserName}");
            MenuFactory.GetMenu("HomeMenu").Start();
        }
        else
        {
            Console.WriteLine("Username does not match!");
            goto Login;
        }
    }

    public void EmployeeLogin()
    {
        string username;

        Console.WriteLine("Employee Log In!");
    NotEmployee:
        Console.WriteLine("Username: ");
        username = ValidString();
    Login:
        Console.WriteLine("Confirm username:");
        if (username == ValidString())
        {
            _bl.GetCustomer(username);
            if (Customer.UserName == "")
            {
                Console.WriteLine("Employee does not exists!");
                goto NotEmployee;
            }
            else if (Customer.Employee)
            {
                Console.WriteLine($"Welcome {Customer.UserName}");
            }
            else
            {
                Console.WriteLine("User is not an employee!");
                goto NotEmployee;
            }
        }
        else
        {
            Console.WriteLine("Username does not match!");
            goto Login;
        }
    }

    /// <summary>
    /// Method to check if user input is valid. An invalid string is null or whitespace;
    /// </summary>
    /// <returns>string</returns>
    public string ValidString()
    {
    EnterString:
        string valid = Console.ReadLine() ?? "";

        if (String.IsNullOrWhiteSpace(valid))
        {
            Console.WriteLine("Enter a valid input: ");
            goto EnterString;
        }
        return valid;
    }
}