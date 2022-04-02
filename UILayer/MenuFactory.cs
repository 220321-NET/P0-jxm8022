namespace UILayer;

public static class MenuFactory
{
    public static IMenu GetMenu(string menu)
    {
        menu = menu.ToLower();

        string connectionString = File.ReadAllText("./connectionString.txt");

        IRepository repo = new DBRepository(connectionString);
        IBusiness bl = new Business(repo);

        switch (menu)
        {
            case "main":
                return new MainMenu(bl);
            case "home":
                return new HomeMenu(bl);
            case "manager":
                return new ManagerMenu(bl);
            case "store":
                return new StoreMenu(bl);
            default:
                return new MainMenu(bl);
        }
    }
}