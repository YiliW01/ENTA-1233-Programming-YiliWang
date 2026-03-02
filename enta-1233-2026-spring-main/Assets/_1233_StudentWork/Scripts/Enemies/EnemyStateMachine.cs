using UnityEngine;
using System.Collections;

/// <summary>
/// Simple state machine for controlling enemy behaviour.
/// </summary>
public class EnemyStateMachine : MonoBehaviour
{
    private EnemyState _currentState;

    private void Update()
    {
        _currentState?.Tick();
        WaitForTock();
    }

    private IEnumerator WaitForTock()
    {
        yield return new WaitForSeconds(2f);
        _currentState?.Tock();
    }
    public void Initialize(EnemyState initialState)
    {
        _currentState = initialState;
        _currentState.Enter();
    }

    public void ChangeState(EnemyState newState)
    {
        if (newState == null) return;

        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
