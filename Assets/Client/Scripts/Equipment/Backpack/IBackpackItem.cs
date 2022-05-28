using UnityEngine;
public interface IBackpackItem : IPickupItem, IHasPrice
{
    int id { get; }
    ItemStats Stats { get; }
    public GameObject ItemGameObject { get; }
}

