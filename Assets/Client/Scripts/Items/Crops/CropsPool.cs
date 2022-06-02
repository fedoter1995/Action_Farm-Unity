using System.Collections.Generic;
using UnityEngine;

public class CropsPool
{
    private int count;
    private bool _autoExpand = false;
    private CustomTools.Pool<Crops> cropsPool;
    private List<Crops> cropsList;

    public List<Crops> CropsList => cropsList;
    public CropsPool(Transform parent, Crops cropsPrefab, int count)
    {
        this.count = count;
        cropsPool = new CustomTools.Pool<Crops>(cropsPrefab, this.count, parent, _autoExpand);
        cropsList = new List<Crops>();
    }
    public Crops GetCrops(Vector3 position)
    {
        var go = cropsPool.GetFreeObject();
        go.transform.localPosition = position;
        cropsList.Add(go);
        return go;
    }
    public void ClearPool()
    {
        cropsPool.Clear();
    }
}
