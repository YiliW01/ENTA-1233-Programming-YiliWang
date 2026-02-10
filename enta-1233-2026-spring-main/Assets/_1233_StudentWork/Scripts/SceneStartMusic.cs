using UnityEngine;

public class SceneStartMusic : MonoBehaviour
{

    [SerializeField] private float volumeMod;

    [SerializeField] private AudioMgr.MusicTypes music;

    void Start()
    {
        AudioMgr.Instance.PlayMusic(music, volumeMod);
    }

}
