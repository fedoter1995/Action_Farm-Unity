using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public sealed class Equipments : MonoBehaviour
{
    private Weapon currentWeapon;
    private Backpack currentBackpack;

    private SaveManagerInteractor saveManager;
    private EquipmentPoint weaponPoint;
    private SpaceForBackpack spaceForBackpack;

    private List<int> purchasedWeapons;
    private List<Weapon> Weapons = new List<Weapon>();
    public Weapon CurrentWeapon 
    {                     
        get => currentWeapon;

        set
        {

            var weaponAvailable = Weapons.Find(item => item.GetStats().ID == value.GetStats().ID);
            if (weaponAvailable == null)
            {
                currentWeapon = CreateWeapon(value);
                Weapons.Add(CurrentWeapon);
                purchasedWeapons.Add(currentWeapon.GetStats().ID);
                weaponPoint.ChngeCurrentEquipment(currentWeapon);
                Save();
            }
            else
            {
                currentWeapon = weaponAvailable;
                weaponPoint.ChngeCurrentEquipment(currentWeapon);
                Save();
            }

        }
            
            }
    public Backpack CurrentBackpack
    {
        get => currentBackpack;
        set
        {
            currentBackpack = CreateBackpack(value);
            spaceForBackpack.ChngeCurrentEquipment(currentBackpack);
            Save();
        }
    }
    

    private void ChangeItemActivity(Equipment item)
    {
        item.gameObject.SetActive(!item.gameObject.activeInHierarchy);
    }
    private Weapon CreateWeapon(Weapon prefab)
    {   
        var weapon = Instantiate(prefab, weaponPoint.transform);
        weapon.ChangeActivity();

        return weapon;
    }
    private Backpack CreateBackpack(Backpack prefab)
    {
        var backpack = Instantiate(prefab, spaceForBackpack.transform);

        return backpack;
    }
    public void InitEquipments()
    {
        saveManager = Architecture.Game.GetInteractor<SaveManagerInteractor>();
        purchasedWeapons = saveManager.GetData().purchasedWeapons;

        weaponPoint = GetComponentInChildren<WeaponPoint>();
        spaceForBackpack = GetComponentInChildren<SpaceForBackpack>();
        InitBackpack();
        InitWeapons();
    }
    private void InitWeapons()
    {
        var allWeapons = Resources.LoadAll<Weapon>("Weapons").ToList();
        var curWeapons = new List<Weapon>();
        var weponsId = purchasedWeapons;
        foreach(Weapon weapon in allWeapons)
            foreach(int id in weponsId)
            {
                if (weapon.GetStats().ID == id)
                    curWeapons.Add(weapon);
            }

        foreach (Weapon weapon in curWeapons)
            CurrentWeapon = weapon;

        CurrentWeapon = Weapons.Find(weapon => weapon.GetStats().ID == Weapons[0].GetStats().ID);
    }

    private void InitBackpack()
    {
        var backpacks = Resources.LoadAll<Backpack>("Backpack").ToList();
        foreach(Backpack backpack in backpacks)
        {
                CurrentBackpack = backpack;           
        }
    }



    public bool HasWeapon(int id)
    {
        return Weapons.Find(weapon => weapon.GetStats().ID == id) != null;
    }

    private void Save()
    {
        var data = saveManager.GetData();

        data.purchasedWeapons = purchasedWeapons;
        data.backpackId = currentBackpack.GetStats().ID;

        saveManager.Save(data);
    }
}
