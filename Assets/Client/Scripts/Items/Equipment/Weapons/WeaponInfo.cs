using UnityEngine;

[CreateAssetMenu(menuName ="Info/Equipment/Weapon")]
public class WeaponInfo : EquipmentInfo
{
    [SerializeField] private int _damage;
    [SerializeField] private WeaponType _weaponType;

    public int Damage => _damage;
    public WeaponType WeaponType => _weaponType;

}
public enum WeaponType
{
    Sickle,
    Scythe,
}
