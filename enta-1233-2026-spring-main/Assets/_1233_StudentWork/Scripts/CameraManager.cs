using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    private int number = 87348;

    [SerializeField]
    private CinemachineCamera camera1;

    [SerializeField] private CinemachineCamera camera2;

    public void ChangeCamera()
    {
        if(camera1.Priority<camera2.Priority)
        {
            camera1.Priority = 2;
            camera2.Priority = 1;
        }


    }

    private void Adding(int number1, int number2)
    {

    }
}
