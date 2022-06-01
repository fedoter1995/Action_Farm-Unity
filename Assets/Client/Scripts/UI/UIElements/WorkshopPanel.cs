using System.Collections.Generic;
using UnityEngine;
using CustomTools;

public class WorkshopPanel : MonoBehaviour , IInteractablePanel
{
    [SerializeField] private List<ShopUiItem> _uiItems;
    [SerializeField] private ShopUiItem _uiSlotPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _capacity;

    private Pool<ShopUiItem> uiItemPool;
    private List<ShopUiItem> activeSlots = new List<ShopUiItem>();
    private void Start()
    {
        Initialize();
    }
    public void ChangeActivity(bool activity)
    {
        gameObject.SetActive(activity);
    }
    public void ShowContent(IInteractable obj, Player player)
    {
        ChangeActivity(true);
        var workshop = obj as Workshop;
        foreach(Equipment item in workshop.Assortment)
        {
            var uiSlot = uiItemPool.GetFreeObject();
            uiSlot.transform.position = Vector3.zero;
            uiSlot.TryToBuyEvent += workshop.BuyItem;
            activeSlots.Add(uiSlot);
            uiSlot.SetItem(item, player.Equipments.HasWeapon(item.GetStats().ID));
        }
    }
    public void HideContent(IInteractable obj)
    {
        var workshop = obj as Workshop;
        foreach (ShopUiItem uiSlot in activeSlots)
        {
            uiSlot.TryToBuyEvent -= workshop.BuyItem;
            uiSlot.gameObject.SetActive(false);
        }
        ChangeActivity(false);
    }
    public void OnPlayerEnter(IInteractable obj, Player player)
    {
        var workshop = obj as Workshop;
        if(workshop != null)
        {
            ShowContent(workshop, player);
        }

    }
    public void OnPlayerExit(IInteractable obj)
    {
        var workshop = obj as Workshop;
        if (workshop != null)
        {
            HideContent(workshop);
        }
    }
    private void Initialize()
    {
        uiItemPool = new Pool<ShopUiItem>(_uiSlotPrefab, _capacity, _parent, false);
        ChangeActivity(false);
    }

}
