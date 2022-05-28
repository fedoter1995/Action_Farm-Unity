using Architecture;
using SaveSystem;
using System.Collections;
using UnityEngine;

public class SaveManagerInteractor : Interactor
{
    private SaveManager saveManager;

    protected override void Initialize()
    {
        saveManager = new GameObject("SAVE_MANAGER").AddComponent<SaveManager>();
        saveManager.InitManager();

    }


    public void Save(SaveData data)
    {
        saveManager.Save(data);
    }

    public SaveData GetData()
    {
        return saveManager.Data;
    }
}
