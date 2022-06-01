using UnityEngine;
using UnityEngine.UI;

public class GardenBedPanel : MonoBehaviour, IInteractablePanel
{

    [SerializeField] Button button;
    private void Start()
    {
        Initialize();
    }
    public void ChangeActivity(bool activity)
    {
        gameObject.SetActive(activity);
    }
    public void OnPlayerEnter(IInteractable obj, Player player)
    {
        var gardenBed = obj as GardenBed;
        if(gardenBed != null)
        {
            ShowContent(gardenBed, player);
        }

    }
    public void OnPlayerExit(IInteractable obj)
    {
        var gardenBed = obj as GardenBed;
        if (gardenBed != null)
        {
            HideContent(gardenBed);
        }
    }
    public void HideContent(IInteractable obj)
    {
        ChangeActivity(false);
    }
    public void ShowContent(IInteractable obj, Player player)
    {
        ChangeActivity(true);
    }
    private void Initialize()
    {
        ChangeActivity(false);
    }
}
