using UnityEngine;
public interface IEquipmentStats
{
    int ID { get; }
    Sprite Icon { get; }
    string Title { get; }
    int Price { get; }
}
