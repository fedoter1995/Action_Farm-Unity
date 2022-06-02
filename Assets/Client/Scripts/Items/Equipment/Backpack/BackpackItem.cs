using System;
using UnityEngine;
public class BackpackItem : MonoBehaviour, IBackpackItem
{
    [SerializeField] private ItemInfo stats;

    public string Id => stats.ID;
    public ItemInfo Stats => stats;
    public GameObject ItemGameObject => gameObject;

    public int Price => stats.Price;

    public void OnTriggerEnter(Collider collider)
    {
        var backpack = collider.GetComponentInChildren<Backpack>();

        if (backpack != null)
            Pickup(backpack);
    }
    public void Pickup(Backpack backpack)
    {
        backpack.TryToAddToBackpack(this);
    }
    public void Construct(ItemInfo stats)
    {
        this.stats = stats;
    }
}

