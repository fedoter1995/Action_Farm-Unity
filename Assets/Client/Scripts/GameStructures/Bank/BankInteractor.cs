using System;
using UnityEngine;
using Architecture;

public class BankInteractor : Interactor
{
    private BankRepository repository;

    public event Action<int> OnCoinsChangeEvent;
    public int coins => repository.coins;


    protected override void Initialize()
    {
        repository = Game.sceneManager.GetRepository<BankRepository>();
        Bank.Initialize(this);
    }
    public bool IsEnougthCoins(int value)
    {
        return coins >= value;
    }

    public void AddCoins(object sender, int value)
    {

        repository.coins += value;
        repository.Save();
        OnCoinsChangeEvent?.Invoke(coins);
    }

    public void SpendCoins(object sender, int value)
    {
        repository.coins -= value;
        repository.Save();
        OnCoinsChangeEvent?.Invoke(coins);
    }
}
