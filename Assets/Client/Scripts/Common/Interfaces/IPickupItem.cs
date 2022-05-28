using UnityEngine;

public interface IPickupItem 
{
    void Pickup(Backpack inventory);
    void OnTriggerEnter(Collider collider);
}
