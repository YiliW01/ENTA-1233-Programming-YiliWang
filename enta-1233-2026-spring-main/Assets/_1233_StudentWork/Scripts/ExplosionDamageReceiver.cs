using UnityEngine;

public class ExplosionDamageReceiver : MonoBehaviour
{
    [SerializeField] private int _damage = 100;
    [SerializeField] private GameObject _source;
    

    public void Damage(Collider other)
    {
        var damageReceiver = other.GetComponent<IDamageReceiver>();
        if (damageReceiver != null)
        {
            var info = new DamageInfo
            {
                Amount = _damage,
                Source = _source,
                HitPoint = other.transform.position,
                HitNormal = Vector3.up
            };
            damageReceiver.ApplyDamage(info);
        }
    }
}
