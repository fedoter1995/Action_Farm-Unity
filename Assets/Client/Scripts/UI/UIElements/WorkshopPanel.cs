using System.Collections.Generic;
using UnityEngine;
using CustomTools;

public class WorkshopPanel : MonoBehaviour , IWorkshopPanel
{
    [SerializeField] private List<ShopUiItem> _uiItems;
    [SerializeField] private ShopUiItem _uiSlotPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _capacity;

    private Pool<ShopUiItem> uiItemPool;
    private List<ShopUiItem> activeSlots = new List<ShopUiItem>();
    private IWorkshop workshop;
    private Player player;

    private void Start()
    {
        Initialize();
    }
    public void ChangeActivity(bool activity)
    {
        gameObject.SetActive(activity);
    }
    public void ShowContent()
    {
        ChangeActivity(true);
        foreach(Equipment item in workshop.Assortment)
        {
            var uiSlot = uiItemPool.GetFreeObject();
            uiSlot.transform.position = Vector3.zero;
            uiSlot.TryToBuyEvent += TryToBuyItem;
            activeSlots.Add(uiSlot);
            uiSlot.SetItem(item, player.Equipments.HasWeapon(item.GetStats().ID));
        }
    }
    public void HideContent()
    {
        foreach (ShopUiItem uiSlot in activeSlots)
        {
            uiSlot.TryToBuyEvent -= TryToBuyItem;
            uiSlot.gameObject.SetActive(false);
        }
        workshop = null;
        ChangeActivity(false);
    }
    public void OnPlayerEnter(object obj, Player player)
    {
        workshop = obj as IWorkshop;
        this.player = player; 
        if (workshop != null)
        {
            ShowContent();
        }
    }
    public void OnPlayerExit(object obj)
    {
        workshop = obj as IWorkshop;
        if (workshop != null)
        {
            HideContent();
            workshop = null;
            player = null;
        }
    }
    public void TryToBuyItem(Equipment item)
    {
        if (workshop != null)
            workshop.BuyItem(item);

    }
    private void Initialize()
    {
        uiItemPool = new Pool<ShopUiItem>(_uiSlotPrefab, _capacity, _parent, false);
        ChangeActivity(false);
    }

}
