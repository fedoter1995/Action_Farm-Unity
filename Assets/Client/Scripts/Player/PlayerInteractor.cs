using Architecture;
using System.Collections;
using UnityEngine;

public class PlayerInteractor : Interactor
{
    public Player player { get; private set; }
    private Vector3 _playerPosition;

    protected override void Initialize()
    {
        _playerPosition = GameObject.FindObjectOfType<Beginer>().PlayerPosition;
        var playerLoad = Resources.Load("Player/Ninja");
        player = CustomTools.Creator.Create(playerLoad, _playerPosition, Quaternion.identity).GetComponent<Player>();
        player.PlayerInit();
    }
}
