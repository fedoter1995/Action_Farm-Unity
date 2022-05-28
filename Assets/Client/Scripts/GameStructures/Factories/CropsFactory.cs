using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Crops")]
public class CropsFactory : GameObjectFactory, ICropsFactory
{
    [SerializeField] private Crops _cropsPrefab;
    
    public Crops CreateCrops()
    {
       return CreateGameObjectInstance(_cropsPrefab);
    }
}
