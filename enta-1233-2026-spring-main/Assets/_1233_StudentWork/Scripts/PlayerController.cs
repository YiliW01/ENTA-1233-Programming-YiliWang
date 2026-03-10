using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    public Vector3 _direction;
        
    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    [SerializeField] private float speed;

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    public float _velocity;

    [SerializeField] public float jumpPower;
    public int _numberOfJumps;
    [SerializeField] public int maxNumberOfJumps = 1;

    [SerializeField]
    private Animator _animator;

    private bool isJumping;

    private static readonly int Speed =
        Animator.StringToHash("Speed");

    [SerializeField] private Health _health;

    public ProjectileWeapon Weapon;
        
    private void Awake()
    {
        if (_characterController == null) _characterController = GetComponent<CharacterController>();
        if (_health == null) _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        if (_health != null)
        {
            _health.OnDamaged += HandleDamaged;
            _health.OnDied += HandleDied;
        }
    }

    private void OnDisable()
    {
        if (_health != null)
        {
            _health.OnDamaged -= HandleDamaged;
            _health.OnDied -= HandleDied;
        }
    }

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
              
        if (IsGrounded())
        {
            _animator.SetBool("IsFalling", false);
            _animator.SetBool("IsLanded", true);
        }

        else
        {
            _animator.SetBool("IsFalling", true);
            _animator.SetBool("IsLanded", false);
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

        if (isJumping == true)
        {
            _animator.SetBool("IsJump2", true);
        }

        _numberOfJumps++;
        _velocity = jumpPower;
        //_velocity = jumpPower / _numberOfJumps;

        _animator.SetBool("IsJumping", true);
        isJumping = true;

    }

    public void Testing(InputAction.CallbackContext context)
    {
        print("Testing 1, 2, 3...");
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        Debug.Log($"Pressing attack button!");
        _animator?.SetTrigger("Attack");
    }


    public IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());               
        yield return new WaitUntil(IsGrounded);
        
        _numberOfJumps = 0;

        _animator.SetBool("IsJumping", false);
        isJumping = false;
        _animator.SetBool("IsJump2", false);
        _animator.SetBool("IsLanded", true);
    }

    private void AnimationParameters()
    {
        _animator.SetFloat(
            Speed, _input.sqrMagnitude);
    }

    public bool IsGrounded() => _characterController.isGrounded;

    private void HandleDamaged(DamageInfo info)
    {
        Debug.Log(
            $"[Character] Hit by " +
            $"{info.Source?.name ?? "Unknown"} " +
            $"for {info.Amount} damage. " +
            $"HP: {_health.CurrentHealth}/{_health.MaxHealth}");
        _animator?.SetTrigger("Hit");
    }

    private void HandleDied()
    {
        Debug.Log("[Character] Died! Gameover...");
        _animator?.SetTrigger("Die");
        _characterController = null;
    }
}
