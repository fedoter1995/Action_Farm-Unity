using System;
using System.Collections;
using UnityEngine;


public abstract class Crops : MonoBehaviour, ITakeDamge
{
    #region SerializeFields
    [SerializeField] protected CropsInfo _info;
    [SerializeField] protected CropsStack _cropsStackPrefab;
    #endregion

    private CropsStackPool cropsStackPool;
    private BoxCollider cropsCollider;
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
        healthPoints = _info.HealthPoints;
        ColliderEnabled(true);
        mesh.enabled = true;
    }
    protected virtual void Initialize()
    {
        healthPoints = _info.HealthPoints;
        cropsCollider = GetComponentInChildren<BoxCollider>();
        mesh = GetComponentInChildren<MeshRenderer>();
        cropsStackPool = new CropsStackPool(transform, _cropsStackPrefab);
    }
    protected void Harvesting()
    {
        HarvestingEvent?.Invoke(gameObject);
        GrowingStartEvent?.Invoke();
        StartCoroutine(GrowingRoutine());
        mesh.enabled = false;
        ColliderEnabled(false);
        DropCropsStack();
    }    
    private void DropCropsStack()
    {
        cropsStackPool.GetCropsStack(transform.position);
    }
    private void ColliderEnabled(bool activity)
    {
        cropsCollider.enabled = activity;
    }
    private IEnumerator GrowingRoutine()
    {
        yield return new WaitForSeconds(2);
        TwoSecondsLeftEvent?.Invoke();
        yield return new WaitForSeconds(_info.GrowingTime);
        Maturation();
    }
    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Harvesting();
        }

    }
}
