using System;
using UnityEngine;
using UnityEngine.UI;

public class GardenBedPanel : MonoBehaviour, IRespondingToPlayerPanel
{

    [SerializeField] private Button button;
    public IInteractive currentObj { get; private set; }
    public Crops currentCrops { get; private set; }
    private void Start()
    {
        Initialize();
    }
    private void Harvesting()
    {
        currentObj.Interact(currentCrops);
    }
    public void ChangeActivity(bool activity)
    {
        gameObject.SetActive(activity);
    }
    public void OnPlayerEnter(object obj, Player player)
    {
        currentObj = obj as IInteractive;
        var gardenBed = currentObj as GardenBed;
        if(gardenBed != null)
        {
            ShowContent();
        }

    }
    public void OnPlayerExit(object obj)
    {
        currentObj = obj as IInteractive;
        var gardenBed = currentObj as GardenBed;
        if (gardenBed != null)
        {
            HideContent();
        }
    }
    public void HideContent()
    {
        ChangeActivity(false);
    }
    public void ShowContent()
    {
        ChangeActivity(true);
    }
    private void Initialize()
    {
        button.onClick.AddListener(Harvesting);
        ChangeActivity(false);
    }
}
