using UnityEngine;
using System.Collections;

public class SnakeDeathState : EnemyState
{
    private readonly SnakeBrain _brain;

    public SnakeDeathState(SnakeBrain brain, EnemyStateMachine machine) : base(machine)
    {
        _brain = brain;
    }

    public override void Enter()
    {
        if (_brain.Mover != null)
        {
            _brain.Mover.Stop();
            _brain.Mover.SetEnabled(false);
        }

        _brain.AnimatorDriver.TriggerDie();
        _brain.enabled = false;
    }
}
