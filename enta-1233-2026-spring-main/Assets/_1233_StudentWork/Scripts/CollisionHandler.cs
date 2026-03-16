using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public bool inRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRoom = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRoom = false;
            CameraManager.Instance.ChangeRoomCamera();
        }
    }
}
