using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    //private int number = 87348;

    [SerializeField]
    private CinemachineCamera _cam1;
    [SerializeField]
    private CinemachineCamera _cam2;
    //[SerializeField]
    //private CinemachineCamera _cam3;
    //[SerializeField]
    //private CinemachineCamera _cam4;

    public CollisionHandler camRoom1;
    public CollisionHandler camRoom2;
    //public CollisionHandler roomCam3;
    //public CollisionHandler roomCam4;

    public void ChangeRoomCamera()
    {
        _cam1.Priority = 10;
        _cam2.Priority = 10;
        //_cam3.Priority = 10;
        //_cam4.Priority = 10;

        if (camRoom1.inRoom == true)
        {
            _cam1.Priority = 20;
        }

        if (camRoom2.inRoom == true)
        {
            _cam2.Priority = 20;
        }

    }
}
