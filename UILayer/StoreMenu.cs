namespace UILayer;

public class StoreMenu : IMenu
{
    private readonly IBusiness _bl;

    public StoreMenu(IBusiness bl)
    {
        _bl = bl;
    }

    public void Start()
    {

    }
}