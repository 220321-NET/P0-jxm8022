namespace UILayer;

public static class HelperFunctions
{
    public static StoreFront SelectStore(IBusiness _bl)
    {
        Console.WriteLine("Select a store!");

        List<StoreFront> storeFronts = _bl.GetStoreFronts();

        if (storeFronts == null || storeFronts.Count == 0)
        {
            Console.WriteLine("There are no stores!");
            return null!;
        }

    SelectStore:
        for (int i = 0; i < storeFronts.Count; i++)
        {
            Console.WriteLine($"[{i}] {storeFronts[i].City}, {storeFronts[i].State}");
        }

        int index;

        if (Int32.TryParse(Console.ReadLine(), out index) && (index >= 0 && index < storeFronts.Count))
        {
            return storeFronts[index];
        }
        else
        {
            Console.WriteLine("Enter a valid index!");
            goto SelectStore;
        }
    }

}