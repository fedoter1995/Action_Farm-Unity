using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GardenBed : MonoBehaviour, IInteractive
{
    [SerializeField] private Vector2Int _size = new Vector2Int(2,1);
    [SerializeField] private Vector2 _offset = new Vector2(1, 1);
    [SerializeField] private Crops _cropsPrefab;


    private CropsPool cropsPool;
    private BoxCollider gardenCollider;
    private Player currentPlayer;

    #region Events
    public event Action<object, Player> OnPlayerEnterEvent;
    public event Action<object> OnPlayerExitEvent;
    #endregion
    private void Awake()
    {
        gardenCollider = GetComponent<BoxCollider>();
        Planting(_cropsPrefab);
    }
    private void Planting(Crops prefab)
    {
        if (cropsPool != null)
            cropsPool.ClearPool();

        cropsPool = new CropsPool(transform, prefab, _size.x * _size.y);
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                var crops = cropsPool.GetCrops(new Vector3(x * _offset.x, 0.1f, y * _offset.y));
            }
            
        }

        gardenCollider.isTrigger = true;
        gardenCollider.center = new Vector3(_size.x * _offset.x / 2, 1f, _size.y * _offset.y / 2);
        gardenCollider.size = new Vector3(_size.x * _offset.x, 1f, _size.y * _offset.y);
    }
    private void Harvesting()
    {
        foreach(Crops crops in cropsPool.CropsList)
        {
            crops.Harvest();
        }
    }
    public void Interact(object obj)
    {
        if(true)
            Harvesting();
    }
    #region PlayerTrigger
    public void OnTriggerEnter(Collider other)
    {
        currentPlayer = other.GetComponent<Player>();

        if (currentPlayer != null)
            OnPlayerEnterEvent?.Invoke(this, currentPlayer);
    }
    public void OnTriggerExit(Collider other)
    {
        currentPlayer = other.GetComponent<Player>();

        if (currentPlayer != null)
        {
            OnPlayerExitEvent?.Invoke(this);
        }
        currentPlayer = null;
    }
    #endregion
}
