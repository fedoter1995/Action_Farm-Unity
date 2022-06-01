using UnityEngine;
[CreateAssetMenu(menuName = "Stats/Crops")]
public class CropsInfo : ItemInfo
{
    [SerializeField] private Vector2 _size = Vector2.one;
    [SerializeField] private int _growingTime = 10;
    [SerializeField] private int _healthPoints = 10;

    public Vector2 Size => _size;
    public int GrowingTime { get => _growingTime; set => _growingTime = value; }
    public int HealthPoints { get => _healthPoints; set => _healthPoints = value; }

}
