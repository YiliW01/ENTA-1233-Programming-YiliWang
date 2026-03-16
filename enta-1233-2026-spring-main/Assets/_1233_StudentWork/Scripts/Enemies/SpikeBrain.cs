using UnityEngine;

/// <summary>
/// Brain for the Spike enemy. Focuses on patrol movement and contact damage.
/// </summary>
public class SpikeBrain : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PatrolMotor _patrolMotor;
    [SerializeField] private ContactDamage _contactDamage;
    [SerializeField] private EnemyAnimatorDriver _animatorDriver;

    private IMover _mover;

    private void Awake()
    {
        if (_health == null) _health = GetComponent<Health>();
        if (_patrolMotor == null) _patrolMotor = GetComponent<PatrolMotor>();
        if (_contactDamage == null) _contactDamage = GetComponent<ContactDamage>();
        if (_animatorDriver == null) _animatorDriver = GetComponent<EnemyAnimatorDriver>();
        _mover = GetComponent<IMover>();
    }

    private void Update()
    {
        if (_health != null && _health.IsDead) return;

        // Update animator based on mover velocity
        if (_animatorDriver != null && _mover != null) _animatorDriver.SetSpeed(_mover.Velocity.magnitude);
    }

    private void OnEnable()
    {
        if (_health != null) _health.OnDied += HandleDied;
        if (_health != null) _health.OnDamaged += HandleDamaged;
    }

    private void OnDisable()
    {
        if (_health != null) _health.OnDied -= HandleDied;
        if (_health != null) _health.OnDamaged -= HandleDamaged;
    }

    private void HandleDamaged(DamageInfo info)
    {
        Debug.Log(
            $"[Spike] Hit by " +
            $"{info.Source?.name ?? "Unknown"} " +
            $"for {info.Amount} damage. " +
            $"HP: {_health.CurrentHealth}/{_health.MaxHealth}");
        _animatorDriver?.TriggerHit();
    }

    private void HandleDied()
    {
        if (_patrolMotor != null) _patrolMotor.enabled = false;
        if (_contactDamage != null) _contactDamage.enabled = false;
        if (_mover != null)
        {
            _mover.Stop();
            _mover.SetEnabled(false);
        }

        if (_animatorDriver != null) _animatorDriver.TriggerDie();
        enabled = false;
    }
}
