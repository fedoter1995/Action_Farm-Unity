using Architecture;
public class BankRepository : Repository
{
    private SaveManagerInteractor saveManager;
    public int coins { get; set; }

    public override void OnStart()
    {
        saveManager = Game.GetInteractor<SaveManagerInteractor>();
        coins = saveManager.GetData().Coins;
    }


    public  void Save()
    {
        var data = saveManager.GetData();
        data.Coins = coins;
        saveManager.Save(data);
    }
}
