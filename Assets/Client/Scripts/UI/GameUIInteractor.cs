using UnityEngine;
using Architecture;
public class GameUIInteractor : Interactor
{
    private GameUI ui;

    private PlayerInteractor playerInteractor;
    private BankInteractor bankInteractor;
    private BankRepository bankRepository;

    protected override void Initialize()
    {
        LoadResources();
        GetRepositories();
        GetInteractors();
    }
    public override void OnStart()
    {        
        InitCoinsCounterUI();
        InitBackpackUI();
        InitCoinsPool();
        InitWorkshopPanelUI();
        InitGardenBedPanelUI();
    }
    private void LoadResources()
    {
        var prefab = Resources.Load("Interface/UIInterface") as GameObject;
        ui = CustomTools.Creator.Create(prefab).GetComponent<GameUI>();
    }
    private void GetInteractors()
    {
        bankInteractor = Game.GetInteractor<BankInteractor>();
        playerInteractor = Game.GetInteractor<PlayerInteractor>();
    }
    private void GetRepositories()
    {
        bankRepository = Game.GetRepository<BankRepository>();
    }

    // use after OnInitialize
    private void InitCoinsCounterUI()
    {
        ui.UpMenu.Coins.ChangeCoins(bankRepository.coins);
        bankInteractor.OnCoinsChangeEvent += ui.UpMenu.Coins.ChangeCoins;
    }
    private void InitBackpackUI()
    {
        var backpack = playerInteractor.player.Equipments.CurrentBackpack;
        ui.UpMenu.Backpack.ChangeBackpackValues(backpack.Capacity, backpack.ItemAmount);
        backpack.OnInventoryAddedEvent += ui.UpMenu.Backpack.ChangeBackpackValues;
        backpack.OnInventoryRemovedEvent += ui.UpMenu.Backpack.ChangeBackpackValues;
    }
    private void InitWorkshopPanelUI()
    {
        var workshops = GameObject.FindObjectsOfType<Workshop>();

        if (workshops.Length > 0)
        {
            foreach (IInteractable workshop in workshops)
            {
                workshop.OnPlayerEnterEvent += ui.WorkshopPanel.OnPlayerEnter;
                workshop.OnPlayerExitEvent += ui.WorkshopPanel.OnPlayerExit;
            }
        }
    }
    private void InitCoinsPool()
    {
        var barns = GameObject.FindObjectsOfType<Barn>();
        foreach(Barn barn in barns)
        {
            barn.BarterEvent += ui.CoinsPool.GetCoin;
        }
    }
    private void InitGardenBedPanelUI()
    {
        var gardens = GameObject.FindObjectsOfType<GardenBed>();
        if(gardens.Length > 0)
        {
            foreach (GardenBed gardenBed in gardens)
            {
                gardenBed.OnPlayerEnterEvent += ui.GardenBedPanel.OnPlayerEnter;
                gardenBed.OnPlayerExitEvent += ui.GardenBedPanel.OnPlayerExit;
            }
        }

    }


}
