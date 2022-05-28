using UnityEngine;
using Cinemachine;
using Architecture;
public class CameraInteractor : Interactor
{
    public CinemachineVirtualCamera  camera { get; private set; }
    public Camera mainCamera { get; private set; }
    private Object virtualCamera;
    private PlayerInteractor player;
    protected override void Initialize()
    {
        virtualCamera = Resources.Load("Camera/VirtualCameraDefault");
        mainCamera = Camera.main;
        camera = CustomTools.Creator.Create(virtualCamera, mainCamera.transform.position, Quaternion.identity).GetComponent<CinemachineVirtualCamera>();
        player = Game.GetInteractor<PlayerInteractor>();
    }
    public override void OnStart()
    {

        camera.LookAt = player.player.transform;
    }
}
