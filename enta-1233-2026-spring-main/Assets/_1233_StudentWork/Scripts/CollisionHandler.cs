using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public bool inRoom;

    private void OnTriggerEnter(Collider other)
    {
        inRoom = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRoom = false;
        CameraManager.Instance.ChangeRoomCamera();
    }
}
