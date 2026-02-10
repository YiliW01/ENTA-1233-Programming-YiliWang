using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LevelMgr.Instance.LevelComplete();
            GameMgr.Instance.NextLevel();
        }
    }
}
