using Architecture;
using UnityEngine;

public class Beginer : MonoBehaviour
{
    [SerializeField] private Transform _playerPoint;

    public Vector3 PlayerPosition => _playerPoint.position;
    private void Start()
    {
        Game.Run();
    }
}
