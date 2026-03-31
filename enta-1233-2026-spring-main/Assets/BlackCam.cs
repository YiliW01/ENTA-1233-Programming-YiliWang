using UnityEngine;

public class BlackCam : MonoBehaviour
{
    private void Awake()
    {
        CameraMgr.Instance._mainCamera.enabled = false;
    }

    private void OnDisable()
    {
        CameraMgr.Instance._mainCamera.enabled = true;
    }
}
