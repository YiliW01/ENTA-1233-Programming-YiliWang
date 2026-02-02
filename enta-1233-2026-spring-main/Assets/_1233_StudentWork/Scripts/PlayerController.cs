using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;
        
    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    [SerializeField] private float speed;

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    [SerializeField] private float jumpPower;
    private int _numberOfJumps;
    [SerializeField] private int maxNumberOfJumps = 1;

    [SerializeField]
    private Animator _animator;

    private static readonly int Speed =
        Animator.StringToHash("Speed");
        
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
              
        if (!IsGrounded())
        {
            _animator.SetBool("IsFalling", true);
            _animator.SetBool("IsLanded", false);
        }
        else
        {
            _animator.SetBool("IsFalling", false);
            _animator.SetBool("IsLanded", true);
        }

        AnimationParameters();
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        
        _direction.y = _velocity;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && _numberOfJumps >= maxNumberOfJumps) return;
        if (_numberOfJumps == 0) StartCoroutine(WaitForLanding());

        _numberOfJumps++;
        _velocity = jumpPower;
        //_velocity = jumpPower / _numberOfJumps;

        _animator.SetBool("IsJumping", true);
        
    }

    public void Testing(InputAction.CallbackContext context)
    {
        
        print("Hello");
        CameraMgr.Instance.ChangeRoomCamera();
        
    }


    private System.Collections.IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());               
        yield return new WaitUntil(IsGrounded);
        
        _numberOfJumps = 0;
        _animator.SetBool("IsJumping", false);
        _animator.SetBool("IsLanded", true);
    }

    private void AnimationParameters()
    {
        _animator.SetFloat(
            Speed, _input.sqrMagnitude);
    }

    private bool IsGrounded() => _characterController.isGrounded;
}
