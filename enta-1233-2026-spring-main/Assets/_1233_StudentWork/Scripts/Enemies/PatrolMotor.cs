using UnityEngine;
using System.Collections;

public class PatrolMotor : MonoBehaviour
{
    [SerializeField] private NavMeshAgentMover _agent;
    [SerializeField] private Transform[] _patrolPoints;

    private int _destination = 0;

    private void Start()
    {
        GoToPoint();       
    }

    private void GoToPoint()
    {
        _agent.SetDestination(_patrolPoints[_destination].position);
        Debug.Log($"Leaving {_destination}");
        _destination = (_destination + 1) % _patrolPoints.Length;
        Debug.Log($"Going to {_destination}");
    }

    private void Update()
    {
        if (_agent.HasPath && _agent.RemainingDistance <= 0.05f)
        {
            _agent.StartCoroutine(Pause());
        }
    }

    public IEnumerator Pause()
    {
        _agent.Stop();

        Debug.Log("Pausing for 1...");
        yield return new WaitForSeconds(1f);

        GoToPoint();
    }
}
