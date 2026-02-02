using UnityEngine;

public class SceneStartMusic : MonoBehaviour
{

    [SerializeField] private float volumeMod;

    [SerializeField] private AudioMgr.MusicTypes music;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioMgr.Instance.PlayMusic(music, volumeMod);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
