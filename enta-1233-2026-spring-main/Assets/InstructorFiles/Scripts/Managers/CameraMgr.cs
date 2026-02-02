using UnityEngine;
using UnityEngine.Serialization;
using Unity.Cinemachine;

/// <summary>
/// Basic camera manager.
/// This camera will always exist and is not tied to any player or specific game state
/// </summary>
public class CameraMgr : Singleton<CameraMgr>
{
    /*
    public override void Awake() {
        base.Awake();
    }*/

    [FormerlySerializedAs("MainCamera")]
    [Header("Obj Refs")]
    public Camera _mainCamera;

    [SerializeField]
    private CinemachineCamera _cam1;

    [SerializeField]
    private CinemachineCamera _cam2;

        
    public void ChangeRoomCamera()
    {
        print ("test change");
        if(_cam1.Priority < _cam2.Priority)
        {
            _cam1.Priority = 11;
            _cam2.Priority = 10;
        }
        else
        {
            _cam2.Priority = 11;
            _cam1.Priority = 10;
        }
    }
}