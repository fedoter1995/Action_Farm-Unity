using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimatorController), typeof(Equipments))]
public class Player : MonoBehaviour
{    
    [SerializeField] private PlayerStats stats;
    [SerializeField] private PlayerController playerController;

    private PlayerAnimatorController animatorController;
    private Equipments equipments;
    #region Events
    public event Action EnterTheWorkshopEvent;
    #endregion
    public Equipments Equipments => equipments;
    public void PlayerInit() //When init PlayerInteractor
    {
        animatorController = GetComponent<PlayerAnimatorController>();
        equipments = GetComponent<Equipments>();
        playerController.AttackEvent += animatorController.SetAttackTrigger;
        playerController.InitInputs();
        equipments.InitEquipments();
    }

    #region Updates
    private void Update()
    {
        animatorController.SetMoveFloatValue(playerController.UserInput.MoveFloat);
        /*if (Input.GetKeyDown(KeyCode.S))
            Architecture.Game.GetInteractor<BankInteractor>().AddCoins(this, 1000);*/
    }
    private void FixedUpdate()
    {
        playerController.Move(stats.Speed, transform);
    }
    #endregion

    #region Interaction with the barn
    private void EnterTheBarn(Collider other)
    {
        var exchangeZone = other.GetComponent<ExchangeZone>();
        if (exchangeZone != null)
        {
            var barn = other.GetComponentInParent<Barn>();
            equipments.CurrentBackpack.StartRemoovedItems(barn);
        }
    }
    private void ExitTheBarn(Collider other)
    {
        var exchangeZone = other.GetComponent<ExchangeZone>();
        if (exchangeZone != null)
            equipments.CurrentBackpack.StopRemoovedItems();
    }
    #endregion

    public Equipments GetEquipments()
    {
        if (equipments != null)
            return equipments;
        throw new System.Exception("Equipments do not initialized");
    }
    public void OnTriggerEnter(Collider other)
    {
        EnterTheBarn(other);
    }
    public void OnTriggerExit(Collider other)
    {
        ExitTheBarn(other);
    }
}
