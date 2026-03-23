using UnityEngine;
using System.Collections;

public class SelfDelete : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Awake()
    {
        if (_particleSystem == null)
            _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    public void Cleanup()
    {
        StartCoroutine(WaitForCleanup());
    }

    private IEnumerator WaitForCleanup()
    {
        //Wait until particle system fully finishes
        yield return new WaitUntil(() => !_particleSystem.IsAlive(true));

        Destroy(gameObject);
    }
}
