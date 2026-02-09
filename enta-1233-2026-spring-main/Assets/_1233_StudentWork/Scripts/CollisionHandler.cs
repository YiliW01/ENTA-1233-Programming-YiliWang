using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    //[SerializeField]
    //public BoxCollider _room1;
    //public BoxCollider _room2;
    //public BoxCollider _room3;
    //public BoxCollider _room4;

    //public int _roomNumber;

    public bool inRoom;

    private void OnTriggerEnter(Collider other)
    {
        inRoom = true;
        

    }

    private void OnTriggerExit(Collider other)
    {
        inRoom = false;
        CameraMgr.Instance.ChangeRoomCamera();
    }
}
