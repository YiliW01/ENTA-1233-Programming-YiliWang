using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _footstepSource;
    [SerializeField] private AudioSource _landingSource;

    public void PlayFootstep()
    {
        _footstepSource?.Play();
    }

    public void PlayLanding()
    {
        _landingSource?.Play();
    }
}
