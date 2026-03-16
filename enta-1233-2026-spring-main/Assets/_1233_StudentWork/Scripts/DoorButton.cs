using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] GameObject _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pressing Button");
            _door.SetActive(false);
        }
    }
}
