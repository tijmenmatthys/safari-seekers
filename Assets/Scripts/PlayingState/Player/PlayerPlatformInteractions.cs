using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformInteractions : MonoBehaviour
{
    [SerializeField] private LayerMask _platformLayerMask;
    [SerializeField] private PlayerMovement _playerMovement;

    private void OnTriggerStay(Collider other)
    {
        if (!_platformLayerMask.Contains(other.gameObject.layer)) return;

        var movingPlatform = other.gameObject.GetComponent<MovingPlatform>();
        if (movingPlatform != null)
            _playerMovement.MovementFromPlatforms = movingPlatform.Velocity;

        var crumblingPlatform = other.gameObject.GetComponent<CrumblingPlatform>();
        if (crumblingPlatform != null)
            crumblingPlatform.OnPlayerStay();

        var spring = other.gameObject.GetComponent<Spring>();
        if (spring != null)
            if (spring.TryJump())
                _playerMovement.OnSpringJump();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_platformLayerMask.Contains(other.gameObject.layer)) return;

        _playerMovement.MovementFromPlatforms = Vector3.zero;

        var crumblingPlatform = other.gameObject.GetComponent<CrumblingPlatform>();
        if (crumblingPlatform != null)
            crumblingPlatform.OnPlayerExit();

        var spring = other.gameObject.GetComponent<Spring>();
        if (spring != null)
            spring.ResetJump();
    }
}
