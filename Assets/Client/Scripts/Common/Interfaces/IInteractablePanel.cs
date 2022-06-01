using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractablePanel : IUIPanel
{
    void OnPlayerEnter(IInteractable obj, Player player);
    void OnPlayerExit(IInteractable obj);
    void ShowContent(IInteractable obj, Player player);
    void HideContent(IInteractable obj);
}
