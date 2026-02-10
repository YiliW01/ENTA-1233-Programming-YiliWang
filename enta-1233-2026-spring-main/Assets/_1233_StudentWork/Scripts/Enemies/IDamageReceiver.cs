using UnityEngine;
/// <summary>
/// Interface for objects that can receive damage.
/// This acts as the bridge between a hit
/// and the health system.
/// </summary>
public interface IDamageReceiver
{

    void ApplyDamage(DamageInfo info);
}
