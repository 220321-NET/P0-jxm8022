namespace UILayer;

public class HomeMenu : IMenu
{
    private readonly IBusiness _repo;

    public HomeMenu(IBusiness repo)
    {
        _repo = repo;
    }

    public void Start()
    {

    }
}