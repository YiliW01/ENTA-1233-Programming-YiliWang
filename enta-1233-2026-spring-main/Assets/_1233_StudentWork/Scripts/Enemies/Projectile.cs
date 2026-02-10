using UnityEngine;

/// <summary>
/// Handles projectile movement and collision.
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _lifetime = 5f;
    [SerializeField] private bool _useGravity;

    private Rigidbody _rb;
    private GameObject _source;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = _useGravity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Don't hit the source
        if (collision.gameObject == _source) return;

        //Check if we hit something damageable
        var damageReceiver = collision.gameObject.GetComponent<IDamageReceiver>();
        if (damageReceiver != null)
        {

        }
    }
}
