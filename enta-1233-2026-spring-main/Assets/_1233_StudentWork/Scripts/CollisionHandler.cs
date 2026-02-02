using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Room")
        {
            print("test");
            CameraMgr.Instance.ChangeRoomCamera();
        }
        

    }


}
