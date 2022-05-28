using System;
using UnityEngine;

public interface ICrops
{
    event Action<GameObject> HarvestingEvent;
}
