public interface IWeaponStats : IEquipmentStats
{
    int Damage { get; }
    WeaponType WeaponType { get; }
}