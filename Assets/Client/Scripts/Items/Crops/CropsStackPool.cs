using UnityEngine;
using CustomTools;
public class CropsStackPool
{
    private Pool<CropsStack> cropsPool;

    public CropsStackPool(Transform parent, CropsStack stackPrefab, int count = 1, bool autoExpand = true)
    {
        cropsPool = new Pool<CropsStack>(stackPrefab, count, parent, autoExpand);
    }
    public CropsStack GetCropsStack(Vector3 position)
    {
        var go = cropsPool.GetFreeObject();
        go.transform.position = position;
        go.transform.rotation = Quaternion.identity;
        return go;
    }
}
