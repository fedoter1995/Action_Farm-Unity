using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    [SerializeField] private Vector2Int _size = new Vector2Int(2,1);
    [SerializeField] private Vector2 _offset = new Vector2(1, 1);
    [SerializeField] private Crops _cropsPrefab;

    private CropsPool cropsPool;
    private void Awake()
    {
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
    }
}
