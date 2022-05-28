using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    public class SaveManager : MonoBehaviour
    {

        private FileSaveSystem saveSystem;
        private SaveData data;

        public SaveData Data => data;
        public void InitManager()
        {
            var defaultEquipmentData = Resources.Load<EquipmentData>("EquipmentDataDefault");
            saveSystem = new FileSaveSystem();
            data = (SaveData) saveSystem.Load(new SaveData(defaultEquipmentData));
        }

        public void Save(SaveData data)
        {
            saveSystem.Save(data);
        }
        //public SaveData Load() { }

    }
}