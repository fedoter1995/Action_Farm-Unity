using System;
using UnityEngine;
public class BackpackItem : MonoBehaviour, IBackpackItem
{
    [SerializeField] private ItemStats stats;

    public int id => stats.ID;
    public ItemStats Stats => stats;
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
    public void Construct(ItemStats stats)
    {
        this.stats = stats;
    }
}

