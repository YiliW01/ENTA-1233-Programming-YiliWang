using UnityEngine;

public class GameCompleteTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameMgr.Instance.GameComplete();
        }
    }
}
