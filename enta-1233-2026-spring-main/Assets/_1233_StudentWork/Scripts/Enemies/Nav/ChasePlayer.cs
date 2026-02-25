using UnityEngine;

[RequireComponent(typeof(NavMeshAgentMover))]
public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private NavMeshAgentMover _agent;
    [SerializeField] private Transform _destination;
    [SerializeField] private PlayerTargetProvider _targetProvider;

     private void Update()
    {
        //_targetProvider.GetTargetPosition();
        _agent.SetDestination(_targetProvider.GetTargetPosition());
    }
}

