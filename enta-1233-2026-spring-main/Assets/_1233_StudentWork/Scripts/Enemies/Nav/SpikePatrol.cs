using UnityEngine;

[RequireComponent(typeof(NavMeshAgentMover))]
public class SpikePatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgentMover _agent;
    [SerializeField] private Transform[] _patrolPoints;

     private void Start()
    {
        //_targetProvider.GetTargetPosition();
        _agent.SetDestination(_patrolPoints[0].position);
        
    }
}

