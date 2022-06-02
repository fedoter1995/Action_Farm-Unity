using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName ="EquipmentData",menuName = "Data/Equipment")]
public class EquipmentData : ScriptableObject
{
    [SerializeField] private List<int> _weapons;
    [SerializeField] private int _backpackId;

    public List<int> Weapons => _weapons;
    public int Backpack => _backpackId;
}
