using System;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class ExchangeZone : MonoBehaviour
{
    public event Action<Player> EnterEvent;
    public event Action ExitEvent;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
            EnterEvent?.Invoke(player);
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
            ExitEvent?.Invoke();
    }
}
