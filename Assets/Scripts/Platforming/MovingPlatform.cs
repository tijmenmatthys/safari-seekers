using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] _controlPoints;
    [SerializeField] private bool _isCircularMovement = false;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _waitTime = 1f;

    private int _currentTarget; // current control point that the platform is moving towards
    private bool _isMoving = true; // whether the platform is currently moving towards the next control point
    private bool _isMovingForward = true;

    public Vector3 Velocity =>
        (_controlPoints[_currentTarget].position - transform.position) .normalized * _movementSpeed;

    private void Start()
    {
        // start by moving towards the second control point (assuming there is at least one more)
        _currentTarget = 1;
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position
                , _controlPoints[_currentTarget].position, _movementSpeed * Time.deltaTime);


            if (transform.position == _controlPoints[_currentTarget].position)
                StartCoroutine(WaitAtControlPoint());
        }
    }

    private void SetNextTarget()
    {
        if (_isMovingForward)
        {
            _currentTarget++;
            if (_currentTarget == _controlPoints.Length)
            {
                if (_isCircularMovement) _currentTarget = 0;
                else
                {
                    _currentTarget = _controlPoints.Length - 2;
                    _isMovingForward = false;
                }
            }
        }
        else
        {
            _currentTarget--;
            if (_currentTarget == -1)
            {
                _currentTarget = 1;
                _isMovingForward = true;
            }
        }
    }

    private IEnumerator WaitAtControlPoint()
    {
        _isMoving = false;
        yield return new WaitForSeconds(_waitTime);
        SetNextTarget();
        _isMoving = true;
    }
}
