using System;
using System.Collections.Generic;

namespace SaveSystem
{
    [Serializable]
    public class SaveData
    {
        public int Coins;
        public List<int> purchasedWeapons;
        public int backpackId;

        public SaveData(EquipmentData data)
        {

            purchasedWeapons = data.Weapons;
            backpackId = data.Backpack;

            Coins = 0;
        }
    }
}