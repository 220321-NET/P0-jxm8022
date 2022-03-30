// See https://aka.ms/new-console-template for more information
namespace UILayer;

public class Program
{
    public static void Main(String[] args)
    {
        string connectionString = File.ReadAllText("./connectionString.txt");

        IRepository repo = new DBRepository(connectionString);
        IBusiness bl = new Business(repo);
        new MainMenu().Start();
    }
}