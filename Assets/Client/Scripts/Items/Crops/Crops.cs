using System;
using System.Collections;
using UnityEngine;


public abstract class Crops : MonoBehaviour
{
    #region SerializeFields
    [SerializeField] protected CropsInfo _info;
    [SerializeField] protected CropsStack _cropsStackPrefab;
    #endregion

    private CropsStackPool cropsStackPool;
    private MeshRenderer mesh;
    private int healthPoints;
    
   
    public int HealthPoints => healthPoints;


    #region Events
    public event Action<GameObject> HarvestingEvent;
    public event Action GrowingStartEvent;
    public event Action TwoSecondsLeftEvent;
    public event Action<int> TakeDamageEvent;
    #endregion

    protected virtual void Maturation()
    {
        mesh.enabled = true;
    }
    protected virtual void Initialize()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
        cropsStackPool = new CropsStackPool(transform, _cropsStackPrefab);
    }
    public void Harvest()
    {
        HarvestingEvent?.Invoke(gameObject);
        GrowingStartEvent?.Invoke();
        StartCoroutine(GrowingRoutine());
        mesh.enabled = false;
        DropCropsStack();
    } 
    private void DropCropsStack()
    {
        cropsStackPool.GetCropsStack(transform.position);
    }
    private IEnumerator GrowingRoutine()
    {
        yield return new WaitForSeconds(2);
        TwoSecondsLeftEvent?.Invoke();
        yield return new WaitForSeconds(_info.GrowingTime);
        Maturation();
    }
}
