using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWaterInteractions : MonoBehaviour
{
    [SerializeField] private LayerMask _waterLayerMask;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private UnityEvent _leftWater;

    private void OnTriggerStay(Collider other)
    {
        if (!_waterLayerMask.Contains(other.gameObject.layer)) return;

        _playerMovement.IsWading = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_waterLayerMask.Contains(other.gameObject.layer)) return;

        _playerMovement.IsWading = false;
        _leftWater?.Invoke();
    }
}
