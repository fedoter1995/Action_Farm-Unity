using System;
using System.Collections.Generic;
using UnityEngine;
using Architecture;

public class Workshop : MonoBehaviour, IStore, IInteractable
{
    [SerializeField] private List<Equipment> _assortment;
    [SerializeField] private WorkshopZone _workshopZone;
    
    private Player player;
    #region Events
    public event Action<object, object, int> BarterEvent;
    public event Action<IInteractable, Player> OnPlayerEnterEvent;
    public event Action<IInteractable> OnPlayerExitEvent;
    #endregion
    public List<Equipment> Assortment => _assortment;
    public GameObject CurrentObject => gameObject;

    private void Awake()
    {
        _workshopZone.EnterEvent += EnterTheWorkshop;
        _workshopZone.ExitEvent += ExitTheWorkshop;
    }


    private bool TryToBuyItem(Equipment item)
    {
        var bank = Game.GetInteractor<BankInteractor>();
        
        if (bank.coins >= item.GetStats().Price)
        {
            var type = item.GetType();

            if (type == typeof(Weapon))
            {

                player.Equipments.CurrentWeapon = item.GetComponent<Weapon>();
                bank.SpendCoins(this, item.GetStats().Price);
                return true;
            }
            else if(type == typeof(Backpack))
            {
                player.Equipments.CurrentBackpack = item.GetComponent<Backpack>();
                bank.SpendCoins(this, item.GetStats().Price);
                return true;
            }
            throw new Exception($"Invalid type {item}"); 
        }

        return false;
    }
    public void BuyItem(Equipment item)
    {
        if (TryToBuyItem(item))
        {
            Debug.Log($"You buy{item}");
        }           
        else
            Debug.Log($"No money to buy{item}");
    }

    #region Interaction with the Player
    private void EnterTheWorkshop(Player player)
    {
        this.player = player;
        OnPlayerEnterEvent?.Invoke(this, player);            
    }
    private void ExitTheWorkshop()
    {
        player = null;
        OnPlayerExitEvent?.Invoke(this);
    }

    public void Interact()
    {
        throw new NotImplementedException();
    }
    #endregion
}
