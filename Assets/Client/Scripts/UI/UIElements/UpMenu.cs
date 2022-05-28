using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMenu : MonoBehaviour
{
    [SerializeField] private CounterCoinsUI _coins;
    [SerializeField] private BackpackUI _backpack;
    public CounterCoinsUI Coins => _coins;
    public BackpackUI Backpack => _backpack;
}
