using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkingMaxSpeed = 10f;
    [SerializeField] private float _wadingMaxSpeed = 5f;
    [SerializeField] private float _movementAcceleration = 5f;
    [SerializeField] private float _movementDrag = .1f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _gravityUp = 20f;
    [SerializeField] private float _gravityDown = 40f;

    [SerializeField] private UnityEvent _startedWalking;
    [SerializeField] private UnityEvent _startedIdle;
    [SerializeField] private UnityEvent _startedJump;

    private CharacterController _charController;
    private Vector2 _inputVector = Vector2.zero;
    private Vector3 _horizontalMovement = Vector3.zero;
    private float _verticalMovement = 0f;
    private float _playerRotation = 0f;
    private bool _isJumping = false;
    private float _jumpForce;

    public Vector3 MovementFromPlatforms { get; set; } = Vector3.zero;
    public bool IsWading { get; set; } = false;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        _playerRotation = transform.rotation.eulerAngles.y;
        _jumpForce = Mathf.Sqrt(2f * _jumpHeight * _gravityUp);
    }

    private void Update()
    {
        ApplyRotation();
        ApplyAcceleration();
        ApplyDeceleration();
        ApplyGravity();
        ApplyJump();
        Move();
    }

    private void Move()
    {
        if (_charController.isGrounded && _horizontalMovement.magnitude > .1f) _startedWalking?.Invoke();
        else if (_charController.isGrounded && _horizontalMovement.magnitude <= .1f) _startedIdle?.Invoke();

        Vector3 totalMovement = _horizontalMovement;
        totalMovement.y = _verticalMovement;
        totalMovement += MovementFromPlatforms;
        _charController.Move(totalMovement * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (_charController.isGrounded)
            // Reset vertical movement, but make sure we still collide with ground to make the jump work
            _verticalMovement = - _gravityDown * _charController.skinWidth;
        else
            _verticalMovement -= (_verticalMovement >= 0f ? _gravityUp : _gravityDown) * Time.deltaTime;
    }

    private void ApplyJump()
    {
        if (!_isJumping) return;

        _verticalMovement = _jumpForce;
        _isJumping = false;
        _startedJump?.Invoke();
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
        _playerRotation += _inputVector.x * _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, _playerRotation, 0f);
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
