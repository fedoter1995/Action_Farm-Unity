using UnityEngine;

public class CropsPool
{
    private int count;
    private bool _autoExpand = false;
    private CustomTools.Pool<Crops> cropsPool;
    public CropsPool(Transform parent, Crops cropsPrefab, int count)
    {
        this.count = count;
        cropsPool = new CustomTools.Pool<Crops>(cropsPrefab, this.count, parent, _autoExpand);
    }
    public Crops GetCrops(Vector3 position)
    {
        var go = cropsPool.GetFreeObject();
        go.transform.localPosition = position;
        return go;
    }
    public void ClearPool()
    {
        cropsPool.Clear();
    }
}
