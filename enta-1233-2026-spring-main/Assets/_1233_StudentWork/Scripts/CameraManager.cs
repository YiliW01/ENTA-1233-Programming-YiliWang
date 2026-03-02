using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private CinemachineCamera[] _cam;
    
    public CollisionHandler[] _camRoom;

    //idk what this was for i lost the thought
    //private int roomNumber = 0;

    public void ChangeRoomCamera()
    {
        _cam[0].Priority = 10;
        _cam[1].Priority = 10;

        if (_camRoom[0].inRoom == true)
        {
            _cam[0].Priority = 20;
        }

        if (_camRoom[1].inRoom == true)
        {
            _cam[1].Priority = 20;
        }

    }
}
