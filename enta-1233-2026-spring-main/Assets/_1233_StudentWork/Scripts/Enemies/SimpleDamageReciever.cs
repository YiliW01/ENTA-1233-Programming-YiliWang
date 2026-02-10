using UnityEngine;

/// <summary>
/// Centralizes animation calls for enemies.
/// </summary>

public class SimpleDamageReciever : MonoBehaviour, IDamageReceiver
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damageMultiplier = 1f;

    private void Awake()
    {
        //Fallback to local if not assigned
        if (_health == null) _health = GetComponentInParent<Health>();
    }

    public void ApplyDamage(DamageInfo info)
    {
        if (_health == null) return;

        //Apply multiplier (e.g., for weak points)
        info.Amount = Mathf.RoundToInt(info.Amount * _damageMultiplier);

        _health.ApplyDamage(info);
    }
}
