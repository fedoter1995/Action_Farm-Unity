using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Rigidbody))]
public class Weapon : Equipment, IInflictDamage
{
    [SerializeField] private WeaponInfo _weaponStats;

    public override IEquipmentStats GetStats()
    {
        return _weaponStats;
    }

    public void InflictDamage(int damage, ITakeDamge target)
    {
        target.TakeDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        var recipient = other.GetComponent<ITakeDamge>();

        if(recipient != null)
        {
            InflictDamage(_weaponStats.Damage, recipient);
        }
    }
}
