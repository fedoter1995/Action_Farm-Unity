using UnityEngine;
using System;

public class AnimationEventsHandler : MonoBehaviour
{
    public event Action TriggerAnimationEvent;
    public void TriggerEvent()
    {
        TriggerAnimationEvent?.Invoke();
    }
}
