using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Player")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private float speed;
   
    public float Speed { get => speed; }

}
