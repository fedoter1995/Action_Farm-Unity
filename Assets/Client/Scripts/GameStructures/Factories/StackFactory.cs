using UnityEngine;

[CreateAssetMenu(menuName = "Factory/CropsStack")]
public class StackFactory : GameObjectFactory, ICropsFactory
{
    [SerializeField] private CropsStack _stackPrefab;

    public CropsStack CreateStack()
    {
        return CreateGameObjectInstance(_stackPrefab);
    }
}
