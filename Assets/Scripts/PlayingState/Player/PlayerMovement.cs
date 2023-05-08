using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkingMaxSpeed = 10f;
    [SerializeField] private float _wadingMaxSpeed = 5f;
    [SerializeField] private float _movementAcceleration = 5f;
    [SerializeField] private float _movementDrag = .1f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _springJumpHeight = 5f;
    [SerializeField] private float _gravityUp = 20f;
    [SerializeField] private float _gravityDown = 40f;
    [SerializeField] private float _idleAnimationTreshold = .1f;

    [SerializeField] private UnityEvent _startedRunningForward;
    [SerializeField] private UnityEvent _startedRunningBackward;
    [SerializeField] private UnityEvent _startedIdle;
    [SerializeField] private UnityEvent _startedJump;
    [SerializeField] private UnityEvent _startedFall;

    private CharacterController _charController;
    private Vector2 _inputVector = Vector2.zero;
    private Vector3 _horizontalMovement = Vector3.zero;
    private float _verticalMovement = 0f;
    private bool _isJumping = false;
    private bool _isSpringJumping = false;
    private float _jumpForce;
    private float _springJumpForce;
    private PlayerState _playerState = PlayerState.Idle;

    public Vector3 MovementFromPlatforms { get; set; } = Vector3.zero;
    public bool IsWading { get; set; } = false;
    public float PlayerRotation { get; private set; } = 0f;
    public PlayerState PlayerState
    {
        get => _playerState;
        private set
        {
            if (value == _playerState) return;
            _playerState = value;

            if (value == PlayerState.Idle) _startedIdle?.Invoke();
            else if (value == PlayerState.RunningForward) _startedRunningForward?.Invoke();
            else if (value == PlayerState.RunningBackward) _startedRunningBackward?.Invoke();
            else if (value == PlayerState.Jump) _startedJump?.Invoke();
            else if (value == PlayerState.Fall) _startedFall?.Invoke();

            Debug.Log(value);
        }
    }

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        PlayerRotation = transform.rotation.eulerAngles.y;
        _jumpForce = Mathf.Sqrt(2f * _jumpHeight * _gravityUp);
        _springJumpForce = Mathf.Sqrt(2f * _springJumpHeight * _gravityUp);
    }

    private void Update()
    {
        ApplyRotation();
        ApplyAcceleration();
        ApplyDeceleration();
        ApplyGravity();
        ApplyJump();
        Move();
        UpdateAnimationStates();
    }

    private void Move()
    {
        Vector3 totalMovement = _horizontalMovement;
        totalMovement.y = _verticalMovement;
        totalMovement += MovementFromPlatforms;
        _charController.Move(totalMovement * Time.deltaTime);
    }

    private void UpdateAnimationStates()
    {
        if (_charController.isGrounded && _horizontalMovement.magnitude > _idleAnimationTreshold)
        {
            if (IsMovingForward()) PlayerState = PlayerState.RunningForward;
            else PlayerState = PlayerState.RunningBackward;
        }
        else if (_charController.isGrounded && _horizontalMovement.magnitude <= _idleAnimationTreshold)
            PlayerState = PlayerState.Idle;
        else if (PlayerState != PlayerState.Jump)
            PlayerState = PlayerState.Fall;
    }

    private bool IsMovingForward()
    {
        return Vector3.Dot(_horizontalMovement, transform.forward) >= 0;
    }

    private void ApplyGravity()
    {
        if (_charController.isGrounded)
            // Reset vertical movement, but make sure we still collide with ground to make the jump work
            _verticalMovement = -_gravityDown * _charController.skinWidth;
        else
            _verticalMovement -= (_verticalMovement >= 0f ? _gravityUp : _gravityDown) * Time.deltaTime;
    }

    private void ApplyJump()
    {
        if (_isSpringJumping)
        {
            _verticalMovement = _springJumpForce;
            _isSpringJumping = false;
            PlayerState = PlayerState.Jump;
        }
        if (_isJumping)
        {
            _verticalMovement = _jumpForce;
            _isJumping = false;
            PlayerState = PlayerState.Jump;
        }
    }

    private void ApplyDeceleration()
    {
        _horizontalMovement *= 1 - _movementDrag * Time.deltaTime;
    }

    private void ApplyAcceleration()
    {
        _horizontalMovement += transform.forward * _inputVector.y * _movementAcceleration * Time.deltaTime;
        float maxSpeed = IsWading ? _wadingMaxSpeed : _walkingMaxSpeed;
        if (_horizontalMovement.magnitude > maxSpeed)
            _horizontalMovement = _horizontalMovement.normalized * maxSpeed;
    }

    private void ApplyRotation()
    {
        PlayerRotation += _inputVector.x * _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, PlayerRotation, 0f);
    }

    public void OnSpringJump()
    {
        _isSpringJumping = true;
    }

    public void OnJump(InputValue value)
    {
        if (_charController.isGrounded) _isJumping = true;
    }

    public void OnMove(InputValue value)
    {
        _inputVector = value.Get<Vector2>();
        if (_inputVector.magnitude > 1f)
        {
            _inputVector = _inputVector.normalized;
        }
    }
}

public enum PlayerState
{
    Idle,
    RunningForward,
    RunningBackward,
    Jump,
    Fall
}
