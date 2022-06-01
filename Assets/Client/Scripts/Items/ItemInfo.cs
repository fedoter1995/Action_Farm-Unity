using System;
using UnityEngine;

public class ItemInfo : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private int _price;

    public string ID  => _id;
    public int Price => _price;
}

