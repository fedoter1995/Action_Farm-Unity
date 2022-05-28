using UnityEngine;

public abstract class EquipmentInfo : ScriptableObject, IEquipmentStats
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _title;
    [SerializeField] private int _price;
    public int ID => _id;
    public Sprite Icon => _icon;
    public string Title => _title;
    public int Price => _price;
}
