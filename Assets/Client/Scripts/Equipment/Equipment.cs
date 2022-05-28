using System;
using UnityEngine;

[Serializable]
public abstract class Equipment : MonoBehaviour
{
    public abstract IEquipmentStats GetStats();
    public BoxCollider EquipmentCollider { get; private set; }

    public void ChangeActivity()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
        //EquipmentCollider.enabled = !EquipmentCollider.enabled;
    }

}

