using UnityEngine;

public class ExplosionApplyForceRB : MonoBehaviour
{
    [SerializeField] private GameObject _source;
    [SerializeField] private float _forceMult = 500;

    public void Push(Collider other)
    {
        var force = (other.transform.position - _source.transform.position) * _forceMult;
        var rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode.Force);
        }
    }
}
