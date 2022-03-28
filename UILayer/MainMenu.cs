﻿// See https://aka.ms/new-console-template for more information
namespace UILayer;

public class MainMenu
{
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

            string username = "";
            string password = "";
            string passwordConfirm = "";

            switch (command)
            {
                case ('S'):
                    Console.WriteLine("Sign Up!");
                    Console.WriteLine("Username: ");
                    username = ValidString();
                    Console.WriteLine("Password: ");
                    password = ValidString();
                    Console.WriteLine("Confirm Password:");
                    passwordConfirm = ValidString();
                    break;

                case ('L'):
                    Console.WriteLine("Log In!");
                    Console.WriteLine("Username: ");
                    username = ValidString();
                    Console.WriteLine("Password: ");
                    password = ValidString();
                    break;

                case ('E'):
                    Console.WriteLine("Employee Log In!");
                    Console.WriteLine("Username: ");
                    username = ValidString();
                    Console.WriteLine("Password: ");
                    password = ValidString();
                    break;

                case ('Q'):
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Incorrect command!");
                    break;
            }

            // Console.Clear();

            break;
        }
    }
}