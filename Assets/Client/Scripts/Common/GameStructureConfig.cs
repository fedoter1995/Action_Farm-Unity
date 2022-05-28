using UnityEngine;
[CreateAssetMenu(menuName = "Config/GameStructureConfig")]
public class GameStructureConfig : ScriptableObject
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
    
    public Vector3 Position => _position;
    public Quaternion Rotation => _rotation;
}
