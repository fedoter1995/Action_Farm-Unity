using System;
using UnityEngine;

public class ItemStats : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _price;

    public int ID  => _id;
    public int Price => _price;
}

