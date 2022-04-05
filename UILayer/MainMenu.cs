﻿// See https://aka.ms/new-console-template for more information
namespace UILayer;

public class MainMenu : IMenu
{
    private readonly IBusiness _bl;
    private Customer _customer = new Customer();
    private StoreFront _store = new StoreFront();
    public MainMenu(IBusiness bl)
    {
        _bl = bl;
    }
    /// <summary>
    /// Method to hold the title of the store(Telescope Store). Used to spice things up.
    /// </summary>
    public void StoreTitle()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
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
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\nWelcome to Telescope Store!\n");
    }

    /// <summary>
    /// Method to start the store application. This is the entrance to the telescope store.
    /// </summary>
    public void Start()
    {
        bool exit = false;

        StoreTitle();

        while (!exit)
        {
            Console.WriteLine("Enter a command: (S)ign up -- (L)og in -- (E)mployee -- (Q)uit");
            string input = InputValidation.ValidString();

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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect command!");
                    Console.ForegroundColor = ConsoleColor.Gray;
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

    /// <summary>
    /// Method to handle sign up when there is a new user
    /// </summary>
    public void SignUp()
    {
        string username;

        Console.WriteLine("Sign Up!");
        Console.WriteLine("Username: ");
        username = InputValidation.ValidString();
    SignUp:
        Console.WriteLine("Confirm username:");
        if (username == InputValidation.ValidString())
        {
            if (_bl.GetCustomer(username) == null)
            {
                Customer customer = new Customer();
                customer.UserName = username;
                _bl.AddCustomer(customer);
                MenuFactory.GetMenu("home").Start(customer);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User already exists!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Username does not match!");
            Console.ForegroundColor = ConsoleColor.Gray;
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
        Console.WriteLine("Username: ");
        username = InputValidation.ValidString();
        Customer customer = new Customer();
        customer = _bl.GetCustomer(username);
        if (customer != null)
        {
            customer.Employee = false;
            MenuFactory.GetMenu("home").Start(customer);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Customer does not exists!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    public void EmployeeLogin()
    {
        string username;

        Console.WriteLine("Employee Log In!");
        Console.WriteLine("Username: ");
        username = InputValidation.ValidString();
        Customer customer = new Customer();
        customer = _bl.GetCustomer(username);
        if (customer == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Employee does not exists!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (customer.Employee)
        {
            MenuFactory.GetMenu("manager").Start(customer);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("User is not an employee!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}