using UnityEngine;

public class BloomDeathState : EnemyState
{
    private readonly BloomBrain _brain;

    public BloomDeathState(BloomBrain brain, EnemyStateMachine machine) : base(machine)
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
