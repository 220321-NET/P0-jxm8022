// See https://aka.ms/new-console-template for more information

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

string Username()
{
EnterEUser:
    Console.WriteLine("Username: ");
    string username = Console.ReadLine() ?? "";

    if (String.IsNullOrWhiteSpace(username))
    {
        Console.WriteLine("Enter a valid username: ");
        goto EnterEUser;
    }
    return username;
}

string Password()
{
EnterEUser:
    Console.WriteLine("Password: ");
    string password = Console.ReadLine() ?? "";

    if (String.IsNullOrWhiteSpace(password))
    {
        Console.WriteLine("Enter a valid password: ");
        goto EnterEUser;
    }
    return password;
}

bool exit = false;

while (!exit)
{
// ENTER COMMAND TO ENTER THE STORE MAIN PAGE
EnterCommand:
    Console.WriteLine("Enter a command: (S)ign up -- (L)og in -- (E)mployee -- (Q)uit");
    string input = Console.ReadLine() ?? "";

    if (String.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Please enter a valid command: (S)ign up -- (L)og in -- (E)mployee -- (Q)uit");
        goto EnterCommand;
    }

    char command = input.Trim().ToUpper()[0];

    string username = "";
    string password = "";

    // START OF SWITCH TO READ COMMAND AND READ USERNAME/PASSWORD
    switch (command)
    {
        // CASE FOR SIGNING UP
        case ('S'):
            Console.WriteLine("Sign Up!");

            // ENTER USERNAME
            username = Username();

            // ENTER PASSWORD
            password = Password();
            break;

        // CASE FOR LOG IN
        case ('L'):
            Console.WriteLine("Log In!");

            // ENTER USERNAME
            username = Username();

            // ENTER PASSWORD
            password = Password();
            break;

        // CASE FOR EMPLOYEE IN
        case ('E'):
            Console.WriteLine("Employee Log In!");

            // ENTER USERNAME
            username = Username();

            // ENTER PASSWORD
            password = Password();
            break;

        // CASE FOR QUITING
        case ('Q'):
            exit = true;
            break;

        // CASE FOR DEFAULT
        default:
            Console.WriteLine("Incorrect command!");
            break;
    } // END OF SWITCH STATEMENT

    Console.WriteLine(username + password);
    break;
}