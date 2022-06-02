using System;
using UnityEngine;

public abstract class EquipmentPoint : MonoBehaviour
{
    private Equipment currentEquipment;
    private AnimationEventsHandler handler;
    private PlayerInteractor playerInteractor;

    public Equipment CurrentWeapon => currentEquipment;
    public AnimationEventsHandler Handler => handler;


    public void ChngeCurrentEquipment(Equipment newItem)
    {        
        currentEquipment = newItem;
    }

    protected void Init()
    {
        handler = GetComponentInParent<AnimationEventsHandler>();
        handler.TriggerAnimationEvent += AttackActivity;
        playerInteractor = Architecture.Game.GetInteractor<PlayerInteractor>();
    }

    private void AttackActivity()
    {
        currentEquipment.ChangeActivity();
    }
}

