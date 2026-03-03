using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public sealed class NavMeshAgentMover : MonoBehaviour, IMover
{
    [SerializeField] private NavMeshAgent _agent;

    //public getters for agent related information
    public Vector3 Velocity => _agent.velocity;
    public bool HasPath => _agent.hasPath;
    public float RemainingDistance => _agent.remainingDistance;
    public bool IsAtDestination => _agent.pathPending;

    public void SetDestination(Vector3 worldPos)
    {
        //Best practice: don't spam SetDestination every frame if you don't need to.
        _agent?.SetDestination(worldPos);
    }

    public void Stop()
    {
        _agent.isStopped = true;
        _agent.ResetPath();
    }

    public void Resume()
    {
        _agent.isStopped = false;
    }

    public void SetEnabled(bool value)
    {
        _agent.enabled = value;
    }
}
