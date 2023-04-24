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
        Debug.Log("trigger stay");

        var movingPlatform = other.gameObject.GetComponent<MovingPlatform>();
        if (movingPlatform != null)
        {
            _playerMovement.MovementFromPlatforms = movingPlatform.Velocity;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_platformLayerMask.Contains(other.gameObject.layer)) return;
        Debug.Log("trigger exit");

        _playerMovement.MovementFromPlatforms = Vector3.zero;
    }
}
