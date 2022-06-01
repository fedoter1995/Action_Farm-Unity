using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    GameObject CurrentObject { get; }
    event Action<IInteractable, Player> OnPlayerEnterEvent;
    event Action<IInteractable> OnPlayerExitEvent;
    void Interact();
}
