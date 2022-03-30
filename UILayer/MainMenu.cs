// See https://aka.ms/new-console-template for more information
namespace UILayer;

public class MainMenu
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
            exit = AccountInput(exit);
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

    public bool AccountInput(bool exit)
    {
        Console.WriteLine("Enter a command: (S)ign up -- (L)og in -- (E)mployee -- (Q)uit");
        string input = ValidString();

        char command = input.Trim().ToUpper()[0];

        string username = "";
        string password = "";
        string passwordConfirm = "";

        switch (command)
        {
            case ('S'):
            SignUp:
                Console.WriteLine("Sign Up!");
                Console.WriteLine("Username: ");
                username = ValidString();
                Console.WriteLine("Password: ");
                password = ValidString();
                Console.WriteLine("Confirm Password:");
                passwordConfirm = ValidString();
                if (password == passwordConfirm)
                {
                    Customer customer = new Customer();
                    customer.UserName = username;
                    Console.WriteLine("Do you work here?");
                    if (ValidString().Trim().ToUpper()[0] == 'Y')
                    {
                        customer.Employee = true;
                        new StoreFront(customer).Home();
                    }
                    else
                    {
                        new StoreFront(customer).Home();
                    }
                    exit = true;
                }
                else
                {
                    goto SignUp;
                }
                break;

            case ('L'):
                Console.WriteLine("Log In!");
                Console.WriteLine("Username: ");
                username = ValidString();
                Console.WriteLine("Password: ");
                password = ValidString();
                // new StoreFront().Home();
                break;

            case ('E'):
                Console.WriteLine("Employee Log In!");
                Console.WriteLine("Username: ");
                username = ValidString();
                Console.WriteLine("Password: ");
                password = ValidString();
                // new StoreFront().Home();
                break;

            case ('Q'):
                exit = true;
                break;

            default:
                Console.WriteLine("Incorrect command!");
                break;
        }
        return exit;
    }
}