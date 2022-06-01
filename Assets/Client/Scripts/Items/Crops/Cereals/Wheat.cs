using System;
using UnityEngine;

public class Wheat : Crops, ITakeDamge
{
    [SerializeField] protected CustomTools.CustomSlicer _slicer;


    private void Awake()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        GrowingStartEvent += _slicer.Slice;
        TwoSecondsLeftEvent += _slicer.DestroyParts;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(_info.Size.x, 0.1f, _info.Size.y));
    }
}
