using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChasePlayer : MonoBehaviour
{
    public float AttackDistance;
    public Transform Target;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerTargetProvider _targetProvider;

    public Vector3 Velocity => _agent.velocity;
    public float RemainingDistance => _agent.remainingDistance;

     private void Update()
    {
        _agent.SetDestination(_targetProvider.GetTargetPosition());
    }
}

