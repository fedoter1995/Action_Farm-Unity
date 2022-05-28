using System.Collections.Generic;
using UnityEngine;
using CustomTools;

public class WorkshopPanel : MonoBehaviour
{
    [SerializeField] private List<ShopUiItem> _uiItems;
    [SerializeField] private ShopUiItem _uiSlotPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _capacity;

    private Pool<ShopUiItem> uiItemPool;
    private List<ShopUiItem> activeSlots = new List<ShopUiItem>();
    private void Start()
    {
        InitCapacity();
        ChangeActivity();
    }
    private void ChangeActivity()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    private void ShowAssortment(Workshop workshop, Player player)
    {
        foreach(Equipment item in workshop.Assortment)
        {
            var uiSlot = uiItemPool.GetFreeObject();
            uiSlot.transform.position = Vector3.zero;
            uiSlot.TryToBuyEvent += workshop.BuyItem;
            activeSlots.Add(uiSlot);
            uiSlot.SetItem(item, player.Equipments.HasWeapon(item.GetStats().ID));
        }
    }

    public void WhenPlayerEnter(Workshop workshop, Player player)
    {
        ChangeActivity();
        ShowAssortment(workshop, player);
    }
    public void WhenPlayerExit(Workshop workshop)
    {
        HideSlots(workshop);
        ChangeActivity();
    }
    private void HideSlots(Workshop workshop)
    {
        foreach (ShopUiItem uiSlot in activeSlots)
        {
            uiSlot.TryToBuyEvent -= workshop.BuyItem;
            uiSlot.gameObject.SetActive(false);
        }

    }
    private void InitCapacity()
    {
        uiItemPool = new Pool<ShopUiItem>(_uiSlotPrefab, _capacity, _parent, false);
    }

    
}
