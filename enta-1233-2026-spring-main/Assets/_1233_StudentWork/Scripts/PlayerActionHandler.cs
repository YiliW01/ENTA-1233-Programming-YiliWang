using UnityEngine;

public class PlayerActionHandler : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    public void Attack()
    {
        Debug.Log("IS ATTACKING");
    }

    public void Jump()
    {
        if (!_controller.IsGrounded() && _controller._numberOfJumps >= _controller.maxNumberOfJumps) return;
        if (_controller._numberOfJumps == 0) _controller.StartCoroutine(_controller.WaitForLanding());

        _controller._numberOfJumps++;
        _controller._velocity = _controller.jumpPower;
        //_velocity = jumpPower / _numberOfJumps;
    }
}
