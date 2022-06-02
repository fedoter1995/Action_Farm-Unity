using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRespondingToPlayerPanel : IUIPanel
{
    void OnPlayerEnter(object obj, Player player);
    void OnPlayerExit(object obj);
}
