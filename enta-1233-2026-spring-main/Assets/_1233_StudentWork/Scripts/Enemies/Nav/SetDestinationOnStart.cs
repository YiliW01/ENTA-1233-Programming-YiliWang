using UnityEngine;

[RequireComponent(typeof(NavMeshAgentMover))]
public class SetDestinationOnStart : MonoBehaviour
{
    [SerializeField] private NavMeshAgentMover _agent;
    [SerializeField] private Transform _destination;
    [SerializeField] private PlayerTargetProvider _targetProvider;

    private void Start()
    {
        _agent.SetDestination(_destination.position);
    }

    private void Update()
    {
        //_targetProvider.GetTargetPosition();
        //_agent.SetDestination(_targetProvider.GetTargetPosition());
    }
}
