using UnityEngine;
using UnityEngine.Events;

public class SphereOverlap : MonoBehaviour
{
    [SerializeField] private UnityEvent<Collider> _onColliderDetected;
}
