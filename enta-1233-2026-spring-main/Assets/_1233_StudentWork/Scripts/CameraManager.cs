using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private CinemachineCamera[] _cam;
    
    [SerializeField] CollisionHandler[] _camRoom;

    public CinemachineCamera _activeCamera;

    private void Start()
    {
        _activeCamera = _cam[0];
    }

    public void ChangeRoomCamera()
    {
        _cam[0].Priority = 10;
        _cam[1].Priority = 10;
        _cam[2].Priority = 10;

        if (_camRoom[0].inRoom == true)
        {
            _cam[0].Priority = 11;
            _activeCamera = _cam[0];
        }

        if (_camRoom[1].inRoom == true)
        {
            _cam[1].Priority = 11;
            _activeCamera = _cam[1];
        }

        if (_camRoom[2].inRoom == true)
        {
            _cam[2].Priority = 11;
            _activeCamera = _cam[2];
        }

    }
}
