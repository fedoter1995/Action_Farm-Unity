using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bank
{
    private static BankInteractor bankInteractor;

    public static int coins => bankInteractor.coins;
    public static bool isInitialize = false;
    public static void Initialize(BankInteractor interactor)
    {
        bankInteractor = interactor;
        isInitialize = true;

    }

    public static bool IsEnougthCoins(int value)
    {
        return bankInteractor.IsEnougthCoins(value);
    }

    public static void AddCoins(object sender, int value)
    {
        bankInteractor.AddCoins(sender, value);
    }

    public static void SpendCoins(object sender, int value)
    {
        bankInteractor.SpendCoins(sender, value);
    }

}
