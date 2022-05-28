using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(menuName = "Info/Equipment/Backpack")]
class BackpackInfo : EquipmentInfo
{
    [SerializeField] private int _capacity;
    [SerializeField] private float _itemOffset;

    public int Capacity => _capacity;
    public float ItemOffset => _itemOffset;
}

