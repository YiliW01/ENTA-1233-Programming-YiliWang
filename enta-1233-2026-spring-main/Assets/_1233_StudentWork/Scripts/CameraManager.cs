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
        for (int i = 0; i < _cam.Length; i++)
        {
            _cam[i].Priority = 10;

            if (_camRoom[i].inRoom == true)
            {
                _cam[i].Priority = 11;
                _activeCamera = _cam[i];
            }
        }
    }
}
