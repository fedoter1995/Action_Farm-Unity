using UnityEngine;
public interface IBackpackItem : IPickupItem, IHasPrice
{
    string Id { get; }
    ItemInfo Stats { get; }
    public GameObject ItemGameObject { get; }
}

